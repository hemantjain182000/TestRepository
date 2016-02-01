using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CySchool.Models
{
    public class Student
    {
        #region Properties

        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        [StringLength(50, MinimumLength = 1)]
        [Display]
        public string FirstMidName { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        #endregion
    }
}