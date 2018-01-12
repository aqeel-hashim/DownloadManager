using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;
using Domain.Repository;

namespace Domain.Interactor
{
    public class GetSite
    {
        private ISiteRepository _siteRepository;

        public GetSite(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public Site Site(string url)
        {
            return _siteRepository.Site(url);
        }
    }
}
