using Labb4Avanc.Models;
using Labb4AvancAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Services
{
    public class InterestRepository : ILabb4Avanc<Interest>
    {
        private AppDbContext _appContext;

        public InterestRepository(AppDbContext appContext)
        {
            this._appContext = appContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appContext.Interests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestId == id);
            if (result != null)
            {
                _appContext.Interests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }       

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _appContext.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
        }        

        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(i => i.InterestId == Entity.InterestId);
            if (result != null)
            {
                result.InterestTitle = Entity.InterestTitle;
                result.InterestDescription = Entity.InterestDescription;               
                
                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
