using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Repository
{
    public interface IDownloadListner
    {
        void Start();
        void Update(int progress);
        void Pause(int progress);
        void Resume(int progress);
        void Cancel(int progress);
        void Complete(int progress);
    }
}
