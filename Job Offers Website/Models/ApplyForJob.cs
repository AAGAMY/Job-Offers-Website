using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Job_Offers_Website.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }

        //سنقوم بعمل مفاتيح بين الجداول User و Job وجدولين ApplyForJob للعلاقات بين جدول الـ
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}