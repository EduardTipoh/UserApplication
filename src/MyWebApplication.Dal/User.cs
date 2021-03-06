﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Dal
{
    public class User
    {
        public User()
        {
            Edu = new List<Educations>();
        }
        [Key]
        public int Id { get;set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public ICollection<Educations> Edu { get; set; }
    }
}
