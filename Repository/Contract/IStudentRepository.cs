using Saliman_Dot_NetDeveloper.Context;
using Saliman_Dot_NetDeveloper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saliman_Dot_NetDeveloper.Repository.Contract
{
    public interface IStudentRepository<T>
    {
        public IEnumerable<ClassMaster> GetAllClass();
        public IEnumerable<SubjectMaster> GetAllSubject();
        public IEnumerable<StudentlistingModel> GetAllStudent(int studentid, int classid, int subjectid);
        public IEnumerable<StudentSubjectRef> GetallSubjectofStudent(int studentid);
        public IEnumerable<StudentListingwithSubj> GetallstudentList();
        public IEnumerable<StudentListingwithSubj> GetallstudentListfilter(int classid, int subid);
        public int AddStudent(StudentMaster student);
        int AddStudentsubj(StudentSubjectRef subj);
        public string RemoveStudent(StudentMaster studentid);
        public string delstdsubjcet(StudentMaster studentid);
        public string UpdateStudent(StudentMaster student);


    }
}
