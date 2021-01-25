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
    public class EditViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		private readonly SponsorService SponsorService;
		public SponsorDetailModel Sponsor { get; set; }

		public EditViewModel(SponsorService SponsorService)
		{
			Title = "Edit sponsor";
			Subtitle = "In this section, you can edit an sponsor's data.";

			this.SponsorService = SponsorService;
		}

		public override async Task PreRender()
		{
			int id = Convert.ToInt32(Context.Parameters["IdSponsor"]);
			Sponsor = await SponsorService.GetSponsorByIdAsync(id);

			await base.PreRender();
		}

		public async Task EditSponsor()
		{
			await SponsorService.UpdateSponsorAsync(Sponsor);
			Context.RedirectToRoute("DetailSponsor", new { IdSponsor = Sponsor.IdSponsor });
		}
	}
}

