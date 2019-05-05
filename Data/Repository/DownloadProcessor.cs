using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Data.Model;
using Domain.Repository;
using File = Domain.Model.File;

namespace Data.Repository
{
    public class DownloadProcessor : Domain.Repository.DownloadProcessor
    {
        private FileEntity _file;
        private Thread _currentThread;
        private Stream stream;
        private WebResponse response;
        private WebRequest req;
        private int progress = 1;
        private long length = 0;
        public DownloadProcessor(File file, IDownloadListner downloadListner) : base(file, downloadListner)
        {
            _file = new FileEntity(file.Url, file.Location, file.FileType);
        }

        public override void Start()
        {
            _currentThread = new Thread(() =>
            {
                _downloadListner.Start();
                try
                {
                    req = WebRequest.Create(_file.Url);
                    response = req.GetResponse();
                    stream = response.GetResponseStream();
                    length = stream.Length;

                    while (stream.CanRead)
                    {

                        int nextByte = stream.ReadByte();
                    }
                }
                catch (Exception)
                {
                    _downloadListner.Cancel(-2);
                }
            });

            _currentThread.Start();
           
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Resume()
        {
            throw new NotImplementedException();
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Termiinate()
        {
            throw new NotImplementedException();
        }
    }
}
