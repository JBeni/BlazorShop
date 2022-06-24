// <copyright file="SessionStorageService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    public class SessionStorageService
    {
        private readonly IJSRuntime _js;
        private readonly IJSInProcessRuntime _jsInProcess;

        public SessionStorageService(IJSRuntime js)
        {
            _js = js;
            _jsInProcess = (IJSInProcessRuntime)_js;
        }

        /// <inheritdoc/>
        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string>(
                "BlazorShop.getSessionStorage",
                key);

            return string.IsNullOrEmpty(json)
                    ? default
                    : JsonSerializer.Deserialize<T>(json);
        }

        /// <inheritdoc/>
        public async Task SetItemAsync<T>(string key, T item)
        {
            await _js.InvokeVoidAsync(
                "BlazorShop.setSessionStorage",
                key,
                JsonSerializer.Serialize(item));
        }

        /// <inheritdoc/>
        public void SetItem<T>(string key, T item)
        {
            _jsInProcess.InvokeVoid(
                "BlazorShop.setSessionStorage",
                key,
                JsonSerializer.Serialize(item));
        }
    }
}
