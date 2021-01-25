using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models.Sessions;
using EventAdmin.BL.Models.Speakers;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Sessions
{
    public class CreateViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

        private readonly SessionService SessionService;
        private readonly SpeakerService SpeakerService;

        //
        [Bind(Direction.ServerToClient)]
        public List<SessionLevelModel> Levels { get; set; }
        public SessionLevelModel SessionLevelModelSelected { get; set; }

        [Bind(Direction.ServerToClient)]
        public List<SessionTypeModel> Types { get; set; }
        public SessionTypeModel SessionTypeModelSelected { get; set; }

        public SessionDetailModel Session { get; set; } = new SessionDetailModel() { StartDate = DateTime.UtcNow.Date, EndDate = DateTime.UtcNow.Date };

        [Bind(Direction.ServerToClient)]
        public List<SpeakerListModel> Speakers { get; set; }

        public SpeakerListModel SpeakerToAdd { get; set; }
        public SpeakerListModel SpeakerToRemove { get; set; }

        public List<SpeakerListModel> SpeakersSelected { get; set; } = new List<SpeakerListModel>();

        //
        public CreateViewModel(SessionService SessionService, SpeakerService SpeakerService)
		{
			Title = "Create session";
			Subtitle = "In this section you can create a new session.";

            this.SessionService = SessionService;
            this.SpeakerService = SpeakerService;
        }

        public override async Task PreRender()
        {
            Levels = await SessionService.GetSessionLevelAsync();
            Types = await SessionService.GetSessionTypeAsync();
            Speakers = await SpeakerService.GetAllSpeakerAsync();

            await base.PreRender();
        }

        public async Task AddSession()
        {
            Session.IdSessionLevel = SessionLevelModelSelected.IdSessionLevel;
            Session.IdSessionType = SessionTypeModelSelected.IdSessionType;

            await SessionService.InsertSessionAsync(Session, SpeakersSelected);
            Context.RedirectToRoute("Session");
        }

        public void AddToListSpeaker()
        {
            var match = SpeakersSelected.FirstOrDefault(s => s.IdSpeaker == SpeakerToAdd.IdSpeaker);
            if (match==null)
            {
                SpeakersSelected.Add(SpeakerToAdd);
            }

            SpeakerToAdd = new SpeakerListModel();
        }

        public void RemoveFromListSpeaker()
        {
            var item = SpeakersSelected.SingleOrDefault(s => s.IdSpeaker == SpeakerToRemove.IdSpeaker);
            if (item != null)
                SpeakersSelected.Remove(item);

            SpeakerToRemove = new SpeakerListModel();

        }
    }
}

