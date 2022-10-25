using AdBoard.AppServices.User.IRepository;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AdBoard.AppServices;
using System.Linq.Expressions;
using AdBoard.AppServices.Ad.Repositories;

namespace AdBoard
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _userRepository.DeleteAsync(id, cancellation);
        }

        public async Task<string> Login(string login, string password, CancellationToken cancellation)
        {

            var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellation); ;

            if (existingUser == null)
            {
                throw new Exception($"Пользователz с логином '{login}' не существует");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception($"Указан не верный логин или пароль");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Name, existingUser.Login),
                new Claim(ClaimTypes.Email, existingUser.Email),
            };

            var securatyKey = "secretKeysecretKeysecretKeysecretKeysecretKeysecretKey";

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securatyKey)),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Guid> Register(string login, string name, string password, string number, string email, string region, CancellationToken cancellation)
        {
            var user = new Users
            {
                Login = login,
                Name = name,
                Password = password,
                CreateDate = DateTime.UtcNow,
                Number = number,
                Email = email,
                Region = region
            };

            var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellation); ;
            if (existingUser != null)
            {
                throw new Exception($"Пользователь с логином '{login}' уже существует");
            }

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public Task EditAsync(Guid id, string name, string login, string password, string number, string email, string region)
        {
            return _userRepository.EditAsync(id, name, login, password, number, email, region);
        }

       
    }

}
