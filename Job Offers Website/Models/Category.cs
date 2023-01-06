using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Job_Offers_Website.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="نوع الوظيفة")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name ="وصف الوظيفة")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; } // Relationship between Job and Category as a collection

    }
}