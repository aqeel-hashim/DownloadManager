using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.Model
{
    public abstract class QueryParent
    {
        protected string _querystring;
        protected List<File> _files;

        public string QueryString
        {
            get => _querystring;
            set => _querystring = value;
        }

        public List<File> Files
        {
            get => _files;
            set => _files = value;
        }

        protected QueryParent(string querystring, List<File> files)
        {
            _querystring = querystring;
            _files = files;
        }

        public abstract List<File> Query();
    }

    public class QueryFileType : QueryParent
    {
        public QueryFileType(string querystring, List<File> files) : base(querystring, files)
        {
        }

        public override List<File> Query()
        {
            return _files.Where(f => f.Ext.Equals(_querystring) || f.Ext.Contains(_querystring)).ToList();
        }
    }

    public class QueryFileName : QueryParent
    {
        public QueryFileName(string querystring, List<File> files) : base(querystring, files)
        {
        }

        public override List<File> Query()
        {
            return _files.Where(f => f.Name.Equals(_querystring) || f.Name.Contains(_querystring)).ToList();
        }
    }

    public class QueryFileUrlPattern : QueryParent
    {
        public QueryFileUrlPattern(string querystring, List<File> files) : base(querystring, files)
        {
        }

        public override List<File> Query()
        {
            return _files.Where(f => new Regex(_querystring).IsMatch(f.Url)).ToList();
        }
    }

    public class QueryFactory
    {
        public enum QueryType
        {
            Filetype,
            Filename,
            Urlpattern
        }

        private QueryParent _queryParent;
        private Site _siteObj;

        public QueryFactory(Site siteObj)
        {
            _siteObj = siteObj;
        }

        public QueryFactory Build(QueryType type, string query)
        {
            switch (type)
            {
                case QueryType.Filename:
                    _queryParent = new QueryFileName(query,_siteObj.Files);
                    break;
                case QueryType.Filetype:
                    _queryParent = new QueryFileType(query, _siteObj.Files);
                    break;
                case QueryType.Urlpattern:
                    _queryParent = new QueryFileUrlPattern(query, _siteObj.Files);
                    break;
            }

            return this;
        }

        public QueryFactory QueryString(string query)
        {
            if (_queryParent != null)
                _queryParent.QueryString = query;
            else
            {
                throw new Exception("Please build the Query Object first");
            }
            return this;
        }

        public QueryFactory QueryFiles(List<File> files)
        {
            if (_queryParent != null)
                _queryParent.Files = files;
            else
            {
                throw new Exception("Please build the Query Object first");
            }
            return this;
        }

        public QueryFactory Site(Site site)
        {
            _siteObj = site;
            return this;
        }

        public List<File> Query()
        {
            return _queryParent.Query();
        }

        public QueryParent Get()
        {
            return _queryParent;
        }

    }
}
