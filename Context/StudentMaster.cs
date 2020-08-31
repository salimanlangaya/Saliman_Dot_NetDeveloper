using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saliman_Dot_NetDeveloper.Context
{
    [Table("StudentMaster", Schema = "dbo")]
    public class StudentMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        // Foreign key   
        [Display(Name = "ClassMaster")]
        public virtual int ClassID { get; set; }

        [ForeignKey("ClassID")]
        public virtual ClassMaster Classes { get; set; }

       
    }
}
