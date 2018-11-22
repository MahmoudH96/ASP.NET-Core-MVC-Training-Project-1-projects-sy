using System;

namespace ChefBox.Logging.Dto.Errors
{
    public class HttpErrorDto
    {
        public string Source { get; set; }
        public Exception Exception { get; set; }
    }
}
