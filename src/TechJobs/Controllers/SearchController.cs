using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            return RedirectToAction("Results", "Search", new { searchType = searchType, searchTerm = searchTerm });
        }
        public IActionResult Results(string searchType, string searchTerm)

        {
            if (searchType == "all" && searchTerm == null)
            {
                List<Dictionary<string, string>> jobsList = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobsList;
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            } 
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobsList = JobData.FindByValue(searchType, searchTerm);
                ViewBag.jobs = jobsList;
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobsList = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobsList;
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }

        }

        }
    // TODO #1 - Create a Results action method to process 
}           // search request and display results
    
        
    
