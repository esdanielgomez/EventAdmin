using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models;
using EventAdmin.BL.Models.Sessions;
using EventAdmin.BL.Models.Speakers;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Sessions
{
    public class EditViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		private readonly SessionService SessionService;
		private readonly SpeakerService SpeakerService;
		public SessionDetailModel Session { get; set; }
		
		//
		[Bind(Direction.ServerToClient)]
		public List<SessionLevelModel> Levels { get; set; }
		public SessionLevelModel SessionLevelModelSelected { get; set; }

		[Bind(Direction.ServerToClient)]
		public List<SessionTypeModel> Types { get; set; }
		public SessionTypeModel SessionTypeModelSelected { get; set; }


		[Bind(Direction.ServerToClient)]
		public List<SpeakerListModel> Speakers { get; set; } = new List<SpeakerListModel>();

		public SpeakerListModel SpeakerToAdd { get; set; }
		public SpeakerHasSessionModel SpeakerToRemove { get; set; }

		[Bind(Direction.ServerToClientFirstRequest)]
		public List<SpeakerHasSessionModel> SpeakersSelected { get; set; } = new List<SpeakerHasSessionModel>();

		//


		public EditViewModel(SessionService SessionService, SpeakerService SpeakerService)
		{
			Title = "Edit session";
			Subtitle = "In this section, you can edit an session's data.";

			this.SessionService = SessionService;
			this.SpeakerService = SpeakerService;
		}

		public override async Task PreRender()
		{
			int id = Convert.ToInt32(Context.Parameters["IdSession"]);
			Session = await SessionService.GetSessionByIdAsync(id);

			Levels = await SessionService.GetSessionLevelAsync();
			Types = await SessionService.GetSessionTypeAsync();

			Speakers = await SpeakerService.GetAllSpeakerAsync();

			SpeakersSelected = Session.SpeakersSessions;

			await base.PreRender();
		}

		public async Task EditSession()
		{
			await SessionService.UpdateSessionAsync(Session, SpeakersSelected);
			Context.RedirectToRoute("DetailSession", new { IdSession = Session.IdSession });
		}

		public void AddToListSpeaker()
		{
			var match = SpeakersSelected.FirstOrDefault(s => s.IdSpeaker == SpeakerToAdd.IdSpeaker);
			if (match == null)
			{

				SpeakersSelected.Add(new SpeakerHasSessionModel { 
					IdSpeaker = SpeakerToAdd.IdSpeaker,
					FirstName = SpeakerToAdd.FirstName,
					SecondName = SpeakerToAdd.SecondName,
					FirstLastName = SpeakerToAdd.FirstLastName,
					SecondLastName = SpeakerToAdd.SecondLastName
				});
			}

		}

		public void RemoveFromListSpeaker()
		{
			Console.WriteLine("Speaker");
			Console.WriteLine(SpeakerToRemove.IdSpeaker);
			var item = SpeakersSelected.SingleOrDefault(s => s.IdSpeaker == SpeakerToRemove.IdSpeaker);
			if (item != null)
            {
				SpeakersSelected.Remove(item);
				Console.WriteLine("Gollaaaa");
            }
				

		}
	}
}

