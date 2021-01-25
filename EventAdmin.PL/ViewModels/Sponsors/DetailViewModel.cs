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
    public class DetailViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SponsorService SponsorService;
		public SponsorDetailModel Sponsor { get; set; }
		public int IdSearch { get; set; }

		public DetailViewModel(SponsorService SponsorService)
		{
			Title = "Sponsor detail";
			Subtitle = "In this section you can see the detailed data of an sponsor.";

			this.SponsorService = SponsorService;
		}

		public override async Task PreRender()
		{
			IdSearch = Convert.ToInt32(Context.Parameters["IdSponsor"]);
			Console.WriteLine(IdSearch);
			Sponsor = await SponsorService.GetSponsorByIdAsync(IdSearch);
			
			await base.PreRender();
			
		
		}

		public async Task DeleteSponsor()
		{
			await SponsorService.DeleteSponsorAsync(Sponsor.IdSponsor);
			Context.RedirectToRoutePermanent("Sponsor", replaceInHistory: true);
		}
	}
}

