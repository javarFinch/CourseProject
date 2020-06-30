using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CoursesAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static List<Course> courses;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            courses = CourseInitializer.createCourses();
            HttpContext.Current.Cache["courses"] = courses;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, DELETE, OPTIONS, PUT");
                Response.AddHeader("Access-Control-Allow-Headers", "*");
                Response.End();
            }
        }
    }
}