using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotivationalMortailityWeb.Models
{
    public class MainViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        public DateTime Today { get; set; }
        public int NumberOfWeeks { get; set; }
    }
}