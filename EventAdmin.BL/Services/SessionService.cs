using EventAdmin.BL.Models;
using EventAdmin.BL.Models.Sessions;
using EventAdmin.BL.Models.Speakers;
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
    public class SessionService
    {
        private readonly DBContext DbContext;

        public SessionService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SessionListModel>> GetAllSessionAsync()
        {

            return await DbContext.Session.Select(
                s => new SessionListModel
                {
                    IdSession = s.IdSession,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    NameSessionLevel = s.IdSessionLevelNavigation.Name,
                    NameSessionType = s.IdSessionTypeNavigation.Name
                }
            ).ToListAsync();
        }

        public async Task<List<SessionLevelModel>> GetSessionLevelAsync()
        {

            return await DbContext.Sessionlevel.Select(
                s => new SessionLevelModel
                {
                    IdSessionLevel = s.IdSessionLevel,
                    Name = s.Name,
                    Description = s.Description
                }
            ).ToListAsync();
        }

        public async Task<List<SessionTypeModel>> GetSessionTypeAsync()
        {

            return await DbContext.Sessiontype.Select(
                s => new SessionTypeModel
                {
                    IdSessionType = s.IdSessionType,
                    Name = s.Name,
                    Description = s.Description
                }
            ).ToListAsync();
        }

        public async Task<SessionDetailModel> GetSessionByIdAsync(int IdSession)
        {
            SessionDetailModel session = await DbContext.Session.Select(
                    s => new SessionDetailModel
                    {
                        IdSession = s.IdSession,
                        Name = s.Name,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        Description = s.Description,
                        IconLink = s.IconLink,
                        IdSessionLevel = s.IdSessionLevelNavigation.IdSessionLevel,
                        NameSessionLevel = s.IdSessionLevelNavigation.Name,
                        IdSessionType = s.IdSessionTypeNavigation.IdSessionType,
                        NameSessionType = s.IdSessionTypeNavigation.Name

                    })
                .FirstOrDefaultAsync(s => s.IdSession == IdSession);

            session.SpeakersSessions = await DbContext.SpeakerHasSession.Select(
                s => new SpeakerHasSessionModel
                {
                    IdSpeaker = s.IdSpeaker,
                    FirstName = s.IdSpeakerNavigation.FirstName,
                    SecondName = s.IdSpeakerNavigation.SecondName,
                    FirstLastName = s.IdSpeakerNavigation.FirstLastName,
                    SecondLastName = s.IdSpeakerNavigation.SecondLastName,

                    IdSession = s.IdSession,
                    Name = s.IdSessionNavigation.Name,
                    StartDate = s.IdSessionNavigation.StartDate,
                    NameSessionLevel = s.IdSessionNavigation.IdSessionLevelNavigation.Name,
                    NameSessionType = s.IdSessionNavigation.IdSessionTypeNavigation.Name
                }
            ).Where(s => s.IdSession == IdSession).ToListAsync();

            return session;

        }

        public async Task InsertSessionAsync(SessionDetailModel Session, List<SpeakerListModel> Speakers)
        {
            var entity = new Session()
            {
                Name = Session.Name,
                StartDate = Session.StartDate,
                EndDate = Session.EndDate,
                Description = Session.Description,
                IconLink = Session.IconLink,
                IdSessionLevel = Session.IdSessionLevel,
                IdSessionType = Session.IdSessionType
            };

            DbContext.Session.Add(entity);
            await DbContext.SaveChangesAsync();

            await DbContext.Entry(entity).GetDatabaseValuesAsync();

            int IdS = entity.IdSession;
            Console.WriteLine("-------------------------");
            Console.WriteLine(IdS);

            foreach (var s in Speakers)
            {
                var speakatsession = new SpeakerHasSession()
                {
                    IdSpeaker = s.IdSpeaker,
                    IdSession = IdS
                };

                Console.WriteLine(speakatsession.IdSession + " - " + speakatsession.IdSpeaker);

                await DbContext.SpeakerHasSession.AddAsync(speakatsession);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateSessionAsync(SessionDetailModel Session, List<SpeakerHasSessionModel> Speakers)
        {
            var entity = await DbContext.Session.FirstOrDefaultAsync(s => s.IdSession == Session.IdSession);

            entity.Name = Session.Name;
            entity.StartDate = Session.StartDate;
            entity.EndDate = Session.EndDate;
            entity.Description = Session.Description;
            entity.IconLink = Session.IconLink;
            entity.IdSessionLevel = Session.IdSessionLevel;
            entity.IdSessionType = Session.IdSessionType;

            await DbContext.SaveChangesAsync();

            var entitySpeakerHasSession = new SpeakerHasSession()
            {
                IdSession = Session.IdSession
            };

            


        }

        public async Task DeleteSessionAsync(int IdSession)
        {

            DbContext.SpeakerHasSession.RemoveRange(DbContext.SpeakerHasSession.Where(s => s.IdSession == IdSession));
            await DbContext.SaveChangesAsync();

            DbContext.Remove(DbContext.Session.Single(s => s.IdSession == IdSession));
            await DbContext.SaveChangesAsync();
        }
    }
}
