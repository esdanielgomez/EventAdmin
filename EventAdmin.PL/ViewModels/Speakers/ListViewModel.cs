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
    public class ListViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SpeakerService SpeakerService;

		[Bind(Direction.ServerToClient)]
		public List<SpeakerListModel> Speakers { get; set; }

		public int ContUsers { get; set; }

		public ListViewModel(SpeakerService SpeakerService)
		{
			Title = "Speaker dashboard";
			Subtitle = "In this section you can see the list of speakers registered in the database.";

			this.SpeakerService = SpeakerService;
		}

		public override async Task PreRender()
		{
			Speakers = await SpeakerService.GetAllSpeakerAsync();

			await base.PreRender();
		}
	}
}

