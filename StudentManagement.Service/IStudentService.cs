using StudentManagement.DAL; // Need this for the Student type
using StudentManagement.BLL; // Need this for PagedResult
using System.Collections.Generic;
using System.ServiceModel; // WCF attributes
using System.Runtime.Serialization;

namespace StudentManagement.Service
{
    [ServiceContract]
    public interface IStudentService
    {
        // Note: We use the PagedResult<Student> from BLL.
        // Ensure Student and PagedResult are usable by WCF.
        // EF entities generated with DB First usually have [DataContract]
        // and [DataMember] attributes, making them serializable.
        // We need to explicitly mark PagedResult as a DataContract.

        [OperationContract]
        PagedResult<Student> GetStudents(int pageNumber, int pageSize, string nameFilter, int? minGradeFilter);

        [OperationContract]
        Student GetStudentById(int id);

        [OperationContract]
        void AddStudent(Student student);

        [OperationContract]
        bool UpdateStudent(Student student);

        [OperationContract]
        bool DeleteStudent(int id);
    }

    // Add DataContract/DataMember attributes to PagedResult if it wasn't
    // defined directly in the DAL entities namespace or if needed explicitly.
    // Since we defined it in BLL, let's add them here or in BLL.
    // Adding here for clarity in the Service layer context:
    [DataContract]
    public class PagedResultForWcf<T> // Use a specific name if needed
    {
        [DataMember]
        public List<T> Results { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }
    // *** IMPORTANT ***: For simplicity in this example, we'll try to use the
    // BLL's PagedResult directly. If serialization issues arise, you'd
    // create a separate DTO like PagedResultForWcf and map between them,
    // or add [DataContract]/[DataMember] to the BLL's PagedResult class.
    // Let's try adding attributes to the BLL version:

    // Go back to StudentBusinessService.cs in BLL and add attributes:
    /*
    using System.Runtime.Serialization; // Add this using

    [DataContract] // Add this attribute
    public class PagedResult<T>
    {
        [DataMember] // Add this attribute
        public List<T> Results { get; set; }
        [DataMember] // Add this attribute
        public int TotalCount { get; set; }
    }
    */
    // Rebuild BLL after adding attributes.
}
