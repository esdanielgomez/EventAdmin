using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models.Sponsors;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Sponsors
{
    public class ListViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SponsorService SponsorService;

		[Bind(Direction.ServerToClient)]
		public List<SponsorListModel> Sponsors { get; set; }

		public int ContUsers { get; set; }

		public ListViewModel(SponsorService SponsorService)
		{
			Title = "Sponsor dashboard";
			Subtitle = "In this section you can see the list of sponsors registered in the database.";

			this.SponsorService = SponsorService;
		}

		public override async Task PreRender()
		{
			Sponsors = await SponsorService.GetAllSponsorsAsync();

			await base.PreRender();
		}
	}
}

