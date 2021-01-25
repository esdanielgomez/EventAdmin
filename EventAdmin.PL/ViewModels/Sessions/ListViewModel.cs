using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using EventAdmin.BL.Models.Sessions;
using EventAdmin.BL.Services;

namespace EventAdmin.PL.ViewModels.Sessions
{
    public class ListViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly SessionService SessionService;

		[Bind(Direction.ServerToClient)]
		public List<SessionListModel> Sessions { get; set; }

		public int ContUsers { get; set; }

		public ListViewModel(SessionService SessionService)
		{
			Title = "Session dashboard";
			Subtitle = "In this section you can see the list of sessions registered in the database.";

			this.SessionService = SessionService;
		}

		public override async Task PreRender()
		{
			Sessions = await SessionService.GetAllSessionAsync();

			await base.PreRender();
		}
	}
}

