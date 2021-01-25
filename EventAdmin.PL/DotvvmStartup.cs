using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace EventAdmin.PL
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");

            config.RouteTable.Add("Organizer", "Organizer", "Views/Organizers/List.dothtml");
            config.RouteTable.Add("CreateOrganizer", "CreateOrganizer", "Views/Organizers/Create.dothtml");
            config.RouteTable.Add("EditOrganizer", "EditOrganizer/{IdOrganizer}", "Views/Organizers/Edit.dothtml");
            config.RouteTable.Add("DetailOrganizer", "DetailOrganizer/{IdOrganizer}", "Views/Organizers/Detail.dothtml");

            config.RouteTable.Add("Speaker", "Speaker", "Views/Speakers/List.dothtml");
            config.RouteTable.Add("CreateSpeaker", "CreateSpeaker", "Views/Speakers/Create.dothtml");
            config.RouteTable.Add("EditSpeaker", "EditSpeaker/{IdSpeaker}", "Views/Speakers/Edit.dothtml");
            config.RouteTable.Add("DetailSpeaker", "DetailSpeaker/{IdSpeaker}", "Views/Speakers/Detail.dothtml");

            config.RouteTable.Add("Sponsor", "Sponsor", "Views/Sponsors/List.dothtml");
            config.RouteTable.Add("CreateSponsor", "CreateSponsor", "Views/Sponsors/Create.dothtml");
            config.RouteTable.Add("EditSponsor", "EditSponsor/{IdSponsor}", "Views/Sponsors/Edit.dothtml");
            config.RouteTable.Add("DetailSponsor", "DetailSponsor/{IdSponsor}", "Views/Sponsors/Detail.dothtml");

            config.RouteTable.Add("Session", "Session", "Views/Sessions/List.dothtml");
            config.RouteTable.Add("CreateSession", "CreateSession", "Views/Sessions/Create.dothtml");
            config.RouteTable.Add("EditSession", "EditSession/{IdSession}", "Views/Sessions/Edit.dothtml");
            config.RouteTable.Add("DetailSession", "DetailSession/{IdSession}", "Views/Sessions/Detail.dothtml");

            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/assets/css/material-dashboard.css?v=2.1.2")
            });
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
		}
    }
}
