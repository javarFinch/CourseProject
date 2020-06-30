using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesAPI
{
    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public string crn { get; set; }
        public  Instructor instructor { get; set; }
    }
}