using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4Avanc.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        public string InterestTitle { get; set; }

        public string InterestDescription { get; set; }

        public virtual ICollection<Leisure> Leisure { get; set; }
    }
}
