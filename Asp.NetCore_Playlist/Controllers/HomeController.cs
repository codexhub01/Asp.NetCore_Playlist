using Asp.NetCore_Playlist.Models;
using Asp.NetCore_Playlist.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Asp.NetCore_Playlist.Controllers
{
    
    public class HomeController : Controller // this Controller class present in Microsoft.AspNetCore.Mvc
    {
        //Here we are using constructor to inject IEmployeeRepository which is known as constructor injection
        
        //This home controller is not creating an instance of IEmployeeRepository using new keyword instead of it we are injecting it into this constructor
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingenviornment;
        public HomeController(IEmployeeRepository employeeRepository , IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingenviornment = hostingEnvironment;

            //_employeeRepository = new MockEmployeeRepository(); -> We are not doing this because its tightly bind with this controller & we have many controller also which creates an issue

        }

        public string Index()
        {
            ViewData["employeedata"] = _employeeRepository.GetEmployee(2).Name;
            ViewBag.EmailId = "abc@gmail.com";
            return _employeeRepository.GetEmployee(1).Name;
            // return View("xyz") :- when we wanna return some other view
            //return View("MyTempViews/tempviiew.cshtml") :- when we wanna return some other view which is not inside views folder , so for that we used absolute path ( file extension also required in this case )
            //return View("../SomeCustomViews/customviewfile") :- this .. means to move one level up in a hierarchy
            //return View();

           
        }

        [Route("Home/newmet/{id}")]
        public ActionResult MethodM1(int id)
        {
            Employee data = _employeeRepository.GetEmployee(1);

            HomeMethodM1ViewModel hmvm = new HomeMethodM1ViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id),
                PageTitle = "something went wrong"

            };

            
            return View(hmvm);
        }

        public ActionResult NewMethod()
        {
            var alldata = _employeeRepository.GetAllEmployees();
            return View(alldata);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]

        public ActionResult NewRoutingMethod()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
               string localuploadfilepath =  Path.Combine(_hostingenviornment.WebRootPath, "images");
                foreach(IFormFile filepathdata in emp.Files)
                {
                    string uniquefilename = Guid.NewGuid().ToString() + "_" + filepathdata.FileName;
                    string filepath = Path.Combine(localuploadfilepath, uniquefilename);
                    //filepathdata.CopyTo(new FileStream(filepath, FileMode.Create));
                }
             
                int id = _employeeRepository.UpdateFormData(emp);
                return RedirectToAction("MethodM1", new { id = id });
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            List<Employee> data = _employeeRepository.GetAllEmployees().Where(s => s.Id == id).ToList();
            EditEmployeeModel eeml = new EditEmployeeModel
            {
                Name = data[0].Name,
                Department = data[0].Department,
                Email = data[0].Email,
                Address = data[0].Address
            };

            return View(eeml);
        }
    }
}
