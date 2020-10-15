using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesDepartments.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeesDepartments.Controllers
{
    public class EmployeesDepartmentsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       private readonly  IRepository _repository;
        public EmployeesDepartmentsController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult GetAllWorkPositionWithDepartment()
        {
            return View(_repository.GetAllWorkPositionWithDepartment());
        }  
        public IActionResult GetDepartmentsWithChief()
        {
            return View(_repository.GetDepartmentsWithChief());
        }
    }
}
