using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models.Organizers;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Organizers
{
    public class CreateViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

        private readonly OrganizerService OrganizerService;

        public OrganizerDetailModel Organizer { get; set; } = new OrganizerDetailModel();

        public CreateViewModel(OrganizerService OrganizerService)
		{
			Title = "Create organizer";
			Subtitle = "In this section you can create a new organizer.";

            this.OrganizerService = OrganizerService;
        }

        public async Task AddOrganizer()
        {
            await OrganizerService.InsertOrganizerAsync(Organizer);
            Context.RedirectToRoute("Organizer");
        }
    }
}

