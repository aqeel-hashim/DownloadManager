using System.Diagnostics;
using System.Linq;
using Data.Repository.DataAccess;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DataSiteGrabberTest()
        {
            var grabber = new SiteGrabber(@"https://vimeo.com/253530307");
            var entity = grabber.Site(File.Type.Image);
            foreach (var entityFileEntity in entity.FileEntitys)
            {
                Trace.WriteLine(entityFileEntity.Url);
            }
            
            Assert.IsTrue(entity.FileEntitys.Count > 0 /*&& entity.FileEntitys.ElementAt(0) != null*/);
        }
    }
}
