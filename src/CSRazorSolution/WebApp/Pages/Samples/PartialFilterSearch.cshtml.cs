using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchModel(ILogger<IndexModel> logger,
                                        TerritoryServices territoryservices,
                                        RegionServices regionServices)
        {
            _logger = logger;
            _territoryServices = territoryservices;
            _regionServices = regionServices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Searcharg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; } = new();

        public void OnGet()
        {
            // Obtain the data list for the region dropdown list
            RegionList = _regionServices.Region_List();
            
            if (!string.IsNullOrWhiteSpace(Searcharg))
            {
                TerritoryInfo = _territoryServices.GetByPartialDescription(Searcharg);
            }
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(Searcharg))
            {
                Feedback = "Required: Search argument is empty.";
            }

            return RedirectToPage(new { Searcharg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }

    }
}