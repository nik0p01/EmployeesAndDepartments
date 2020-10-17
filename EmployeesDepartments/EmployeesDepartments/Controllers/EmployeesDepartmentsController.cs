using EmployeesDepartments.DAL.Entities;
using EmployeesDepartments.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeesDepartments.Controllers
{
    public class EmployeesDepartmentsController : Controller
    {
        private readonly ILogger<EmployeesDepartmentsController> _logger;
        private readonly IRepository _repository;
        public EmployeesDepartmentsController(ILogger<EmployeesDepartmentsController> logger, IRepository repository)
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
            var a = _repository.GetAllWorkPositionWithDepartment();
            return View(a);
        }
        public IActionResult GetDepartmentsWithChief()
        {
            return View(_repository.GetDepartmentsWithChief());
        }

        public IActionResult GetEmpoyeesByDepartmentId(int id)
        {
            return View(_repository.GetEmpoyeesByDepartmentId(new Department() { id = id }));
        }
        public IActionResult GetFreeRates()
        {

            return View(_repository.GetFreeRates());
        }
        [HttpGet]
        public IActionResult EditWorkRate(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.WorkRateId = id;
            ViewBag.Departments = _repository.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public string EditWorkRate(int id, string NamePosition, bool chief, int DepartmentId)
        {
            _repository.EditWorkingRates(new WorkingRate { id = id, chief = chief, department = new Department() { id = DepartmentId }, workPosition = new WorkPosition() { name = NamePosition } });
            return "Запись отредактирована";
        }
        [HttpGet]
        public IActionResult EditEmpoyeeById(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.EmpoyeeId = id;
            return View();
        }
        [HttpPost]
        public string EditEmpoyeeById(int id, string name, string email)
        {
            _repository.EditEmpoyeeById(new Employee() { id = id, name = name, email = email });
            return "Запись отредактирована";
        }
    }
}
