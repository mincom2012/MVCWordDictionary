using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWordDictionary.Models
{
    [MetadataType(typeof(NewsMetaData))]
    public partial class News
    {
        public class NewsMetaData
        {
            public System.Guid NewID { get; set; }

            [Required]
            [StringLength(maximumLength:255)]
            [MaxWords(10)]
            public string Title { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            [AllowHtml]
            [Display(Name = "Content")]
            public string Contents { get; set; }

            [Display(Name="Image thumb")]
            public string ImageThumb { get; set; }

            public string Image { get; set; }

            public string Author { get; set; }

            [Display(Name="News type")]
            public Nullable<int> NewType { get; set; }

            [DisplayFormat(DataFormatString="{0:dd/MM/yyyy hh:mm:ss}")]
            public Nullable<System.DateTime> CreatedDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
            public Nullable<System.DateTime> ModifiedDate { get; set; }
        }
    }
}