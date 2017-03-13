using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        
        // GET: /<controller>/
     
        public IActionResult Index()
        {
            Cheese cheeses = new Cheese(); 

            ViewBag.cheeses = Cheeses;
           
            return View(cheeses);

        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name,string discription)
        {
            //Add the new cheese to my existing cheeses
            Cheeses.Add(name, discription);

            return Redirect("/Cheese");
        }

        [Route("/Cheese/Remove/{name}")]
        [HttpGet]
        public IActionResult RemoveCheese(string name)
        {          
            Cheeses.Remove(name);

           
            return Redirect("/Cheese");
        }
    }
}
