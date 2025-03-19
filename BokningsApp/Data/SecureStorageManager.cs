using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.Data
{
    public sealed class SecureStorageManager
    {
        private static readonly Lazy<SecureStorageManager> _instance =
            new Lazy<SecureStorageManager>(() => new SecureStorageManager());

        public static SecureStorageManager Instance => _instance.Value;

        private SecureStorageManager() { }

        public async Task SaveUserCredentialsAsync(string userId, string userEmail)
        {
            await SecureStorage.SetAsync("user_id", userId);
            await SecureStorage.SetAsync("user_email", userEmail);
        }

        public async Task<string> GetUserIdAsync()
        {
            return await SecureStorage.GetAsync("user_id");
        }

        public async Task<string> GetUserEmailAsync()
        {
            return await SecureStorage.GetAsync("user_email");
        }

        public void RemoveUserCredentials()
        {
            SecureStorage.Remove("user_id");
            SecureStorage.Remove("user_email");
        }
    }
}
