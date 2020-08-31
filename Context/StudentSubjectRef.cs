using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Saliman_Dot_NetDeveloper.Context
{
    [Table("StudentSubjectRef", Schema = "dbo")]
    public class StudentSubjectRef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentSubjectRefID { get; set; }       

         
        [Display(Name = "StudentMaster")]
        public virtual int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual StudentMaster Students { get; set; }



        [Display(Name = "SubjectMaster")]
        public virtual int SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        public virtual SubjectMaster Subjects { get; set; }
       
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Marks { get; set; }
    }
}
