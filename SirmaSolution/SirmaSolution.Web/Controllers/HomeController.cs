namespace SirmaSolution.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SirmaSolution.Data;
    using SirmaSolution.Data.ViewModels;
    using SirmaSolution.Service;
    using SirmaSolution.Web.Extentions;
    using SirmaSolution.Web.Models;

    public class HomeController : Controller
    {
        public HomeController(IEmployeeProjectService employeeProjectService) => this.EmployeeProjectService = employeeProjectService;

        public IEmployeeProjectService EmployeeProjectService { get; }

        public IActionResult Index(List<HomeViewModel> homeViewModels)
        {
            return View(homeViewModels);
        }

        [HttpPost("UploadFiles")]
        public IActionResult Index(IFormFile file)
        {
            List<EmployeeProject> employeeProjects = new List<EmployeeProject>();

            var filePath = Path.GetTempFileName();
            
            if (file != null)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                using (var reader = System.IO.File.OpenText(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var employeeProject = reader.ReadLine().ToEmployeeProject();
                        employeeProjects.Add(employeeProject);
                    }
                }
            }

            var employeesResult = this.EmployeeProjectService.FindPairsEmployees(employeeProjects);

            return Index(employeesResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
