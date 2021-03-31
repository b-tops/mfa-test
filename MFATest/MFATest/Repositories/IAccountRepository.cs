using System;

using MFATest.Models;


namespace MFATest.Repositories
{
    public interface IAccountRepository
    {
        Account GetAccount(string username, string password);
        void InsertAccount(string username, string password, string phone, out Guid userGuid);
    }
}
