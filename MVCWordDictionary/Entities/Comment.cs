using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCWordDictionary.CustomAttribute;

namespace MVCWordDictionary.Models
{
    [Serializable]
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Comment
    {
        public class CategoryMetaData {

            [Display(Name="Comment id")]
            public System.Guid CommentID { get; set; }

            [InputMark(mask:"Input commnet")]
            [Display(Name = "Contents")]
            public string Contents { get; set; }
            public Nullable<int> Likes { get; set; }
            public Nullable<int> UnLikes { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public Nullable<System.DateTime> ModifiedDate { get; set; }
            public Nullable<System.Guid> NewID { get; set; }
        
        }
    }
}