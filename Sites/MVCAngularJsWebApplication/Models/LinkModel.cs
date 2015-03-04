using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngularJsWebApplication.Models
{
    [Serializable]
    public class LinkModel
    {
        public int Id { get; set; }
        public string Href { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}