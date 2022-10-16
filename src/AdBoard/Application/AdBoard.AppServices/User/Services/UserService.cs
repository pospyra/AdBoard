using AdBoard.AppServices.User.IRepository;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AdBoard
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public Task<User> GetCurrent(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string Login, string Password, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<int> Register(string Login, string Password, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
