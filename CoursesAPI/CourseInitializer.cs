using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesAPI
{
    public class CourseInitializer
    {
        private static List<Course> courseCollection = new List<Course>();
        private static int count = 0;
        public static List<Course> createCourses()
        {
            Course course1 = new Course();
            course1.id = getId();
            course1.instructor = new Instructor();
            course1.instructor.firstName = "Salam";
            course1.instructor.lastName = "Farhat";
            course1.title = "Introduction to Web Services";
            course1.crn = "20201";
            courseCollection.Add(course1);
            Course course2 = new Course();
            course2.id = getId();
            course2.instructor = new Instructor();
            course2.instructor.firstName = "Jose";
            course2.instructor.lastName = "Ramos";
            course2.title = "VLSI";
            course2.crn = "20202";
            courseCollection.Add(course2);
            Course course3 = new Course();
            course3.id = getId();
            course3.instructor = new Instructor();
            course3.instructor.firstName = "Junping";
            course3.instructor.lastName = "Sun";
            course3.title = "Intro to Database";
            course3.crn = "20203";
            courseCollection.Add(course3);
            return courseCollection;
        }

        public static int getId()
        {
            return courseCollection.Count + 1;
        }
    }
}