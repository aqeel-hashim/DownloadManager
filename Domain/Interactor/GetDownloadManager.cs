using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Interactor
{
    public class GetDownloadManager
    {
        private static readonly DownloadManager _downloadManager;

        static GetDownloadManager()
        {
            _downloadManager = new DownloadManager();
        }

        public DownloadManager GetManager()
        {
            return _downloadManager;
        }

    }
}
