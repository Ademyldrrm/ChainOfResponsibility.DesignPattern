using ChainOfResponsibility.DesignPattern.ChainOfResponsibility;
using ChainOfResponsibility.DesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibility.DesignPattern.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer= new Treasurer();
            Employee managerAsistant=new ManagerAsistant();
            Employee manager = new Manager();
            Employee areaDirector = new AreDirector();

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);
            treasurer.ProcessReguest(model);
            return View();
        }
    }
}
