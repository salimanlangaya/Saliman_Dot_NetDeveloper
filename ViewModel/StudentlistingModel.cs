using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saliman_Dot_NetDeveloper.ViewModel
{
    public class StudentlistingModel
    {
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }
        public  int SubjectID { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
        public decimal Marks { get; set; }
    }
}
