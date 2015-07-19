using MotivationalMortality;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotivationalMortailityWeb.Models
{
    public class RequestProfileViewModel
    {
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        [Range(1,2)]
        public GenderType? Gender { get; set; }
    }

    public class ViewProfileViewModel : RequestProfileViewModel
    {
        public ViewProfileViewModel()
        {
            this.Name = "";
            this.CountryName = "";
            this.Gender = null;
        }
        
        public ViewProfileViewModel(RequestProfileViewModel view)
        {
            this.Name = view.Name;
            this.CountryName = view.CountryName;
            this.Gender = view.Gender;
        }

        public string Messsage { get; set; }
        public string LifeExpectancyGraph { get; set; }
    }
}