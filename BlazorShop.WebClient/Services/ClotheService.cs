// <copyright file="ClotheService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IClotheService"/>.
    /// </summary>
    public class ClotheService : IClotheService
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// .
        /// </summary>
        private readonly ISnackbar _snackBar;

        /// <summary>
        /// .
        /// </summary>
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="snackBar"></param>
        public ClotheService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<ClotheResponse>> GetClothes()
        {
            var response = await _httpClient.GetAsync("Clothes/clothes");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<ClotheResponse> GetClothe(int id)
        {
            var response = await _httpClient.GetAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClotheResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PostAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The clothe was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateClothe(ClotheResponse clothe)
        {
            var response = await _httpClient.PutAsJsonAsync("Clothes/clothe", clothe);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The clothe was updated.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteClothe(int id)
        {
            var response = await _httpClient.DeleteAsync($"Clothes/clothe/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                _snackBar.Add("The clothe was deleted.", Severity.Success);
            }

            return result;
        }
    }
}
