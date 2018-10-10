using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ASPCourse.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourse.Controllers
{
    /// <summary>
    /// The Session2Controller controller.
    /// </summary>
    public class Session5Controller : Controller
    {
        #region Properties


        #endregion

        #region Constructors

        #endregion

        #region Methods

        #region Routes

        #region Action types
        /// <summary>
        /// Example of POCO Action
        /// </summary>
        /// <returns></returns>
        public Student GetStudentPOCO()
        {
            var student = new Student()
            {
                Id = 1,
                FullName = "Ahmad ahmad"
            };
            return student;
        }

        /// <summary>
        /// Example of standard IActionResult interface
        /// </summary>
        /// <returns></returns>
        public IActionResult GetStudentIActionResult()
        {
            var student = new Student()
            {
                Id = 1,
                FullName = "Ahmad ahmad"
            };
            /*
             * $ with {} for string interpolation
             */
            return Content($"Student name is {student.FullName}");
        }

        /// <summary>
        /// Example of getting student data 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetStudentDataAsync()
        {
            var student = await Task.Run(() =>
              {
                  Thread.Sleep(5000);//simulate the time to get data from datasource (database, api ...etc)
                  return new Student()
                  {
                      Id = 1,
                      FullName = "Ahmad ahmad"
                  };
              });
            return Content($"Student name is {student.FullName}");
        }
        #endregion

        #region Query strings

        /// <summary>
        /// GET: /Session2/GetBlog?id=2&name=test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult GetBlog(int id, string name)
        {
            return Content($"The id of the blog is: {id}, and the name of the blog is: {name}");
        }

        /// <summary>
        /// Used to get blog by id 
        /// GET: /Session2/GetBlogById/2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetBlogById(int id)
        {
            return Content($"The id of the blog is: {id}");
        }

        /// <summary>
        /// Define custom route map at startup to enable receiving code beside id in route
        /// GET /Session2/GetBooking/2/A582
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public IActionResult GetBooking(int id, string code)
        {
            return Content($"The id of the booking is: {id}, and the code is {code}");
        }

        #endregion

        #endregion

        #region Helpers
        #endregion

        #endregion
    }
}