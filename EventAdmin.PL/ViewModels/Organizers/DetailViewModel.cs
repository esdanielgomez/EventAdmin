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
    public class DetailViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly OrganizerService OrganizerService;
		public OrganizerDetailModel Organizer { get; set; }
		public int IdSearch { get; set; }

		public DetailViewModel(OrganizerService OrganizerService)
		{
			Title = "Organizer detail";
			Subtitle = "In this section you can see the detailed data of an organizer.";

			this.OrganizerService = OrganizerService;
		}

		public override async Task PreRender()
		{
			IdSearch = Convert.ToInt32(Context.Parameters["IdOrganizer"]);
			Console.WriteLine(IdSearch);
			Organizer = await OrganizerService.GetOrganizerByIdAsync(IdSearch);
			
			await base.PreRender();
			
		
		}

		public async Task DeleteOrganizer()
		{
			await OrganizerService.DeleteOrganizerAsync(Organizer.IdOrganizer);
			Context.RedirectToRoutePermanent("Organizer", replaceInHistory: true);
		}
	}
}

