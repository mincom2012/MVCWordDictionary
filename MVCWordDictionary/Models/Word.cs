//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWordDictionary.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Word
    {
        public Word()
        {
            this.Answer = new HashSet<Answer>();
            this.LessonDetail = new HashSet<LessonDetail>();
        }
    
        public int WordID { get; set; }
        public string WordName { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public Nullable<int> CategoryID { get; set; }
    
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<LessonDetail> LessonDetail { get; set; }
    }
}