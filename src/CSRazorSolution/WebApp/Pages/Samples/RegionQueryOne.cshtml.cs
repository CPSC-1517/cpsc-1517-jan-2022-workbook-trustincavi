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

        public void OnGet()
        {
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
