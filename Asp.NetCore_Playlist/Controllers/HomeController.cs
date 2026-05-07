using Asp.NetCore_Playlist.Models;
using Asp.NetCore_Playlist.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Asp.NetCore_Playlist.Controllers
{
    public class useraccess : IdentityUser
    {
       
    }
    
    public class HomeController : Controller // this Controller class present in Microsoft.AspNetCore.Mvc
    {
        //Here we are using constructor to inject IEmployeeRepository which is known as constructor injection
        
        //This home controller is not creating an instance of IEmployeeRepository using new keyword instead of it we are injecting it into this constructor
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingenviornment;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<useraccess> _usermanager;
        private readonly SignInManager<useraccess> _signmanager;
        public HomeController(IEmployeeRepository employeeRepository , IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger , UserManager<useraccess> userManager)
        {
            _employeeRepository = employeeRepository;
            _hostingenviornment = hostingEnvironment;
            _usermanager = userManager;
            _logger = logger;

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
            Employee data = _employeeRepository.GetEmployee(id);

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
            try
            {
                List<Employee> data = _employeeRepository.GetAllEmployees().Where(s => s.Id == id).ToList();
                EditEmployeeModel eeml = new EditEmployeeModel
                {
                    Id = data[0].Id,
                    Name = data[0].Name,
                    Department = data[0].Department,
                    Email = data[0].Email,
                    Address = data[0].Address
                };

                return View(eeml);
            }
            catch(Exception ex)
            {
                return View("CustomErrorMessage");
            }
            

            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditEmployeeModel eeml)
        {
            bool value = _employeeRepository.UpdateEditData(eeml); 
            
            return View(eeml);
        }

        public ActionResult LoggingMethod()
        {
            try
            {
                int a = 10;
                int b = 0;

                int result = a / b;

                _logger.LogInformation("Division successful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Divide by zero exception occurred");
            }

            return View();
        }

        public ActionResult RegistrationUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new useraccess
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _usermanager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [Authorize]
        public ActionResult authorizationmethod()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult deleteuser()
        {
            return View();
        }
    }
}
