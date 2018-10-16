using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCourse.Helpers
{
    public static class FilesHelper
    {
        public static FileResult DownloadFile(Controller controller, string wwwroot, string filePath,
            string fileName, string fileExtension, string contentType)
        {
            IFileProvider provider = new PhysicalFileProvider(wwwroot);
            IFileInfo fileInfo = provider.GetFileInfo(filePath);
            var readStream = fileInfo.CreateReadStream();
            return controller.File(readStream, contentType, $"{fileName}{fileExtension}");
        }

    }
}
