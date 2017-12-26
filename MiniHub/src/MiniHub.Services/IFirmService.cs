using System;
using System.Collections.Generic;
using MiniHub.Data.Entities;
using MiniHub.Services.Dtos;

namespace MiniHub.Services
{
    public interface IFirmService
    {
        Firm CreateNew(CreateFirmDto dto);
        bool Delete(Guid firmId);
        List<Firm> GetAll();
        Firm GetViaId(Guid id);
    }
}