using EventAdmin.BL.Models.Organizers;
using EventAdmin.DAL;
using EventAdmin.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAdmin.BL.Services
{
    public class OrganizerService
    {
        private readonly DBContext DbContext;

        public OrganizerService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<OrganizerListModel>> GetAllOrganizersAsync()
        {

            return await DbContext.Organizer.Select(
                s => new OrganizerListModel
                {
                    IdOrganizer = s.IdOrganizer,
                    Name = s.Name
                }
            ).ToListAsync();
        }

        public async Task<OrganizerDetailModel> GetOrganizerByIdAsync(int IdOrganizer)
        {
            return await DbContext.Organizer.Select(
                    s => new OrganizerDetailModel
                    {
                        IdOrganizer = s.IdOrganizer,
                        Name = s.Name,
                        Description = s.Description,
                        WebPage = s.WebPage,
                        LogoLink = s.LogoLink,
                        Email = s.Email,
                        FacebookLink = s.FacebookLink,
                        InstagramLink = s.InstagramLink,
                        TwitterLink = s.InstagramLink
                    })
                .FirstOrDefaultAsync(s => s.IdOrganizer == IdOrganizer);
        }

        public async Task InsertOrganizerAsync(OrganizerDetailModel Organizer)
        {
            var entity = new Organizer()
            {
                Name = Organizer.Name,
                Description = Organizer.Description,
                WebPage = Organizer.WebPage,
                LogoLink = Organizer.LogoLink,
                Email = Organizer.Email,
                FacebookLink = Organizer.FacebookLink,
                InstagramLink = Organizer.InstagramLink,
                TwitterLink = Organizer.TwitterLink,
                IdEvent = EventId.GetInstance().Id
            };

            DbContext.Organizer.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateOrganizerAsync(OrganizerDetailModel Organizer)
        {
            var entity = await DbContext.Organizer.FirstOrDefaultAsync(s => s.IdOrganizer == Organizer.IdOrganizer);

            entity.Name = Organizer.Name;
            entity.Description = Organizer.Description;
            entity.WebPage = Organizer.WebPage;
            entity.LogoLink = Organizer.LogoLink;
            entity.Email = Organizer.Email;
            entity.FacebookLink = Organizer.FacebookLink;
            entity.TwitterLink = Organizer.TwitterLink;
            entity.InstagramLink = Organizer.InstagramLink;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteOrganizerAsync(int IdOrganizer)
        {
            var entity = new Organizer()
            {
                IdOrganizer = IdOrganizer
            };
            DbContext.Organizer.Attach(entity);
            DbContext.Organizer.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
