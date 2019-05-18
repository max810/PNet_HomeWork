using PNet_HomeWork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PNet_Again.Models
{
    public class SwimmingCharacteristics
    {
        [Required]
        public bool HasBag { get; set; }
        [Required]
        [Range(0.1, 10)]
        public double AverageSpeed { get; set; }
        [Required]
        [Range(0.1, 10)]
        public double AverageDepth { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }
    }
}