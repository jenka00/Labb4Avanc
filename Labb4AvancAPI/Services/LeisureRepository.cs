using Labb4Avanc.Models;
using Labb4AvancAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Services
{
    public class LeisureRepository : ILabb4Avanc<Leisure>
    {
        private AppDbContext _appContext;

        public LeisureRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Leisure> Add(Leisure newEntity)
        {
            var result = await _appContext.Leisures.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Leisure> Delete(int id)
        {
            var result = await _appContext.Leisures.FirstOrDefaultAsync(l => l.LeisureId == id);
            if (result != null)
            {
                _appContext.Leisures.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Leisure>> GetAll()
        {
            return await _appContext.Leisures.ToListAsync();
        }

        public async Task<Leisure> GetSingle(int id)
        {
            return await _appContext.Leisures.FirstOrDefaultAsync(l => l.LeisureId == id);
        }

        public async Task<Leisure> PersonsInterests(int PersId)
        {
            return await _appContext.Leisures.FirstOrDefaultAsync(l => l.PersonId == PersId);
        }

        public async Task<Leisure> Update(Leisure Entity)
        {
            var result = await _appContext.Leisures.FirstOrDefaultAsync(l => l.LeisureId == Entity.LeisureId);
            if (result != null)
            {
                result.PersonId = Entity.PersonId;
                result.InterestId = Entity.InterestId;
                result.Url = Entity.Url;
                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}