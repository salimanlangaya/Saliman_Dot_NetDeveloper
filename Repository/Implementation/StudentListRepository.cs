using Saliman_Dot_NetDeveloper.Context;
using Saliman_Dot_NetDeveloper.Repository.Contract;
using Saliman_Dot_NetDeveloper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Saliman_Dot_NetDeveloper.Repository.Implementation
{
    public class StudentListRepository : IStudentRepository<StudentMaster>
    {
        readonly StudentAppDbContext _studentContext;

        public StudentListRepository(StudentAppDbContext context)
        {
            _studentContext = context;
        }


        public IEnumerable<ClassMaster> GetAllClass()
        {
            return _studentContext.ClassMasters.ToList();
        }
        public IEnumerable<SubjectMaster> GetAllSubject()
        {
            return _studentContext.SubjectMasters.ToList();
        }
        public IEnumerable<StudentlistingModel> GetAllStudent(int studentid, int classid, int subjectid)
        {
            if (_studentContext != null)
            {
                return (from stdnt in _studentContext.StudentMasters
                        join clsmaster in _studentContext.ClassMasters on stdnt.ClassID equals clsmaster.ClassID
                        join subref in _studentContext.StudentSubjectRefs on stdnt.StudentID equals subref.StudentID
                        join submas in _studentContext.SubjectMasters on subref.SubjectID equals submas.SubjectID
                        where (stdnt.StudentID==studentid || studentid==0) &&
                        (stdnt.ClassID == classid || classid == 0) &&
                        (subref.SubjectID == subjectid || subjectid == 0)

                        select new StudentlistingModel
                             {
                                 StudentID = stdnt.StudentID,
                                 FirstName = stdnt.FirstName,
                                 LastName = stdnt.LastName,
                                 ClassName = clsmaster.ClassName,
                                 Marks = subref.Marks,
                                 SubjectID = subref.SubjectID,
                                 SubjectName=submas.SubjectName
                             }).ToList();
            }

            return null;
        }

        public IEnumerable<StudentSubjectRef> GetallSubjectofStudent(int studentid)
        {
            return _studentContext.StudentSubjectRefs.Where(x=>x.StudentID==studentid).ToList();
        }
        public IEnumerable<StudentListingwithSubj> GetallstudentListfilter(int classid,int subid)
        {
            List<StudentListingwithSubj> students = new List<StudentListingwithSubj>();
            if (_studentContext != null)
            {

                var cust = (from stdnt in _studentContext.StudentMasters
                            join clsmaster in _studentContext.ClassMasters on stdnt.ClassID equals clsmaster.ClassID
                            where                             (stdnt.ClassID == classid || classid == 0)

                            select new studentclassV
                            {
                                StudentID = stdnt.StudentID,
                                FirstName = stdnt.FirstName,
                                LastName = stdnt.LastName,
                                ClassName = clsmaster.ClassName,
                                ClassID = clsmaster.ClassID

                            }).ToList();
                foreach (var i in cust)
                {
                    var subjectlist = (from stdsub in _studentContext.StudentSubjectRefs
                                       join submas in _studentContext.SubjectMasters on stdsub.SubjectID equals submas.SubjectID
                                       where stdsub.StudentID==i.StudentID
                                       select new subjectref
                                       {
                                           StudentID = stdsub.StudentID,
                                           Marks = stdsub.Marks,
                                           SubjectID = stdsub.SubjectID,
                                           SubjectName = submas.SubjectName,

                                       }
                                       ).ToList();
                    //_studentContext.StudentSubjectRefs.Where(a => a.StudentID == i.StudentID).OrderBy(a => a.SubjectID).ToList();

                    students.Add(new StudentListingwithSubj
                    {
                        student = i,
                        subjectlist = subjectlist
                    });
                }
            }
            return students;
        }
        public IEnumerable<StudentListingwithSubj> GetallstudentList()
        {
            List<StudentListingwithSubj> students = new List<StudentListingwithSubj>();
            if (_studentContext != null)
            {

                var cust = (from stdnt in _studentContext.StudentMasters
                           join clsmaster in _studentContext.ClassMasters on stdnt.ClassID equals clsmaster.ClassID
                           orderby stdnt.FirstName,stdnt.LastName
                           //where (stdnt.StudentID == studentid || studentid == 0) &&
                           //(stdnt.ClassID == classid || classid == 0) 

                           select new studentclassV
                           {
                               StudentID = stdnt.StudentID,
                               FirstName = stdnt.FirstName,
                               LastName = stdnt.LastName,
                               ClassName = clsmaster.ClassName,
                               ClassID=clsmaster.ClassID
                              
                           }).ToList(); 
                foreach (var i in cust)
                {
                    var subjectlist = (from stdsub in _studentContext.StudentSubjectRefs
                                       join submas in _studentContext.SubjectMasters on stdsub.SubjectID equals submas.SubjectID
                                       where stdsub.StudentID == i.StudentID
                                       select new subjectref
                                       {
                                           StudentID = stdsub.StudentID,
                                           Marks = stdsub.Marks,
                                           SubjectID = stdsub.SubjectID,
                                           SubjectName = submas.SubjectName,

                                       }
                                       ).ToList();
                        //_studentContext.StudentSubjectRefs.Where(a => a.StudentID == i.StudentID).OrderBy(a => a.SubjectID).ToList();
                    
                     students.Add(new StudentListingwithSubj
                    {
                        student = i,
                        subjectlist = subjectlist
                    });
                }
            }
            return students;
        }
        public int AddStudent(StudentMaster student)
        {
            if (_studentContext != null)
            {
                _studentContext.StudentMasters.Add(student);
                _studentContext.SaveChanges();
                return student.StudentID;

            }
           else return 0;
        }
        public int AddStudentsubj(StudentSubjectRef subj)
        {
            if (_studentContext != null)
            {
                _studentContext.StudentSubjectRefs.Add(subj);
                _studentContext.SaveChanges();
            }
            return 0;
        }
        public string delstdsubjcet(StudentMaster student)

        {
            string result = "Student does not exists or some error has occure";

            if (_studentContext != null)
            {
                //Find the post for specific post id
                var subjectrefstdremv = _studentContext.StudentSubjectRefs.Where(x => x.StudentID == student.StudentID);
                if (subjectrefstdremv != null)
                {
                    _studentContext.StudentSubjectRefs.RemoveRange(subjectrefstdremv);
                  
                    _studentContext.SaveChanges();
                    result = "Data deleted";
                }
                else
                {
                    result = "Student does not exists or some error has occure";
                }
                return result;
            }

            return result;

        }
        public string RemoveStudent(StudentMaster student)
        {
            string result = "Student does not exists or some error has occure";

            if (_studentContext != null)
            {
                //Find the post for specific post id
                var studentremv = _studentContext.StudentMasters.FirstOrDefault(x => x.StudentID == student.StudentID);
                var subjectrefstdremv = _studentContext.StudentSubjectRefs.Where(x => x.StudentID == student.StudentID);
                if (studentremv != null)
                {
                    //Delete the all subject relate to this id
                    _studentContext.StudentSubjectRefs.RemoveRange(subjectrefstdremv);
                    //delete student
                    _studentContext.StudentMasters.Remove(studentremv);
                    _studentContext.SaveChanges();
                    result = "Data deleted";
                }
                else
                {
                     result = "Student does not exists or some error has occure";
                }
                return result;
            }

            return result;

        }
        public string UpdateStudent(StudentMaster student)
        {
            if (_studentContext != null)
            {
                StudentMaster std = _studentContext.StudentMasters.Where(x => x.StudentID == student.StudentID).FirstOrDefault();
                std.FirstName = student.FirstName;
                std.LastName = student.LastName;
                std.ClassID = student.ClassID;
                _studentContext.SaveChanges();
                return "Student Updated Successfully";
            }
            else
                return "Student not Updated Successfully";
        }
    }
}
