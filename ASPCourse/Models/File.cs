using System;
using System.Collections.Generic;
using System.Text;

namespace ASPCourse.Models
{
    /// <summary>
    /// The File class.
    /// </summary>
    public class File
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public string CoverUrl { get; set; }
        public string FileUrl { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}