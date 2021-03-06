﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebApplication.Areas.Security.Models
{
    public class UserModelView
    {
        public int Id { get; set; }
        [Required (ErrorMessage="This is a required field")]
        [MinLength(8, ErrorMessage="Minimum of 8 characters")]
        [MaxLength(20, ErrorMessage = "Maximum of 20 characters")]
         [Display(Name="Your name")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage="Minimum of 3 Letters")]
        [MaxLength(15, ErrorMessage="Maximum of 10 Letters Only")]
        [Display(Name="Your Last Name")]
       public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string School { get; set; }
        public string YearAttended { get; set; }

        public IList<string> Schools { get; set; }
        public IList<string> YeatAttend { get; set; }
    }
}