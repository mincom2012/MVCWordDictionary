using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Entities
{
    public class RssNews
    {
        public string Author { get; set; }

        public string Category { get; set; }

        public string Comments { get; set; }

        public string Description { get; set; }

        public string Enclosure { get; set; }

        public string Link { get; set; }

        public string PublishDate { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }
    }
}