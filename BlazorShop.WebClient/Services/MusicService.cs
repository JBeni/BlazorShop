namespace BlazorShop.WebClient.Services
{
    public class MusicService : IMusicService
    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;

        public MusicService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<MusicResponse>> GetMusics()
        {
            var authResult = await _httpClient.GetAsync("Musics/musics");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<MusicResponse>>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<MusicResponse> GetMusic(int id)
        {
            var authResult = await _httpClient.GetAsync($"Musics/music/{id}");
            if (authResult.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MusicResponse>(
                authContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result;
        }

        public async Task<RequestResponse> AddMusic(MusicResponse music)
        {
            var response = await _httpClient.PostAsJsonAsync("Musics/music", music);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Music was added.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateMusic(MusicResponse music)
        {
            var response = await _httpClient.PutAsJsonAsync("Musics/music", music);
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Music was updated.");
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMusic(int id)
        {
            var response = await _httpClient.DeleteAsync($"Musics/music/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                _toastService.ShowError("Something went wrong.");
                return null;
            }

            _toastService.ShowSuccess("The Music was deleted.");
            return RequestResponse.Success();
        }
    }
}
