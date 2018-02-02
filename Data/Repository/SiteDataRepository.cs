using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.Model.Mapper;
using Data.Repository.DataAccess;
using Domain.Model;
using Domain.Repository;

namespace Data.Repository
{
    public class SiteDataRepository : ISiteRepository
    {
        private SiteEntityMapper _siteEntityMapper;

        public SiteDataRepository(SiteEntityMapper siteEntityMapper)
        {
            _siteEntityMapper = siteEntityMapper;
        }

        public Site Site(string url)
        {
            var siteGrabber = new SiteGrabber(url);
            var siteEntityImage = siteGrabber.Site(File.Type.Image);
            var siteEntityVideo = siteGrabber.Site(File.Type.Video);
            siteEntityImage.FileEntitys.AddRange(siteEntityVideo.FileEntitys);
            return _siteEntityMapper.Transform(siteEntityImage);
        }
    }
}
