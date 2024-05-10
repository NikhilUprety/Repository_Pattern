using SMS.Data;
using SMS.Models;
using SMS.Repository.Interface;

namespace SMS.Repository.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public AppDbContext _studentDb;
        public StudentRepository(AppDbContext studentDb):base(studentDb) {
            _studentDb = studentDb;
        }

        public void save()
        {

            _studentDb.SaveChanges();
        }

        public void update(Student student)
        {
            _studentDb.Update(student);
        }
    }
}
