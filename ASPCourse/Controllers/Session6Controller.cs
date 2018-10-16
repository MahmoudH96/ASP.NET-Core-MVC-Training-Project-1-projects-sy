using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPCourse.Controllers
{
    /// <summary>
    /// The Session6Controller class.
    /// </summary>
    public class Session6Controller : Controller
    {
        #region Properties

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #region Route parameters
        public IActionResult GetBook(int id, string code)
        {
            return Content($"Id :{id}, Name: {code}");
        }

        public IActionResult GetWeather(int year, int month, int day)
        {
            return Content($"The weahter on {year}/{month}/{day} is sunny");
        }
        #endregion

        #endregion
    }
}