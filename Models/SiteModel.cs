using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRSP_Parallel.Models
{
    public class SiteModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string ErrorMessage { get; set; }

        public bool Online { get; set; }
    }
}