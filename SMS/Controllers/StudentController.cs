using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Models;
using SMS.Repository.Interface;
using SMS.ViewModel;
using System.Collections.Specialized;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        public IStudentRepository _studentRepo;
        public INotyfService _notification { get; }

        public StudentController(IStudentRepository studentRepo, INotyfService notification)
        {
            _studentRepo=studentRepo;
            _notification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var student = _studentRepo.GetAll();
            return View(student);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentVM vm) 
        {
            if (!ModelState.IsValid) {

             _notification.Error("not valid error");            
            return View(vm);    
            }
            var studentvm=new Student()
            {
                RollNo = vm.RollNo,
                Name = vm.Name,
                Sex = vm.Sex,
                Address = vm.Address,
                Grade = vm.Grade,
                Faculty = vm.Faculty,
            };
            _studentRepo.Add(studentvm);
            _studentRepo.save();
            _notification.Success("successfully added");
            return RedirectToAction("Students");
        }

        public IActionResult Delete(int id)
        {
            var user=_studentRepo.FindById(id);
            _studentRepo.Remove(user);
            _studentRepo.save();
            _notification.Error("user deleted");
            return RedirectToAction("Students");
        }

        [HttpGet]
        public IActionResult Update(int id )
        {
           var user= _studentRepo.Get( x=>x.Id==id);
            if (user != null)
            {
                var student = new UpdateVM()
                {
                    Name = user.Name,
                    RollNo = user.RollNo,
                    Sex = user.Sex,
                    Address = user.Address,
                    Grade = user.Grade,
                    Faculty = user.Faculty,
                };
                return View(student);
            }

           return RedirectToAction("Students");
        }

        [HttpPost]
        public IActionResult Update(UpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);

            }
            var student = _studentRepo.FindById(vm.Id);  
            if(student != null)
            {


                student.Name = vm.Name;
                student.Sex = vm.Sex;
                student.Address = vm.Address;
                student.RollNo = vm.RollNo;
                student.Grade = vm.Grade;
                student.Faculty = vm.Faculty;
                student.Faculty = vm.Faculty;
            

            _studentRepo.save();
               _notification.Success("updated successfully");
            return RedirectToAction("Students");
            }
            else
            {
                return View(vm); }
        }


    }
}
