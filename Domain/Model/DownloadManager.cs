using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repository;

namespace Domain.Model
{
    public class DownloadManager
    {
        private readonly List<DownloadProcessor> _downloadProcessors;

        public DownloadManager()
        {
            _downloadProcessors = new List<DownloadProcessor>();
        }

        public DownloadManager(DownloadProcessor downloadProcessor)
        {
            _downloadProcessors = new List<DownloadProcessor>() { downloadProcessor };
        }

        public DownloadManager(List<DownloadProcessor> downloadProcessors)
        {
            _downloadProcessors = downloadProcessors;
        }

        public enum Actions
        {
            Start,
            Pause,
            Resume,
            Cancel
        }

        public void AddDownloadProcessor(DownloadProcessor downloadProcessor)
        {
            _downloadProcessors.Add(downloadProcessor);
        }

        public void Process(Actions action, File file)
        {
            var downloadProcessor = _downloadProcessors.Find(x => x.File.Equals(file));
            if (downloadProcessor == null)
            {
                throw new Exception("Please add appropriate DownloadProcessor for the given file");
            }
            switch (action)
            {
                case Actions.Start:
                    downloadProcessor.Start();
                    break;
                case Actions.Pause:
                    downloadProcessor.Pause();
                    break;
                case Actions.Resume:
                    downloadProcessor.Resume();
                    break;
                case Actions.Cancel:
                    downloadProcessor.Cancel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        public void Terminate(File file)
        {
            var downloadProcessor = _downloadProcessors.Find(x => x.File.Equals(file));
            if (downloadProcessor == null)
            {
                throw new Exception("Please add appropriate DownloadProcessor for the given file");
            }
            downloadProcessor.Termiinate();
        }

        public void Terminate()
        {
            _downloadProcessors.ForEach(d => d.Termiinate());
        }

    }
}
