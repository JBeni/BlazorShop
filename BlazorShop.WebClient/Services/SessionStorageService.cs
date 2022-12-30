// <copyright file="SessionStorageService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="SessionStorageService"/>.
    /// </summary>
    public class SessionStorageService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStorageService"/> class.
        /// </summary>
        /// <param name="js">The instance of the <see cref="IJSRuntime"/> to use.</param>
        public SessionStorageService(IJSRuntime js)
        {
            this.Js = js;
            this.JsInProcess = (IJSInProcessRuntime)this.Js;
        }

        /// <summary>
        /// Gets the instance of the <see cref="IJSRuntime"/> to use..
        /// </summary>
        private IJSRuntime Js { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IJSInProcessRuntime"/> to use..
        /// </summary>
        private IJSInProcessRuntime JsInProcess { get; }

        /// <summary>
        /// Get an item from session storage.
        /// </summary>
        /// <typeparam name="T">The generic type of the object.</typeparam>
        /// <param name="key">The key to be added.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await this.Js.InvokeAsync<string>(
                "BlazorShop.getSessionStorage",
                key);

            return string.IsNullOrEmpty(json)
                    ? default
                    : JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Set an item to session storage - async.
        /// </summary>
        /// <typeparam name="T">The generic type of the object.</typeparam>
        /// <param name="key">The key to be added.</param>
        /// <param name="item">The item of type T.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SetItemAsync<T>(string key, T item)
        {
            await this.Js.InvokeVoidAsync(
                "BlazorShop.setSessionStorage",
                key,
                JsonSerializer.Serialize(item));
        }

        /// <summary>
        /// Set an item to session storage.
        /// </summary>
        /// <typeparam name="T">The generic type of the object.</typeparam>
        /// <param name="key">The key to be added.</param>
        /// <param name="item">The item of type T.</param>
        public void SetItem<T>(string key, T item)
        {
            this.JsInProcess.InvokeVoid(
                "BlazorShop.setSessionStorage",
                key,
                JsonSerializer.Serialize(item));
        }
    }
}
