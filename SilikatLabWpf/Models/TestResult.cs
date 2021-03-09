using System;
using System.ComponentModel.DataAnnotations;
using SilikatLabWpf.Models.Base;

namespace SilikatLabWpf.Models
{
    public class TestResult : Entity
    {
        [Required]
        public DateTime DateTime { get; set; }
        [MaxLength(100), Required]
        public string ResearchName { get; set; }
        [MaxLength(100), Required]
        public string ObjectName { get; set; }
        [MaxLength(100)]
        public string WorkShiftName { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        public double Value { get; set; }
        [MaxLength(200)]
        public string Result { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
