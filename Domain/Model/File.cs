using System;
using System.Threading;

namespace Domain.Model
{
    public class File
    {
        public enum Type
        {
            Video,
            Image
        }
        private int _id;
        private string _url;
        private string _name;
        private string _ext;
        private string _location;
        private File.Type _fileType;

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

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Ext
        {
            get => _ext;
            set => _ext = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public Type FileType
        {
            get => _fileType;
            set => _fileType = value;
        }

        public File(string url, string name, string ext, string location, Type fileType)
        {
            Interlocked.Increment(ref _id);
            _url = url;
            _name = name;
            _ext = ext;
            _location = location;
            _fileType = fileType;
        }

        protected bool Equals(File other)
        {
            return _id == other._id && string.Equals(_url, other._url)
                                    && string.Equals(_name, other._name) 
                                    && string.Equals(_ext, other._ext) 
                                    && string.Equals(_location, other._location) && _fileType == other._fileType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((File) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _id;
                hashCode = (hashCode * 397) ^ (_url != null ? _url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_ext != null ? _ext.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_location != null ? _location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _fileType;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(_id)}: {_id}, " +
                   $"{nameof(_url)}: {_url}, " +
                   $"{nameof(_name)}: {_name}, {nameof(_ext)}: {_ext}, " +
                   $"{nameof(_location)}: {_location}, {nameof(_fileType)}: {_fileType}";
        }
    }
}
