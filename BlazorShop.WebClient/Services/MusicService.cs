namespace BlazorShop.WebClient.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private readonly JsonSerializerOptions _options;

        public MusicService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<MusicResponse>> GetMusics()
        {
            var response = await _httpClient.GetAsync("Musics/musics");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Items;
        }

        public async Task<MusicResponse> GetMusic(int id)
        {
            var response = await _httpClient.GetAsync($"Musics/music/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<MusicResponse>>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return null;
            }

            return result.Item;
        }

        public async Task<RequestResponse> AddMusic(MusicResponse music)
        {
            var response = await _httpClient.PostAsJsonAsync("Musics/music", music);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Music was added.");
            return result;
        }

        public async Task<RequestResponse> UpdateMusic(MusicResponse music)
        {
            var response = await _httpClient.PutAsJsonAsync("Musics/music", music);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Music was updated.");
            return result;
        }

        public async Task<RequestResponse> DeleteMusic(int id)
        {
            var response = await _httpClient.DeleteAsync($"Musics/music/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, _options
            );

            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError(result.Error);
                return result;
            }

            _toastService.ShowSuccess("The Music was deleted.");
            return result;
        }
    }
}
