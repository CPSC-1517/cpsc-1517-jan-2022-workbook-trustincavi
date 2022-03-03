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


        //Annotation TempData is required IF you are processing multiple requests (OnPost followed by OnGet)
        //
        //[TempData]
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
            //Process the OnPost request of the form (method="post").
            FeedBack = $"Number {Num}, Course {FavouriteCourse}, Comments {Comments}";
        }

        public void OnPostA()
        {
            //This method is called due to the helper-tag on the form button.
            //The "string" used on the helper-tag asp-page-handler="string" is add to the OnPost method name.

            FeedBack = $"Button A was pressed.";
        }

        public void OnPostB()
        {
            FeedBack = $"Button B was pressed.";
        }
    }
}
