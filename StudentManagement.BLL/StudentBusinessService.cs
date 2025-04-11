using System.Runtime.Serialization;
using StudentManagement.DAL; // Access EF context and entities
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity; // Required for Include, FindAsync etc. (optional for basic ops)

namespace StudentManagement.BLL
{
    // Define a class to hold paged results
    public class PagedResult<T>
    {
        public List<T> Results { get; set; }
        public int TotalCount { get; set; }
    }

    public class StudentBusinessService : IDisposable
    {
        // Instance of the EF Database Context
        // Note: In a real-world app, use Dependency Injection here!
        private readonly StudentManagementDBEntities _context;

        public StudentBusinessService()
        {
            _context = new StudentManagementDBEntities();
        }

        // Method to get students with filtering and pagination
        public PagedResult<Student> GetStudents(
            int pageNumber,
            int pageSize,
            string nameFilter = null,
            int? minGradeFilter = null)
        {
            // Start with the base query
            IQueryable<Student> query = _context.Students;

            // Apply filters
            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                query = query.Where(s => s.FirstName.Contains(nameFilter) ||
                                         s.LastName.Contains(nameFilter));
            }

            if (minGradeFilter.HasValue)
            {
                query = query.Where(s => s.Grade >= minGradeFilter.Value);
            }

            // Get total count before pagination (for UI)
            int totalCount = query.Count();

            // Apply sorting (important for consistent pagination)
            query = query.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);

            // Apply pagination
            var students = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList(); // Execute the query

            return new PagedResult<Student>
            {
                Results = students,
                TotalCount = totalCount
            };
        }

        // Get a single student by ID
        public Student GetStudentById(int id)
        {
            // Find returns null if not found
            return _context.Students.Find(id);
        }

        // Add a new student
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            // Basic validation (more can be added)
            if (string.IsNullOrWhiteSpace(student.FirstName) ||
                string.IsNullOrWhiteSpace(student.LastName))
            {
                throw new ArgumentException("First and Last names are required.");
            }

            _context.Students.Add(student);
            _context.SaveChanges(); // Persist changes to DB
        }

        // Update an existing student
        public bool UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            // Find the existing student in the context or attach and change state
            var existingStudent = _context.Students.Find(student.Id);
            if (existingStudent != null)
            {
                // Update properties
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                _context.SaveChanges(); // Persist changes
                return true; // Indicate success
            }
            return false; // Indicate student not found
        }

        // Delete a student by ID
        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges(); // Persist changes
                return true; // Indicate success
            }
            return false; // Indicate student not found
        }

        // Implement IDisposable to release the context
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
