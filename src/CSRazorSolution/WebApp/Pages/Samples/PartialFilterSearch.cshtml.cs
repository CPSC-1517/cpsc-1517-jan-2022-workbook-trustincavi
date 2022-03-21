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

        public PartialFilterSearchModel(ILogger<IndexModel> logger,
            TerritoryServices territoryservices)
        {
            _logger = logger;
            _territoryServices = territoryservices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Searcharg { get; set; }

        public List<Territory> TerritoryInfo { get; set; } = new();

        public void OnGet()
        {
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