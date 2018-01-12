using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Data.Model.Mapper
{
    public class SiteEntityMapper
    {
        private FileEntityMapper _fileEntityMapper;

        public SiteEntityMapper(FileEntityMapper fileEntityMapper)
        {
            _fileEntityMapper = fileEntityMapper;
        }

        public Site Transform(SiteEntity siteEntity)
        {
            return new Site(_fileEntityMapper.TransformList(siteEntity.FileEntitys));
        }
    }
}
