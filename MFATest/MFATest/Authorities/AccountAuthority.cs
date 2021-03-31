using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

using MFATest.Repositories;


namespace MFATest.Authorities
{
    public class AccountAuthority : IAuthority
    {
        private IAccountRepository _repository;

        public AccountAuthority(IAccountRepository repository)
        {
            _repository = repository;
        }

        public string[] Payload => new string[] { "username", "password" };

        public Claim[] OnForward(Claim[] claims)
        {
            throw new NotImplementedException();
        }

        public Claim[] OnVerify(Claim[] claims, JsonDocument payload, string identifier, out bool valid)
        {
            valid = false;
            var user = _repository.GetAccount(payload.RootElement.GetProperty("username").GetString(), payload.RootElement.GetProperty("password").GetString());
            if (user == null)
                throw new KeyNotFoundException();
            valid = true;
            return new Claim[]
            {
          new Claim(identifier, user.UserGuid.ToString()),
          new Claim("phone", user.Phone)
            };
        }
    }
}
