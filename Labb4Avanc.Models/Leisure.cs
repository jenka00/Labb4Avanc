using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Labb4Avanc.Models
{
    public class Leisure
    {
        [Key]
        public int LeisureId { get; set; }
      
        public string Url { get; set; }
        
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
