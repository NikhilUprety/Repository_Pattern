using SMS.Models;

namespace SMS.Repository.Interface
{
    public interface IStudentRepository:IRepository<Student>
    {
        void  save();
        void update(Student student);
    }
}
