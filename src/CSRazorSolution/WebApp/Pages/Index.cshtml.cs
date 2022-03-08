﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL; // this is where the services were coded
using WestWindSystem.Entities; // this is where the entity definition is coded
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;

        /*
         * Services that are registered using AddTransient<>()
         * can be accessed on the constructor of the web page class (PageModel).
         * This is referred to as Dependency Injection.
         * Each register service injected is listed on the constructor as a parameter.
         * ILogger is a service from Microsoft Logging extensions.
         * 
         * We need to add our required service(s) to this page.
         * Our service(s) will be know by the BLL class name.
         * 
         * When you add a service to the page, you will save the service reference in
         * a private readonly field.
         * This variablewill be available to all methods within this class.
         */

        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }
        #endregion


        public string MyName { get; set; }

        public BuildVersion BuildVersionInfo { get; set; }

        public void OnGet()
        {
            Random random = new Random();
            int value = random.Next(0, 100);

            if (value % 2 == 0)
            {
                MyName = $"Welcome to the Razor World ({value})";
            }
            else
            {
                MyName = null;
            }


            // Consume a service (aka method) from the services BuildVersionServices
            BuildVersionInfo = _buildVersionServices.GetBuildVersion();
        }
    }
}