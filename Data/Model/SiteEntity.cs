using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class SiteEntity
    {
        private List<FileEntity> _FileEntitys;

        public List<FileEntity> FileEntitys
        {
            get => _FileEntitys;
            set => _FileEntitys = value;
        }

        public SiteEntity()
        {
            _FileEntitys = new List<FileEntity>();
        }

        public SiteEntity(FileEntity FileEntity)
        {
            _FileEntitys = new List<FileEntity> { FileEntity };
        }

        public SiteEntity(List<FileEntity> FileEntitys)
        {
            _FileEntitys = FileEntitys;
        }

        protected bool Equals(SiteEntity other)
        {
            return Equals(_FileEntitys, other._FileEntitys);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SiteEntity)obj);
        }

        public override int GetHashCode()
        {
            return (_FileEntitys != null ? _FileEntitys.GetHashCode() : 0);
        }
    }
}
