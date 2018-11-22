using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Logging.Dto.Errors
{
    public class DomainErrorDto
    {
        public string RepositoryName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
