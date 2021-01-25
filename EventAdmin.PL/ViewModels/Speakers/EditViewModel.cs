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
    public class EditViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		private readonly SpeakerService SpeakerService;
		public SpeakerDetailModel Speaker { get; set; }

		public EditViewModel(SpeakerService SpeakerService)
		{
			Title = "Edit organizer";
			Subtitle = "In this section, you can edit an speaker's data.";

			this.SpeakerService = SpeakerService;
		}

		public override async Task PreRender()
		{
			int id = Convert.ToInt32(Context.Parameters["IdSpeaker"]);
			Speaker = await SpeakerService.GetSpeakerByIdAsync(id);

			await base.PreRender();
		}

		public async Task EditSpeaker()
		{
			await SpeakerService.UpdateSpeakerAsync(Speaker);
			Context.RedirectToRoute("DetailSpeaker", new { IdSpeaker = Speaker.IdSpeaker });
		}
	}
}

