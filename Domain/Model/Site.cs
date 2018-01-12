using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Model
{
    public class Site
    {
        private List<File> _files;

        public List<File> Files
        {
            get => _files;
            set => _files = value;
        }

        public Site()
        {
            _files = new List<File>();
        }

        public Site(File file)
        {
            _files = new List<File> {file};
        }

        public Site(List<File> files)
        {
            _files = files;
        }

        protected bool Equals(Site other)
        {
            return Equals(_files, other._files);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Site) obj);
        }

        public override int GetHashCode()
        {
            return (_files != null ? _files.GetHashCode() : 0);
        }
    }
}
