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
    public class EditViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		private readonly OrganizerService OrganizerService;
		public OrganizerDetailModel Organizer { get; set; }

		public EditViewModel(OrganizerService OrganizerService)
		{
			Title = "Edit organizer";
			Subtitle = "In this section, you can edit an organizer's data.";

			this.OrganizerService = OrganizerService;
		}

		public override async Task PreRender()
		{
			int id = Convert.ToInt32(Context.Parameters["IdOrganizer"]);
			Organizer = await OrganizerService.GetOrganizerByIdAsync(id);

			await base.PreRender();
		}

		public async Task EditOrganizer()
		{
			await OrganizerService.UpdateOrganizerAsync(Organizer);
			Context.RedirectToRoute("DetailOrganizer", new { IdOrganizer = Organizer.IdOrganizer });
		}
	}
}

