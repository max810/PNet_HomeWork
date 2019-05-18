using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using PNet_Again.Models;
using System.ComponentModel.DataAnnotations;

namespace PNet_HomeWork.Models
{
    public class Fish
    {
        public int FishId { get; set; }
        public int? RiverId { get; set; }
        public River River { get; set; }
        public string ShortName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ScientificName { get; set; }

        [Required]
        public SwimmingCharacteristics SwimmingCharacteristics { get; set; }

        [Required]
        public FinType FinType { get; set; }

        [Range(0.1, 100)]
        public double Width { get; set; }
        [Range(0.1, 100)]
        public double Height { get; set; }
        [Range(0.1, 100)]
        public double Length { get; set; }
    }
}
