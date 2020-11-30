using Clarika.Examen.Tecnico.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Clarika.Examen.Tecnico.Services.Interfaces
{
    public interface IUserService
    {
       
        Task<User> GetUserAsync(string id);
        Task<IEnumerable<User>> GetUserAllAsync();
    }
}
