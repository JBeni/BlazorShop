namespace BlazorShop.WebClient.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public AccountService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<RequestResponse> ChangePassword(ChangePasswordCommand command)
        {
            var response = await _httpClient.PutAsJsonAsync("Accounts/change-password", command);
            var responseResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            _toastService.ShowSuccess("The password was changed.");
            return result;
        }

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
            if (response.IsSuccessStatusCode == false)
            {
                var resultError = JsonSerializer.Deserialize<ErrorView>(
                    responseResult,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                var errorMessage = resultError.Successful == false ? resultError.Error : resultError.Title + ": " + resultError.Detail;
                _toastService.ShowError(errorMessage);
                return null;
            }

            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            _toastService.ShowSuccess("The password was reset.");
            return result;
        }
    }
}
