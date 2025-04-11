using StudentManagement.BLL;
using StudentManagement.DAL; // For Student type
using System.Collections.Generic;

namespace StudentManagement.Service
{
    // NOTE: By default, WCF services can be per-call, per-session, or singleton.
    // Per-call is often the default and simplest for stateless operations.
    // If PerCall, a new StudentBusinessService (and thus DbContext) is created for each call.
    // This is generally safer than holding a DbContext open for long periods.
    // [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StudentService : IStudentService
    {
        // GetStudents now returns the BLL's PagedResult<Student>
        public PagedResult<Student> GetStudents(int pageNumber, int pageSize, string nameFilter, int? minGradeFilter)
        {
            using (var bll = new StudentBusinessService())
            {
                // Directly return the result from BLL
                return bll.GetStudents(pageNumber, pageSize, nameFilter, minGradeFilter);
            }
        }

        public Student GetStudentById(int id)
        {
            using (var bll = new StudentBusinessService())
            {
                return bll.GetStudentById(id);
            }
        }

        public void AddStudent(Student student)
        {
            using (var bll = new StudentBusinessService())
            {
                bll.AddStudent(student);
            }
        }

        public bool UpdateStudent(Student student)
        {
            using (var bll = new StudentBusinessService())
            {
                return bll.UpdateStudent(student);
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var bll = new StudentBusinessService())
            {
                return bll.DeleteStudent(id);
            }
        }
    }
}
