using System;
using System.Collections.Generic;
using System.Text;
using ASPCourse.Helpers;
using ASPCourse.Models;
using ASPCourse.ViewModels.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ASPCourse.Controllers
{
    /// <summary>
    /// The FileController controller.
    /// </summary>
    public class FileController : Controller
    {
        #region Properties
        public static List<File> BooksFiles { get; set; } = new List<File>()
        {
            new File()
            {
                Id=1,
                Name="The tale of two cities",
                ContentType="application/pdf",
                Description="A Tale of Two Cities (1859) is a historical novel by Charles Dickens, set in London and Paris before and during the French Revolution. The novel tells the story of the French Doctor Manette, his 18-year-long imprisonment in the Bastille in Paris and his release to live in London with his daughter Lucie, whom he had never met; Lucie's marriage and the collision between her husband and the people who caused her father's imprisonment; and Monsieur and Madame Defarge, sellers of wine in a poor suburb of Paris. The story is set against the conditions that led up to the French Revolution and the Reign of Terror.",
                CoverUrl="/data/booksImages/book1.jpg",
                Extension=".pdf",
                FileUrl="/data/booksFiles/sample.pdf"
            },
            new File()
            {
                Id=2,
                Name="Zorba the Greek",
                ContentType="application/pdf",
                Description="Zorba the Greek Zorba book.jpg First edition Author Nikos Kazantzakis Original title Βίος και Πολιτεία του Αλέξη Ζορμπά (Life and Times of Alexis Zorbas) Country Greece Language Greek Published 1946 (Greek) OCLC 35223018 Dewey Decimal 889/.332 20 LC Class PA5610.K39 V5613 1996 Zorba the Greek (Greek: Βίος και Πολιτεία του Αλέξη Ζορμπά, Víos kai Politeía tou Aléxē Zorbá, Life and Times of Alexis Zorbas) is a novel written by the Cretan author Nikos Kazantzakis, first published in 1946. It is the tale of a young Greek intellectual who ventures to escape his bookish life with the aid of the boisterous and mysterious Alexis Zorba. The novel was adapted into a successful 1964 film of the same name by Michael Cacoyannis as well as a 1968 musical, Zorba.",
                CoverUrl="/data/booksImages/book2.jpg",
                Extension=".pdf",
                FileUrl="/data/booksFiles/sample.pdf"
            }
        };

        public IHostingEnvironment HostingEnvironment { get; }
        #endregion

        #region Constructors
        public FileController(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Methods

        #region Routes

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Files = BooksFiles
            };
            return View(viewModel);
        }

        public IActionResult ViewFile(int id)
        {
            var file = SearchForFile(id);
            if (file == null)
            {
                return NotFound();
            }
            return View(file);
        }

        public IActionResult DownloadFile(int id)
        {
            var file = SearchForFile(id);
            if (file == null)
            {
                return NotFound();
            }
            return FilesHelper.DownloadFile(this, HostingEnvironment.WebRootPath,
                file.FileUrl, file.Name, file.Extension, file.ContentType);
        }

        private File SearchForFile(int id)
        {
            File fileEntity = null;
            foreach (var file in BooksFiles)
            {
                if (file.Id == id)
                {
                    fileEntity = file;
                    break;
                }
            }
            return fileEntity;
        }

        #endregion

        #region Helpers
        #endregion

        #endregion
    }
}