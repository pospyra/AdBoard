using AdBoard.AppServices.User.IRepository;
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
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using SelectedAd.Contracts.User;

namespace AdBoard
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClaimsAccessor _claimAccessor;
        private readonly IConfiguration _configuration;
        public UserService(
            IUserRepository userRepository, 
            IClaimsAccessor claimAccessor,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _claimAccessor = claimAccessor;
            _configuration = configuration;
        }

        public async Task<Guid> Registration(UserRegister model)
        {

            Users user = new Users
            {
                Name = model.Name,
                Login = model.Login,
                Password = model.Password,
                Number = model.Number,
                Email = model.Email,
                Region = model.Region
               // CreateDate = DateTime.Now
            };
            
            var existingUser = await _userRepository.FindWhere(user => user.Login == model.Login); ;
            if (existingUser != null)
            {
                throw new Exception (  $"Пользователь с логином '{model.Login}' уже существует");
            }
            
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return _userRepository.DeleteAsync(id, cancellation);
        }


        public async Task<string> Login(UserLogin userLogin)
        {
            var existingUser = await _userRepository.FindWhere(user => user.Login == userLogin.Login); ;

            if (existingUser == null)
            {
                throw new Exception($"Пользователь с логином '{userLogin.Login}' не существует");
            }

            if (!existingUser.Password.Equals(userLogin.Password))
            {
                throw new Exception($"Указан неверный логин или пароль" );
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Name, existingUser.Login)
               // new Claim(ClaimTypes.Email, existingUser.Email)
            };

            var secretKey = _configuration["Token:SecretKey"];

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        public Task EditAsync(Guid id, string name, string login, string password, string number, string email, string region)
        {
            return _userRepository.EditAsync(id, name, login, password, number, email, region);
        }

        public async Task<Users> GetCurrent(CancellationToken cancellation)
        {
            var claim = await _claimAccessor.GetClaims(cancellation);
            var claimId = claim.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(claimId))
            {
                return null;
            }

            var id = Guid.Parse(claimId);
            var user = await _userRepository.FindById(id, cancellation);

            if (user == null)
            {
                throw new Exception($"Не найдент пользователь с идентификаторром {id}");
            }

            return user;
        }

        public async Task<Guid> GetCurrentUserId(CancellationToken cancellation)
        {
            var claim = await _claimAccessor.GetClaims(cancellation);
            var claimId = claim.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(claimId))
            {
                throw new Exception("Не найдент пользователь с идентификаторром");
            }

            var id = Guid.Parse(claimId);
            var user = await _userRepository.FindById(id, cancellation);

            if (user == null)
            {
                throw new Exception($"Не найдент пользователь с идентификаторром {id}");
            }

            return user.Id;
        }


        public Task<IReadOnlyCollection<UserDto>> GetUsers(CancellationToken cancellation)
        {
            return _userRepository.GetAll(cancellation);
        }

        //старый логин
        public async Task<string> Login(string login, string password)
        {

            var existingUser = await _userRepository.FindWhere(user => user.Login == login); ;

            if (existingUser == null)
            {
                throw new Exception($"Пользователь с логином '{login}' не существует");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception($"Указан не верный логин или пароль");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Name, existingUser.Login)
               // new Claim(ClaimTypes.Email, existingUser.Email)
            };

            var secretKey = _configuration["Token:SecretKey"];

            var token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256
                    )
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        //старый регистр
        public async Task<Guid> Register(string name, string login, string password, string number, string email, string region)
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

            var existingUser = await _userRepository.FindWhere(user => user.Login == login); ;
            if (existingUser != null)
            {
                throw new Exception($"Пользователь с логином '{login}' уже существует");
            }

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async  Task<Users> GetById(Guid id, CancellationToken cancellation)
        {
            return await _userRepository.FindById(id, cancellation);
        }
    }

}
