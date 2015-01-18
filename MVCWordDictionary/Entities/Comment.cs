using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWordDictionary.Models
{
    [Serializable]
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Comment
    {
        [Serializable]
        public class CategoryMetaData { 
        
        }
    }
}