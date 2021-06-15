using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace EntityLayer.Concrete
{
    public class Draft
    {
        [Key]
        public int ID { get; set; }
        public string RecieverMail { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string MessageContent { get; set; }

    }
}
