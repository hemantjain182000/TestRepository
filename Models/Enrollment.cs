﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CySchool.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        #region Properties

        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        #endregion
    }
}