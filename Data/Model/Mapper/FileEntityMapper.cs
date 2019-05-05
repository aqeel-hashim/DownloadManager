using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;

namespace Data.Model.Mapper
{
    public class FileEntityMapper
    {
        public File Transform(FileEntity fileEntity)
        {
            var file = new File(fileEntity.Url, fileEntity.Url.Split('/').Last().Split('?')[0],
                fileEntity.Url.Split('.').Last(), fileEntity.Location, fileEntity.Type) {Id = fileEntity.Id};
            return file;
        }

        public List<File> TransformList(List<FileEntity> fileEntities)
        {
            return fileEntities.Select(fileEntity => this.Transform(fileEntity)).ToList();
        }
    }
}
    