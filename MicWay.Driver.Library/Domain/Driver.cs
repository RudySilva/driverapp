using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MicWay.Driver.Library.Models
{
    [Table("Driver")]
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "'FirstName' cannot be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "'LastName' cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "'E-mail' cannot be longer than 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Date of Birthday is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
<<<<<<< HEAD
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
=======
>>>>>>> 1018125f4e997d39e4bf3a495816a6e9f9ba813c
        [Display(Name = "Date of Birthday")]
        public DateTime Dob { get; set; }


    }
}