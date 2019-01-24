using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreAngularWebApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Headline { get; set; }   
        public string Articletext { get; set; } 
        public string Author { get; set; } 
    }
}
