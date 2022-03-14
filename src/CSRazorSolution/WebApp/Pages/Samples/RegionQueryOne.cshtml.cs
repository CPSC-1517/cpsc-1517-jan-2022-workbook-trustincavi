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
        [BindProperty]
        public int RegionID { get; set; }

        public Region RegionInfo { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
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
            else
            {
                FeedbackMessage = "Required: Region Id is a non-zero positive number.";
            }
        }
    }
}
