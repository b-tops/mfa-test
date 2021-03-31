using System;
using System.Linq;

using Duende.IdentityServer.Models;
using MFATest.Models;


namespace MFATest.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _db;

        public AccountRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public Account GetAccount(string username, string password)
        {
            Account account = _db.Accounts.Local.SingleOrDefault(m => m.Username == username && m.EncryptedPassword == password.Sha256());
            return account;
        }

        public void InsertAccount(string username, string password, string phone, out Guid userGuid)
        {
            userGuid = Guid.NewGuid();
            _db.Accounts.Add(new Account()
            {
                UserGuid = userGuid,
                Username = username,
                EncryptedPassword = password.Sha256(),
                Phone = phone
            });
        }
    }
}
