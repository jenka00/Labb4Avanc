using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb4Avanc.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Url { get; set; }

        public ICollection<Interest> Interest { get; set; }
    }
}
