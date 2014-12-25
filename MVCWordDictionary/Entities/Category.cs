using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCWordDictionary.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        public class CategoryMetaData {
            public int CategoryID { get; set; }

            [Display(Name="Category name")]
            [Remote("CheckCategoryName","Category",AdditionalFields="categoryName", ErrorMessage="Exist Category name.")]
            [Required]
            public string CategoryName { get; set; }

            [Display(Name = "Description")]
            [StringLength(maximumLength: 500)]
            public string Description { get; set; }

        }
        
    }
}