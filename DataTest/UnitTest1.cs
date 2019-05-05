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
            var grabber = new SiteGrabber(@"https://www.youtube.com/watch?v=c9X3kP3fd4Y");
            var entity = grabber.Site(File.Type.Video);
            foreach (var entityFileEntity in entity.FileEntitys)
            {
                Trace.WriteLine(entityFileEntity.Url);
            }
            
            Assert.IsTrue(entity.FileEntitys.Count > 0 /*&& entity.FileEntitys.ElementAt(0) != null*/);
        }
    }
}
