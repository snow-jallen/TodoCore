using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoCore.Controllers
{
    public class SampleFormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(SampleForm.Instance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateItem(SampleForm newValues)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            SampleForm.Instance.FirstName = newValues.FirstName ?? SampleForm.Instance.FirstName;
            SampleForm.Instance.LastName = newValues.LastName ?? SampleForm.Instance.LastName;
            if (newValues.SubmittedOn != DateTime.MinValue)
                SampleForm.Instance.SubmittedOn = newValues.SubmittedOn;
            SampleForm.Instance.Notes = newValues.Notes ?? SampleForm.Instance.Notes;

            return RedirectToAction("Index");
        }
    }

    //HACK: This should really go in /Models, but it's here for demonstration
    public class SampleForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string Notes { get; set; }
        public decimal Number { get; set; }

        //HACK HACKETY HACK!  This is _SO_ not safe.  At all.  Never do this.  Seriously.  Ever.
        public static SampleForm Instance { get; set; }
        static SampleForm()
        {
            Instance = new SampleForm
            {
                FirstName = "Default FirstName",
                LastName = "Default LastName",
                SubmittedOn = DateTime.Now,
                Notes = "Default Notes",
                Number = 123.45M
            };
        }
    }
}