using CleanArchi.Client.Identity.Models;

namespace CleanArchi.Client.Identity
{
    /// <summary>
    /// Account management services.
    /// </summary>
    public interface IAccountManagement
    {
        /// <summary>
        /// Login service.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The result of the request serialized to <see cref="FormResult"/>.</returns>
        public Task<FormResult> LoginAsync(string email, string password);/// <summary>
        /// Login service.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <param name="password">User's password.</param
        /// <param name="code">User's 2FA Code.</param>
        /// <returns>The result of the request serialized to <see cref="FormResult"/>.</returns>
        public Task<FormResult> Login2FAAsync(string email, string password, string code);

        /// <summary>
        /// Log out the logged in user.
        /// </summary>
        /// <returns>The asynchronous task.</returns>
        public Task LogoutAsync();

        /// <summary>
        /// Registration service.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <param name="password">User's password.</param>
        /// <returns>The result of the request serialized to <see cref="FormResult"/>.</returns>
        public Task<FormResult> RegisterAsync(string email, string password);

        public Task<bool> CheckAuthenticatedAsync();

        public Task<string> GetData2FA();

        public Task Enable2FA(string code);
    }
}
