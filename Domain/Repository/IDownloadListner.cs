using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Repository
{
    public interface IDownloadListner
    {
        void Start(File file);
        void Update(File file, int progress);
        void Pause(File file, int progress);
        void Resume(File file, int progress);
        void Cancel(File file, int progress);
        void Complete(File file, int progress);
    }
}
