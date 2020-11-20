using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;

namespace MIS4200Team3.Models
{
    public class Profile
    {
        [Required]
        [Key] public Guid ID { get; set; }



        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Employee first name is required")]
        [StringLength(20)]
        public string firstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Employee last name is required")]
        [StringLength(30)]
        public string lastName { get; set; }

        [Display(Name = "Employee Name")]
        public string fullName { get
            { return firstName + " " + lastName; }
        }

        [Display(Name = "Centirc Consulting Email")]
        //[Required(ErrorMessage = "Employee email is required")]
        [StringLength(50)]
        public string CentricEmail { get; set; }



        [Display(Name = "Mobile Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone number must be in the format (xxx) xxx-xxx")]
        public string PhoneNumber { get; set; }



        [Display(Name = "Office Location")]
        [Required(ErrorMessage = "Office locatoin is required")]
        //[StringLength(50)]
        public officeLocations officeLocation { get; set; }



        //[Display(Name = "Department")]
        //[Required(ErrorMessage = "Department is required")]
        //[StringLength(50)]
        //public string departemnt { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "Employee title is required")]
        //[StringLength(50)]
        public titles title { get; set; }



        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }

        public enum officeLocations
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            India,
            Indianapolis,
            Louisville,
            Miamai,
            Seattle,
            Tampa
        }

        public enum titles
        {
            Consultant,
            Senior_Consultant,
            Manager,
            Architect,
            Senior_Manager,
            Senior_Architect,
            Director,
            Vice_President,
            President,
            COO,
            CEO

        }
       

        [ForeignKey("receiveID")]
        public ICollection<Refer> refers { get; set; }

       [ForeignKey("refersGivenID")]
        public ICollection<Refer> refersGiven { get; set; }
     

    }


}

