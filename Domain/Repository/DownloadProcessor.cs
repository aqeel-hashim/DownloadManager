using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Repository
{
    public abstract class DownloadProcessor
    {
        private File _file;
        private IDownloadListner _downloadListner;
        public File File
        {
            get => _file;
            set => _file = value;
        }

        public IDownloadListner DownloadListner
        {
            get => _downloadListner;
            set => _downloadListner = value;
        }

        protected DownloadProcessor(File file, IDownloadListner downloadListner)
        {
            _file = file;
            _downloadListner = downloadListner;
        }

        public abstract void Start();
        public abstract void Pause();
        public abstract void Resume();
        public abstract void Cancel();
        public abstract void Termiinate();

        protected bool Equals(DownloadProcessor other)
        {
            return Equals(_file, other._file) && Equals(_downloadListner, other._downloadListner);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DownloadProcessor) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_file != null ? _file.GetHashCode() : 0) * 397) ^ (_downloadListner != null ? _downloadListner.GetHashCode() : 0);
            }
        }
    }
}
