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
    public class CreateViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

        private readonly SponsorService SponsorService;

        public SponsorDetailModel Sponsor { get; set; } = new SponsorDetailModel();

        public CreateViewModel(SponsorService SponsorService)
		{
			Title = "Create sponsor";
			Subtitle = "In this section you can create a new sponsor.";

            this.SponsorService = SponsorService;
        }

        public async Task AddSponsor()
        {
            await SponsorService.InsertSponsorAsync(Sponsor);
            Context.RedirectToRoute("Sponsor");
        }
    }
}

