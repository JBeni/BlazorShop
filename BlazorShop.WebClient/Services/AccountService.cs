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
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public AccountService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _snackBar = snackBar;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> ChangePassword(ChangePasswordCommand command)
        {
            var response = await _httpClient.PutAsJsonAsync("Accounts/change-password", command);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The password was changed.", Severity.Success);
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

            var response = await _httpClient.PostAsync("Accounts/reset-password", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The password was reset.", Severity.Success);
            return result;
        }
    }
}
