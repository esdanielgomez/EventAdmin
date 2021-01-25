using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models.Speakers;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Speakers
{
    public class CreateViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

        private readonly SpeakerService SpeakerService;

        public SpeakerDetailModel Speaker { get; set; } = new SpeakerDetailModel();

        public CreateViewModel(SpeakerService SpeakerService)
		{
			Title = "Create speaker";
			Subtitle = "In this section you can create a new speaker.";

            this.SpeakerService = SpeakerService;
        }

        public async Task AddSpeaker()
        {
            await SpeakerService.InsertSpeakerAsync(Speaker);
            Context.RedirectToRoute("Speaker");
        }
    }
}

