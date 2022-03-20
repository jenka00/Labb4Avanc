using Labb4Avanc.Models;
using Labb4AvancAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Services
{
    public class PersonRepository : ILabb4Avanc<Person>
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            this._appContext = appContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _appContext.Persons.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _appContext.Persons.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.Persons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _appContext.Persons.FirstOrDefaultAsync(i => i.PersonId == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == Entity.PersonId);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Phone = Entity.Phone;
                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
