using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using MVCWordDictionary.Entities;
using System.Text;

namespace MVCWordDictionary
{
    public class RssReader
    {
        public static List<RssNews> Read(string url)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            var webCliet = new WebClient();
            webCliet.Encoding = Encoding.UTF8;
            string result = webCliet.DownloadString(url);
            XDocument document = XDocument.Parse(result);

            var lst = document.Descendants("item").Select(item => new RssNews
            {
                Author = item.GetValueElement("author"),
                Category = item.GetValueElement("category"),
                Comments = item.GetValueElement("comments"),
                Description = item.GetValueElement("description"),
                Enclosure = item.GetValueElement("enclosure"),
                Link = item.GetValueElement("link"),
                PublishDate = item.GetValueElement("pubDate"),
                Source = item.GetValueElement("source"),
                Title = item.GetValueElement("title")
            });

            return lst.ToList();
        }

    }



}