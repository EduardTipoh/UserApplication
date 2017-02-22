using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Dal
{
    [Table("Educations")]
    public class Educations
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public string School { get; set; }
        public string YearAttended { get; set; }

        public User Users { get; set; }
    }
}
