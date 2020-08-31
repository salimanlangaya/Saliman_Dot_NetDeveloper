using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Saliman_Dot_NetDeveloper.Context;
using Saliman_Dot_NetDeveloper.Repository.Contract;
using Saliman_Dot_NetDeveloper.ViewModel;

namespace Saliman_Dot_NetDeveloper.Controllers
{
    public class StudentFrontController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Student Listing";
            return View();
        }

        private readonly IStudentRepository<StudentMaster> _StudentRepository;

        public StudentFrontController(IStudentRepository<StudentMaster> libraryRepository)
        {
            _StudentRepository = libraryRepository;
        }
        


        public JsonResult Get_All_studsubject(StudentMaster id)
        {
            IEnumerable<StudentSubjectRef> students = _StudentRepository.GetallSubjectofStudent(id.StudentID);
            return Json(students);

        }
        public JsonResult GetallstudentListfilter(StudentMaster id)
        {
            IEnumerable<StudentListingwithSubj> students = _StudentRepository.GetallstudentListfilter(0, 0);
            return Json(students);

        }

       

        public JsonResult UpdateStudent(StudentMaster student)
        {
            var res = _StudentRepository.UpdateStudent(student);
            return Json(res);
        }
    }
}
