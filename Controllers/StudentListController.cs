using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Saliman_Dot_NetDeveloper.Context;
using Saliman_Dot_NetDeveloper.Repository.Contract;
using Saliman_Dot_NetDeveloper.ViewModel;

namespace Saliman_Dot_NetDeveloper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentListController : ControllerBase
    {
        private readonly IStudentRepository<StudentMaster> _StudentRepository;

        public StudentListController(IStudentRepository<StudentMaster> libraryRepository)
        {
            _StudentRepository = libraryRepository;
        }
        
        [HttpGet]
        [Route("GetAllStudent")]
        public IActionResult GetAllStudent(int stid,int classid,int subid)
        {
            IEnumerable<StudentlistingModel> students = _StudentRepository.GetAllStudent(stid,classid,subid);
            return Ok(JsonSerializer.Serialize(students));

        }
        [HttpGet]
        [Route("GetAllClass")]
        public IActionResult GetAllClass()
        {
            IEnumerable<ClassMaster> students = _StudentRepository.GetAllClass();
            return Ok(JsonSerializer.Serialize(students));
        }

        [HttpGet]
        [Route("GetAllSubject")]
        public IActionResult GetAllSubject()
        {
            IEnumerable<SubjectMaster> students = _StudentRepository.GetAllSubject();
            return Ok(students);
        }
        [HttpPost]
        [Route("GetallSubjectofStudent")]
        public IActionResult GetallSubjectofStudent(StudentMaster studentid)
        {
            IEnumerable<StudentSubjectRef> students = _StudentRepository.GetallSubjectofStudent(studentid.StudentID);
            return Ok(students);
        }

        [HttpGet]
        [Route("GetallSubjectofStudent1")]
        public IActionResult GetallSubjectofStudent1(int studentid)
        {
            IEnumerable<StudentSubjectRef> students = _StudentRepository.GetallSubjectofStudent(studentid);
            return Ok(students);
        }

        [HttpGet]
        [Route("GetallstudentList")]
        public IActionResult GetallstudentList()
        {
            IEnumerable<StudentListingwithSubj> students = _StudentRepository.GetallstudentList();
            return Ok(students);
        }
        [HttpGet]
        [Route("GetallstudentListfilter")]
        public IActionResult GetallstudentListfilter(int classid, int subid)
        {
            IEnumerable<StudentListingwithSubj> students = _StudentRepository.GetallstudentListfilter(classid,subid);
            return Ok(students);
        }
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(StudentMaster student)
        {
            int res = _StudentRepository.AddStudent(student);
            return Ok(res);
        }
        [HttpPost]
        [Route("AddStudentsubj")]
        public IActionResult AddStudentsubj(StudentSubjectRef subj)
        {
            int res = _StudentRepository.AddStudentsubj(subj);
            return Ok(res);
        }
        [HttpPut]
        [Route("RemoveStudent")]
        public IActionResult RemoveStudent(StudentMaster student)
        {
            string res = _StudentRepository.RemoveStudent(student);
            return Ok(res);
        }
        [HttpPut]
        [Route("delstdsubjcet")]
        public IActionResult delstdsubjcet(StudentMaster student)
        {
            string res = _StudentRepository.delstdsubjcet(student);
            return Ok(res);
        }
        [HttpPost]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(StudentMaster student)
        {
            string res = _StudentRepository.UpdateStudent(student);
            return Ok(res);
        }


    }
}
