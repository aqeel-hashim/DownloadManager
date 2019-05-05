using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Data.Model;
using HtmlAgilityPack;
using File = Domain.Model.File;

namespace Data.Repository.DataAccess
{
    public class SiteGrabber
    {
        private readonly string _url;

        public SiteGrabber(string url)
        {
            _url = url;
        }

        public SiteEntity Site(Domain.Model.File.Type type)
        {
            var siteEntity = new SiteEntity();


            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(_url);
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows; U; MSIE 9.0; WIndows NT 9.0; en-US))";
            req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            string sourceTaken;
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                sourceTaken = reader.ReadToEnd();
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(sourceTaken);
            
            Trace.WriteLine(doc.DocumentNode.ChildNodes.Descendants("video").Count());
            var descendantsList = type == File.Type.Image ? doc.DocumentNode.Descendants("img") : doc.DocumentNode.Descendants("video");
            // For every tag in the HTML containing the node img.
            foreach (var link in descendantsList
                .Select(i => !string.IsNullOrEmpty(i.Attributes["src"].Value) ? i.Attributes["src"] : i.Attributes["source"]))
            {
                // Storing all links found in an array.
                // You can declare this however you want.
                var editedUrl = link.Value;
                if (!IsAbsoluteUrl(link.Value))
                {
                    var removeString = _url.Split("/")[_url.Split("/").Length - 1];
                    editedUrl = _url;
                    editedUrl = editedUrl.Replace(removeString, "");
                    editedUrl += link.Value;
                }
               
                var file = new FileEntity(editedUrl, null, type);
                siteEntity.FileEntitys.Add(file);
            }

            return siteEntity;
        }

        private bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }
    }
}
