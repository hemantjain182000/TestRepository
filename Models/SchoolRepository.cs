using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CySchool.Models
{
    public class SchoolRepository : ISchoolRepository
    {
        #region DbContext

        public SchoolContext dbContext = new SchoolContext();

        #endregion

        #region ISchoolRepository Member Implementation

        public IEnumerable<Student> GetAllStudent()
        {
            return dbContext.Students.ToList();
        }

        public void CreateNewStudent(Student employeeToCreate)
        {
            dbContext.Students.Add(employeeToCreate);
            dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var conToDel = GetStudentById(id);
            dbContext.Students.Remove(conToDel);
            dbContext.SaveChanges();
        }

        public List<Student> GetStudentByName(string Search)
        {
            return dbContext.Students.Where(x => x.FirstMidName.StartsWith(Search) || x.LastName.StartsWith(Search)).ToList();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }


        public Student GetStudentById(int id)
        {
            return dbContext.Students.FirstOrDefault(d => d.StudentID == id);

        }

        #endregion
    }
}