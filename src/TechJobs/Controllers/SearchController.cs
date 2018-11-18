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
        
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            return View();
        }
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {

            List<Dictionary<string, string>> jobsList = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobsList;
            ViewBag.columns = ListController.columnChoices;

            return View("Index");
        }
    }
    
            // TODO #1 - Create a Results action method to process 
            // search request and display results
    }
        
    
