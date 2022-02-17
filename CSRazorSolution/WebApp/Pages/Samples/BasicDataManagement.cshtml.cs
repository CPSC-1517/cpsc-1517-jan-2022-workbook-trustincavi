using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //Bound properties that are directly tied to a control on the form
        //Bound properties have the data automatically trnasferred from the control into the property
        [BindProperty]
        public int Num { get; set; } // ties to the control use the asp-for
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }

        [TempData]
        public string FeedBack { get; set; }
        public void OnGet()
        {
            //Execute for a Get request
            //The first time the page is requested, an automatic Get request is sent.
            //Execellent "event" to use to do any intialization to your web page display as the page
            //  is shown for the first time.

        }

        public void OnPost()
        {
            //Process the OnPost request of the form (methos="post")
            //The return datatype can be void or IActionResult
            //OnPost request is the request from a <button> that has NOT indicated a specific
            //  process Post using the asp-page-handler
            //Logic that you wish to accomplish should be isolated to the actions
            //  desired for the button.

            FeedBack = $"Number {Num}, Course {FavouriteCourse}, Comments {Comments}";
        }
    }
}
