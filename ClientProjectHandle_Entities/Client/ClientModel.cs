using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Entities.Client
{
    public class ClientModel
    {
        [Key]
        public int ClientID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BusinessAddress { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
    }

    public class ClientSubmissionModel 
    {
        [Key]
        public int SubmissionID { get; set; }
        public int ClientID { get; set; }
        public string? ProjectSynopsis { get; set; }
        public string? AreasOfSpecialization { get; set; }
        public DateTime SubmissionDate { get; set; }
    }


    public class ClientSubmissionViewModel
    {
        [Required(ErrorMessage ="Kindly Enter First Name!")]
        [Display(Name = "First Name")]
        public string? ClientFirstName { get; set; }

        [Required(ErrorMessage ="Kindly Enter Last Name!")]
        [Display(Name ="Last Name")]
        public string? ClientLastName { get; set; }

        [Required(ErrorMessage ="Kindly Enter E-Mail!")]
        [Display(Name ="E-Mail")]
        [EmailAddress]
        public string? ClientEmail { get; set; }

        [Required(ErrorMessage ="Kindly Enter Phone Number!")]
        [Display(Name ="Phone Number")]
        [Phone]
        public string? ClientPhoneNumber { get; set; }

        [Display(Name ="Business Address")]
        public string? ClientBusinessAddress { get; set; } = string.Empty;

        [Required(ErrorMessage ="Kindly Enter Project Overview!")]
        [Display(Name ="Overview of Project")]
        public string? ClientProjectOverview { get; set; }

        [Required(ErrorMessage = "Kindly Enter Type Of Project")]
        [Display(Name = "Type of Project")]
        public string? ClientProjectType { get; set; }
    }
    
}
