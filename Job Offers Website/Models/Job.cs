using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Offers_Website.Models
{
    public class Job
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="اسم الوظيفة")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "وصف الوظيفة")]
        public string JobContent { get; set; }
        [Display(Name = "صورة الوظيفة")]
        public string JobImage { get; set; }

        [Display(Name = "نوع الوظيفة")]
        public int CategoryID { get; set; } // PK,FK Categories و Job  الربط بين جدول 

        public virtual Category MyProperty { get; set; } // Calling Category Model Class
    }
}