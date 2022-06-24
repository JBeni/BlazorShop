// <copyright file="MusicService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using MudBlazor;

namespace BlazorShop.WebClient.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;
        private readonly ISnackbar _snackBar;
        private readonly JsonSerializerOptions _options;

        public MusicService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<List<MusicResponse>> GetMusics()
        {
            var response = await _httpClient.GetAsync("Musics/musics");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Items;
        }

        /// <inheritdoc/>
        public async Task<MusicResponse> GetMusic(int id)
        {
            var response = await _httpClient.GetAsync($"Musics/music/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return null;
            }

            return result.Item;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddMusic(MusicResponse music)
        {
            var response = await _httpClient.PostAsJsonAsync("Musics/music", music);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Music was added.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateMusic(MusicResponse music)
        {
            var response = await _httpClient.PutAsJsonAsync("Musics/music", music);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Music was updated.", Severity.Success);
            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteMusic(int id)
        {
            var response = await _httpClient.DeleteAsync($"Musics/music/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _snackBar.Add(result.Error, Severity.Error);
                return result;
            }

            _snackBar.Add("The Music was deleted.", Severity.Success);
            return result;
        }
    }
}
