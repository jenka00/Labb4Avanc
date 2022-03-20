using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labb4Avanc.Models
{
    public class Leisure
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int InterestId { get; set; }

        public Interest Interest { get; set; }

        public List<string> LinkList { get; set; }
    }
}
