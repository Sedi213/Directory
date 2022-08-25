using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directonary.Entity
{
    internal class Location
    {
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}
