using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CySchool.Models
{
    public interface ISchoolRepository
    {
        #region Repository memnber Function

        IEnumerable<Student> GetAllStudent();
        void CreateNewStudent(Student StudentToCreate);
        void DeleteStudent(int id);
        List<Student> GetStudentByName(string Search);
        int SaveChanges();
        Student GetStudentById(int id);

        #endregion

    }
}