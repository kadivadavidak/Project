using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NoteTaker.Models
{
	public class UserAccount
	{
		private static readonly SHA256Managed hasher = new SHA256Managed();
		private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

		public string Username { get; set; }
		
		public string Salt { get; set; }

		public byte[] PasswordHash { get; set; }

		public static UserAccount Create(string username, string password)
		{
			var salt = new byte[16];
			rng.GetBytes(salt);
			var stringSalt = Convert.ToBase64String(salt);
			var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(stringSalt + password));
			return new UserAccount { Username = username, Salt = stringSalt, PasswordHash = hash};
		}

		public bool VerifyPassword(string password)
		{
			var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(Salt + password));
			return hash.SequenceEqual(PasswordHash);
		}
	}
}