using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saliman_Dot_NetDeveloper.Context
{
    [Table("ClassMaster", Schema = "dbo")]
    public class ClassMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

       

    }
}
