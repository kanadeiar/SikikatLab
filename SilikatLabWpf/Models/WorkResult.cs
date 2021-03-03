using System;

namespace SilikatLabWpf.Models
{
    public class WorkResult
    {
        public DateTime DateTime { get; set; }
        public WorkTask WorkTask { get; set; }
        public WorkShift WorkShift { get; set; }
        public Laboratorian Laboratorian { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Results { get; set; }
        public string Description { get; set; }
    }
}
