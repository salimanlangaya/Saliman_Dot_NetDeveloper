using Saliman_Dot_NetDeveloper.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saliman_Dot_NetDeveloper.ViewModel
{
    public class StudentListingwithSubj
    {
        public studentclassV student { get; set; }
        public List<subjectref> subjectlist { get; set; }
    }
}
