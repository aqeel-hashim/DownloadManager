using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Interactor
{
    public class Query
    {
        private readonly QueryFactory _queryFactory;

        public Query(QueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public List<File> Files(QueryFactory.QueryType type, string query, Site site)
        {
            return _queryFactory.Site(site).Build(type, query).Query();
        }
    }
}
