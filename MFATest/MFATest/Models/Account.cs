using System;
using System.ComponentModel.DataAnnotations;


namespace MFATest.Models
{
    public class Account
    {
        [Key]
        public Guid UserGuid { get; set; }

        public string Username { get; set; }
        public string EncryptedPassword { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        //public override bool Equals(Object obj)
        //{
        //    if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        Account account = (Account)obj;
        //        return (Username.ToString() == account.Username.ToString()) && (EncryptedPassword.ToString() == account.EncryptedPassword.ToString());
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return Username.GetHashCode() + EncryptedPassword.GetHashCode();
        //}
    }
}
