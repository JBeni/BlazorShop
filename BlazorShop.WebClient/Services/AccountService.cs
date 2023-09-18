// <copyright file="AccountService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IAccountService"/>.
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="System.Net.Http.HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public AccountService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.SnackBar = snackBar;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Gets the instance of the <see cref="ISnackbar"/> to use.
        /// </summary>
        private ISnackbar SnackBar { get; }

        /// <summary>
        /// Gets the instance of the <see cref="JsonSerializerOptions"/> to use.
        /// </summary>
        private JsonSerializerOptions Options { get; }

        /// <inheritdoc/>
        public async Task<RequestResponse> ChangePassword(ChangePasswordCommand command)
        {
            var response = await this.HttpClient.PutAsJsonAsync("Accounts/change-password", command);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The password was changed.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ResetPassword(ResetPasswordCommand command)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", command.Email),
                new KeyValuePair<string, string>("NewPassword", command.NewPassword),
                new KeyValuePair<string, string>("NewConfirmPassword", command.NewConfirmPassword),
            });

            var response = await this.HttpClient.PostAsync("Accounts/reset-password", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The password was reset.", Severity.Success);
            }

            return result;
        }
    }
}
