using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.GitHub_Objects
{
    public class Release
    {
        public string url {  get; set; } 
        public string tag_name { get; set; }
        public string name { get; set; }
        public bool prerelease { get; set; }
        public DateTime published_at { get; set; }
        public string html_url { get; set; }
        public string body { get; set; }
    }
}
