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
    public class ListViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly OrganizerService OrganizerService;

		[Bind(Direction.ServerToClient)]
		public List<OrganizerListModel> Organizers { get; set; }

		public int ContUsers { get; set; }

		public ListViewModel(OrganizerService OrganizerService)
		{
			Title = "Organizer dashboard";
			Subtitle = "In this section you can see the list of organizers registered in the database.";

			this.OrganizerService = OrganizerService;
		}

		public override async Task PreRender()
		{
			Organizers = await OrganizerService.GetAllOrganizersAsync();

			await base.PreRender();
		}
	}
}

