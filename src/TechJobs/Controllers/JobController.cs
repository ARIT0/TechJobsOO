using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // DONE #1 - get the Job with the given ID and pass it into the view
            Job job = jobData.Find(id);
            return View(job);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // Done #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                Employer employer= jobData.Employers.Find(newJobViewModel.EmployerID);
                Location location = jobData.Locations.Find(newJobViewModel.LocationID);
                CoreCompetency coreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencieID);
                PositionType positionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);

                Job newJob = new Job(newJobViewModel.Name, employer, location, coreCompetency, positionType);
                jobData.Jobs.Add(newJob);

                return Redirect("/Job?id=" + newJob.ID);
            }
            

            return View(newJobViewModel);
        }
    }
}
