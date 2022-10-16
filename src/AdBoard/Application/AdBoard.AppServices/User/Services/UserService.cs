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

        public async Task<string> Login(string Login, string Password, CancellationToken cancellation)
        {
            //TODO
            return "secretKey";


            throw new NotImplementedException();
        }

        public async Task<int> Register(string Login, string Password, CancellationToken cancellation)
        {

            //TODO
            return 1;

            throw new NotImplementedException();
        }
    }
}
