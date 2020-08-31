using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Saliman_Dot_NetDeveloper.Context
{
    [Table("SubjectMaster", Schema = "dbo")]
    public class SubjectMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
       
    }
}
