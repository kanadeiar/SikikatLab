using System;

namespace SilikatLabWpf.Models
{
    public class WorkTask
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public Research Research { get; set; }
        public ResearchObject ResearchObject { get; set; }
    }
}
