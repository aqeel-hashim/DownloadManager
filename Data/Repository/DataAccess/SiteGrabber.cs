using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;

namespace Data.Repository.DataAccess
{
    public class SiteGrabber
    {
        private string _url;

        public SiteGrabber(string url)
        {
            _url = url;
        }

        public SiteEntity Site()
        {
            var siteEntity = new SiteEntity();

            return siteEntity;
        }
    }
}
