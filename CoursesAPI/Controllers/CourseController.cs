using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CoursesAPI.Controllers
{
    [RoutePrefix("courses")]
    public class CourseController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetCourses()
        
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            return Ok(courses);
        }

        [HttpGet, Route("{id}")]
        public Course GetCourse(int id)
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            foreach (var course in courses)
            {
                if (course.id == id)
                {
                    return course;
                }
            }
            return null;
        }

        [HttpDelete, Route("{id}")]
        public string Delete(int id)
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            foreach (var course in courses)
            {
                if (course.id == id)
                {
                    courses.Remove(course);
                    return "course with id " + id + " has been removed.";
                }
            }
            return "No course found with id " + id + ".";
        }

        [HttpPatch,Route("{courseId}")]
        public Course Update(int courseId)
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            foreach (var course in courses)
            {
                if (course.id == courseId)
                {
                    course.title = "New Title";
                    return course;
                }
            }
            return null;
        }


        [HttpPost, Route("")]
        public Course CreateCourse(Course newCourse)
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            newCourse.id = CourseInitializer.getId();
            courses.Add(newCourse);
            return newCourse;
        }

        [HttpPut, Route("")]
        public Course Update(Course course)
        {
            var courses = (List<Course>)HttpContext.Current.Cache["courses"];
            foreach (var c in courses)
            {
                if (c.id == course.id)
                {
                    c.title = course.title;
                    c.crn = course.crn;
                    c.instructor.firstName = course.instructor.firstName;
                    c.instructor.lastName = course.instructor.lastName;
                    return c;
                }
            }
            return null;
        }
    }
}
