using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}