using System;
using System.Collections.Generic;
using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;
using MiniHub.Data.LiteDb;
using System.Linq;

namespace MiniHub.Services
{
    public class FirmService : IFirmService
    {
        private readonly DatabaseContext _databaseContext;

        public FirmService(DatabaseContext db)
        {
            _databaseContext = db;
        }
        
        public Firm GetViaId(Guid id)
        {
            return _databaseContext.Find<Firm>(f => f.Id == id).FirstOrDefault();
        }

        public Firm CreateNew(CreateFirmDto dto)
        {
            var newFirm = new Firm
            {
                Id = Guid.NewGuid(),
                Reference = dto.Reference,
                IsExternal = dto.IsExternal,
                ExternalHubId = dto.ExternalHubId
            };

            _databaseContext.PushSomethingIntoDb(newFirm);
            
            return newFirm;
        }

        public List<Firm> GetAll()
        {
            var firmList = new List<Firm>();

            try
            {
                var firms = _databaseContext.GetList<Firm>();

                firmList = firms.ToList();
            }
            catch (Exception e)
            {
                // DO NOTHING
            }

            return firmList;
        }

        public bool Delete(Guid firmId)
        {
            var firm = GetViaId(firmId);

            if (firm == null)
            {
                return false;
            }

            try
            {
                _databaseContext.DeleteFromDb<Firm>(x => x.Id == firmId);
            }
            catch (Exception e)
            {
                // OH NOES
            }

            return true;
        }
    }
}