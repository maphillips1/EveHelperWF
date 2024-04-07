using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveHelperWF.Objects.GitHub_Objects
{
    public class CreateIssueResponse
    {
        public long id {  get; set; }
        public string node_id { get; set; }
        public string url { get; set; }
        public string repository_url { get; set; }
    }
}
