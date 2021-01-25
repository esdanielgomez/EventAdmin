using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAdmin.BL.Models.Sponsors;
using EventAdmin.DAL;
using EventAdmin.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventAdmin.BL.Services
{
    public class SponsorService
    {
        private readonly DBContext DbContext;

        public SponsorService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SponsorListModel>> GetAllSponsorsAsync()
        {

            return await DbContext.Sponsor.Select(
                s => new SponsorListModel
                {
                    IdSponsor = s.IdSponsor,
                    Name = s.Name
                }
            ).ToListAsync();
        }

        public async Task<SponsorDetailModel> GetSponsorByIdAsync(int IdSponsor)
        {
            return await DbContext.Sponsor.Select(
                    s => new SponsorDetailModel
                    {
                        IdSponsor = s.IdSponsor,
                        Name = s.Name,
                        Description = s.Description,
                        WebPage = s.WebPage,
                        LogoLink = s.LogoLink
                    })
                .FirstOrDefaultAsync(s => s.IdSponsor == IdSponsor);
        }

        public async Task InsertSponsorAsync(SponsorDetailModel Sponsor)
        {
            var entity = new Sponsor()
            {
                Name = Sponsor.Name,
                Description = Sponsor.Description,
                WebPage = Sponsor.WebPage,
                LogoLink = Sponsor.LogoLink,
                IdEvent = EventId.GetInstance().Id
            };

            DbContext.Sponsor.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateSponsorAsync(SponsorDetailModel Sponsor)
        {
            var entity = await DbContext.Sponsor.FirstOrDefaultAsync(s => s.IdSponsor == Sponsor.IdSponsor);

            entity.Name = Sponsor.Name;
            entity.Description = Sponsor.Description;
            entity.WebPage = Sponsor.WebPage;
            entity.LogoLink = Sponsor.LogoLink;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteSponsorAsync(int IdSponsor)
        {
            var entity = new Sponsor()
            {
                IdSponsor = IdSponsor
            };
            DbContext.Sponsor.Attach(entity);
            DbContext.Sponsor.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
