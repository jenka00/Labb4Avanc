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
            this._appContext = appContext;
        }
        public async Task<Leisure> Add(Leisure newEntity)
        {
            var result = await _appContext.Leisures.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Leisure> Delete(int id)
        {
            var result = await _appContext.Leisures.FirstOrDefaultAsync(p => p.PersonId == id);
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
            return await _appContext.Leisures.FirstOrDefaultAsync(i => i.PersonId == id);
        }

        public async Task<Leisure> Update(Leisure Entity)
        {
            var result = await _appContext.Leisures.FirstOrDefaultAsync(p => p.PersonId == Entity.PersonId);
            if (result != null)
            {
                result.PersonId = Entity.PersonId;

                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
