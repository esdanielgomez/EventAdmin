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
    public class SpeakerService
    {
        private readonly DBContext DbContext;

        public SpeakerService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SpeakerListModel>> GetAllSpeakerAsync()
        {

            return await DbContext.Speaker.Select(
                s => new SpeakerListModel
                {
                    IdSpeaker = s.IdSpeaker,
                    FirstName = s.FirstName,
                    SecondName = s.SecondName,
                    FirstLastName = s.FirstLastName,
                    SecondLastName = s.SecondLastName
                }
            ).ToListAsync();
        }

        public async Task<SpeakerDetailModel> GetSpeakerByIdAsync(int IdSpeaker)
        {
            SpeakerDetailModel speaker = await DbContext.Speaker.Select(
                    s => new SpeakerDetailModel
                    {
                        IdSpeaker = s.IdSpeaker,
                        FirstName = s.FirstName,
                        SecondName = s.SecondName,
                        FirstLastName = s.FirstLastName,
                        SecondLastName = s.SecondLastName,
                        TwitterLink = s.TwitterLink,
                        LinkedInLink = s.LinkedInLink,
                        PhotoLink = s.PhotoLink

                    })
                .FirstOrDefaultAsync(s => s.IdSpeaker == IdSpeaker);

            speaker.Sessions = await DbContext.SpeakerHasSession.Select(
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
            ).Where(s => s.IdSpeaker == IdSpeaker).ToListAsync();

            return speaker;

        }

        public async Task InsertSpeakerAsync(SpeakerDetailModel Speaker)
        {
            var entity = new Speaker()
            {
                FirstName = Speaker.FirstName,
                SecondName = Speaker.SecondName,
                FirstLastName = Speaker.FirstLastName,
                SecondLastName = Speaker.SecondLastName,
                TwitterLink = Speaker.TwitterLink,
                LinkedInLink = Speaker.LinkedInLink,
                PhotoLink = Speaker.PhotoLink,
                IdEvent = EventId.GetInstance().Id
            };

            DbContext.Speaker.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateSpeakerAsync(SpeakerDetailModel Speaker)
        {
            var entity = await DbContext.Speaker.FirstOrDefaultAsync(s => s.IdSpeaker == Speaker.IdSpeaker);

            entity.FirstName = Speaker.FirstName;
            entity.SecondName = Speaker.SecondName;
            entity.FirstLastName = Speaker.FirstLastName;
            entity.SecondLastName = Speaker.SecondLastName;
            entity.TwitterLink = Speaker.TwitterLink;
            entity.LinkedInLink = Speaker.LinkedInLink;
            entity.PhotoLink = Speaker.PhotoLink;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteSpeakerAsync(int IdSpeaker)
        {

            var entitySpeakerHasSession = new SpeakerHasSession()
            {
                IdSpeaker = IdSpeaker
            };

            DbContext.SpeakerHasSession.Attach(entitySpeakerHasSession);
            DbContext.SpeakerHasSession.Remove(entitySpeakerHasSession);
            await DbContext.SaveChangesAsync();

            var entity = new Speaker()
            {
                IdSpeaker = IdSpeaker
            };

            DbContext.Speaker.Attach(entity);
            DbContext.Speaker.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
