using Microsoft.AspNetCore.Mvc;
using SMS.Data;
using SMS.Models;
using SMS.ViewModel;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var student = _context.StudentsTable.ToList();
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
            _context.StudentsTable.Add(studentvm);
            _context.SaveChanges();
            return RedirectToAction("Students");
        }

        public IActionResult Delete(int id)
        {
            var user=_context.StudentsTable.Find(id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Students");
        }

        [HttpGet]
        public IActionResult Update(int id )
        {
           var user= _context.StudentsTable.FirstOrDefault( x=>x.Id==id);
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
            var student = _context.StudentsTable.Find(vm.Id);  
            if(student != null)
            {


                student.Name = vm.Name;
                student.Sex = vm.Sex;
                student.Address = vm.Address;
                student.RollNo = vm.RollNo;
                student.Grade = vm.Grade;
                student.Faculty = vm.Faculty;
                student.Faculty = vm.Faculty;
            

            _context.SaveChanges();
            return RedirectToAction("Students");
            }
            else
            { return View(vm); }
        }


    }
}
