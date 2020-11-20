using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MIS4200Team3.Controllers;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS4200Team3.Models
{
    public class Refer
    {
        [Key]

        public int referenceID { get; set; }

        //[Display(Name = "Centric Core Value")]
        //[Required(ErrorMessage = "Core value is required")]
        public Guid? ID { get; set; }

        [Display (Name ="Employee Name")]
        public Guid receiveID { get; set; }
        //all we need is the ID
        //[Display(Name = "First Name")]
        //[Required(ErrorMessage = "Your first name is required")]
        //[StringLength(20)]
        //public string firstName { get; set; }


        //[Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Your last name is required")]
        //[StringLength(20)]
        //public string lastName { get; set; }


        //[Display(Name = "Employee First Name")]
        //[Required(ErrorMessage = "Employee first name is required")]
        //[StringLength(20)]
        //public string employeeFirstName { get; set; }


        //[Display(Name = "Employee Last Name")]
        //[Required(ErrorMessage = "Employee last name is required")]
        //[StringLength(20)]
        //public string employeeLastName { get; set; }


        public virtual Profile profile { get; set; }

        [ForeignKey("receiveID")] 
        public virtual Profile receive { get; set; }
        


        //public ICollection<Profile> Profile { get; set; }
        //public string employeeFullName
        //{

        //    get
        //    {
        //        return employeeFirstName + employeeLastName;
        //    }
        //}

        //[Display(Name = "Department")]
        //[Required(ErrorMessage = "Employee deprtment is required")]
        //[StringLength(50)]
        //public string department { get; set; }


        [Display(Name = "Centric Core Value")]
        [Required(ErrorMessage = "Core value is required")]
        //[StringLength(50)]
        public CompanyValues CompanyValue { get; set; }


        public enum CompanyValues
        {
            Delivery_Excellence, 
            Integrity_and_Openness,
            Stewardship,
            Exceptional_Culture,
            Passion,
            Innovate,
            Balanced_Life
        }
    }

    //internal class DisplayNameAttribute : Attribute
    //{
    //}
}