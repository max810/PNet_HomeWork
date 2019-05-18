using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PNet_HomeWork.Models
{
    public class River
    {
        public int RiverId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public ICollection<Fish> Fishes { get; set; }
    }
}
