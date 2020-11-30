using Clarika.Examen.Tecnico.Config;
using Clarika.Examen.Tecnico.Helpers;
using Clarika.Examen.Tecnico.Models;
using Clarika.Examen.Tecnico.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Clarika.Examen.Tecnico.Services
{
    public class UserService : IUserService
    {

        ILogger<UserService> _logger;
        IEnumerable<User> _users;
        IHttpClientHelper _httpClientHelper;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public UserService(IHttpClientHelper httpClientHelper, ILogger<UserService> logger = null )
        {
            this._logger = logger;
            this._httpClientHelper = httpClientHelper;
            this._users = new List<User>();
        }

        public async Task<User> GetUserAsync(string id)
        {
            _logger?.LogInformation($"GetUser {id}");

            if (!string.IsNullOrEmpty(id) && IsConnected)
            { 
                var userList =  await _httpClientHelper.GetObjects<List<User>>(string.Format(UserUrl.UsersDetail, id));

                return userList.FirstOrDefault();

            }

            return null;
        }

        public async Task<IEnumerable<User>> GetUserAllAsync()
        {
            _logger?.LogInformation($"GetUserAll ");

            if (  IsConnected)
            {
                _users =  await _httpClientHelper.GetObjects<IEnumerable<User>>(string.Format(UserUrl.Users));

            }

            return _users;
            
        }
    }
}
