using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPDP.Models
{
    public class TreeViewNode
    {
        public string Id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public List<TreeViewNode> ChildList = new List<TreeViewNode>();
    }
}
