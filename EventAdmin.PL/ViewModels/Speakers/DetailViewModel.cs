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
    public class DetailViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SpeakerService SpeakerService;
		public SpeakerDetailModel Speaker { get; set; }
		public int IdSearch { get; set; }

		public DetailViewModel(SpeakerService SpeakerService)
		{
			Title = "Speaker detail";
			Subtitle = "In this section you can see the detailed data of an speaker.";

			this.SpeakerService = SpeakerService;
		}

		public override async Task PreRender()
		{
			IdSearch = Convert.ToInt32(Context.Parameters["IdSpeaker"]);
			Console.WriteLine(IdSearch);
			Speaker = await SpeakerService.GetSpeakerByIdAsync(IdSearch);
			
			await base.PreRender();
			
		
		}

		public async Task DeleteSpeaker()
		{
			await SpeakerService.DeleteSpeakerAsync(Speaker.IdSpeaker);
			Context.RedirectToRoutePermanent("Speaker", replaceInHistory: true);
		}
	}
}

