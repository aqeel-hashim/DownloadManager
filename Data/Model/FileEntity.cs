using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Domain.Model;

namespace Data.Model
{
    public class FileEntity
    {
        private int _id;
        private string _url;
        private string _location;
        private File.Type _type;

        public FileEntity(File.Type type)
        {
            _type = type;
            Interlocked.Increment(ref _id);
            _url = "";
            _location = "";
        }

        public FileEntity(string url, string location, File.Type type)
        {
            Interlocked.Increment(ref _id);
            _url = url;
            _location = location;
            _type = type;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Url
        {
            get => _url;
            set => _url = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public File.Type Type
        {
            get => _type;
            set => _type = value;
        }

        protected bool Equals(FileEntity other)
        {
            return _id == other._id && string.Equals(_url, other._url) && string.Equals(_location, other._location) && _type == other._type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FileEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _id;
                hashCode = (hashCode * 397) ^ (_url != null ? _url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_location != null ? _location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _type;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, {nameof(_url)}: {_url}, {nameof(_location)}: {_location}, {nameof(_type)}: {_type}";
        }
    }
}
