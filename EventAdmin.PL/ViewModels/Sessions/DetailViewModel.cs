using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models;
using EventAdmin.BL.Models.Sessions;
using EventAdmin.BL.Services;
using EventAdmin.DAL.Entities;

namespace EventAdmin.PL.ViewModels.Sessions
{
    public class DetailViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SessionService SessionService;
		public SessionDetailModel Session { get; set; }

		public int IdSearch { get; set; }
		public SpeakerHasSessionModel SpeakerAtSessionSelected { get; set; } = new SpeakerHasSessionModel();

		public DetailViewModel(SessionService SessionService)
		{
			Title = "Session detail";
			Subtitle = "In this section you can see the detailed data of a session.";

			this.SessionService = SessionService;
		}

		public override async Task PreRender()
		{
			IdSearch = Convert.ToInt32(Context.Parameters["IdSession"]);
			Console.WriteLine(IdSearch);
			Session = await SessionService.GetSessionByIdAsync(IdSearch);

			
			await base.PreRender();
					
		}

		public async Task DeleteSession()
		{
			await SessionService.DeleteSessionAsync(Session.IdSession);
			Context.RedirectToRoutePermanent("Session", replaceInHistory: true);
		}
	}
}

