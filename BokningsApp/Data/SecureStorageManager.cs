using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace BokningsApp.Data
{
    public sealed class SecureStorageManager
    {
        private static readonly Lazy<SecureStorageManager> _instance = new(() => new());

        public static SecureStorageManager Instance => _instance.Value;

        private SecureStorageManager() { }

        public async Task SaveCredentialsAsync(string userId, string userEmail)
        {
            await SecureStorage.SetAsync("user_id", userId);
            await SecureStorage.SetAsync("user_email", userEmail);
        }

        public async Task<string> GetCredentialAsync(string key) =>
            await SecureStorage.GetAsync(key);

        public void RemoveCredentials()
        {
            SecureStorage.Remove("user_id");
            SecureStorage.Remove("user_email");
        }
    }
}