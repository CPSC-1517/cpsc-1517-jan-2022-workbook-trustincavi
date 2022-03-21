using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly RegionServices _regionServices;

        public RegionQueryOneModel(ILogger<IndexModel> logger, RegionServices regionServices)
        {
            _logger = logger;
            _regionServices = regionServices;
        }
        #endregion
        
        [TempData]
        public string FeedbackMessage { get; set; }


        // This is bond to the input control via asp-for
        // This is a 2-way binding out and in.
        // Data is move out and in automatically.

        // The SupportsGet = true will allow the property to be matched to the routing parameter
        //   of the same name.
        [BindProperty(SupportsGet = true)]
        public int RegionID { get; set; }

        public Region RegionInfo { get; set; }

        //the List<T> has a null value as the page is created
        //you can initialize the property to an instance as the page is
        //      being created by adding = new() to your declaration
        //if you do, you will have an empty instance of List<T>
        [BindProperty]
        public List<Region> regionsList { get; set; } = new();

        [BindProperty]
        public int selectRegion { get; set; }


        public void OnGet()
        {
            //since the internet is a stateless environment, you need to 
            //  obtain any list data that is required by your controls or local
            //  logic on EVERY instance of the page being processed
            PopulateLists();

            if (RegionID > 0)
            {
                RegionInfo = _regionServices.Region_GetById(RegionID);
                if (RegionInfo == null)
                {
                    FeedbackMessage = "Region Id is not valid. No such region.";
                }
                else
                {
                    FeedbackMessage = $"ID: {RegionInfo.RegionID}. Description: {RegionInfo.RegionDescription}";
                }
            }
        }

        private void PopulateLists()
        {
            //this method will obtain the data for any require list to be used
            //      in populating controls or for local logic
            regionsList = _regionServices.Region_List();
        }

        public IActionResult OnPostSelect()
        {
            if (selectRegion < 1)
            {
                FeedbackMessage = "Required: Select a region to view.";
            }
            //the receiving "regionid" is the routing parameter
            //the sending "selectRegion" is a BindProperty field
            return RedirectToPage(new { regionid = selectRegion });
        }


        // Khi co nhieu button tren cung 1 form/page
        // Thi su dung asp-page-handler="HandlerName",
        //  dat ten OnPost+HandlerName()

        // Generic falling post handler
        public void OnPost()
        {
            FeedbackMessage = "WARNING: No OnPost for page handler found. Execution default to OnPost().";
        }

        // Specific OnPost+HandlerName()
        //public void OnPostFetch()
        //{
        //    if (RegionID > 0)
        //    {
        //        RegionInfo = _regionServices.Region_GetById(RegionID);
        //        if (RegionInfo == null)
        //        {
        //            FeedbackMessage = "Region Id is not valid. No such region.";
        //        }
        //        else
        //        {
        //            FeedbackMessage = $"ID: {RegionInfo.RegionID}. Description: {RegionInfo.RegionDescription}";
        //        }
        //    }
        //    else
        //    {
        //        FeedbackMessage = "Required: Region Id is a non-zero positive number.";
        //    }
        //}
        public IActionResult OnPostFetch()
        {
            if (RegionID < 1)
            {
                FeedbackMessage = "Required: Region Id is a non-zero positive number.";
            }

            // The receiving RegionID is the routing parameter.
            // The sending RegionID is a BindProperty field.
            return RedirectToPage(new {RegionID = RegionID});
        }

        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            RegionID = 0;

            ModelState.Clear();

            return RedirectToPage(new {RegionID = (int?)null});
        }
    }
}
