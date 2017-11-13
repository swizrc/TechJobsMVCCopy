using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        static private List<Dictionary<string, string>> Jobs = new List<Dictionary<string, string>>();
        static private string search;

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = Jobs;
            ViewBag.search = search;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchTerm != null)
            {
                if (searchType == "all")
                {
                    Jobs = JobData.FindByValue(searchTerm);
                }
                else
                {
                    Jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
                }
            }
            search = searchTerm;
            return Redirect("/Search");
        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
