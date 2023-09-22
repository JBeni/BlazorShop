// <copyright file="RoleService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IRoleService"/>.
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public RoleService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClient"/> to use.
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
        public async Task<RequestResponse> AddRole(RoleResponse role)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PostAsJsonAsync($"Roles/role", role));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The role was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteRole(int id)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.DeleteAsync($"Roles/role/{id}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The role was deleted.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RoleResponse> GetRole(int id)
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync($"Roles/role/{id}"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Item;
        }

        /// <inheritdoc/>
        public async Task<List<RoleResponse>> GetRoles()
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync("Roles/roles"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<List<RoleResponse>> GetRolesForAdmin()
        {
            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.GetAsync("Roles/rolesAdmin"));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }

            return !response.IsSuccessStatusCode
                ? null
                : result.Items;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> UpdateRole(RoleResponse role)
        {
            var data = new UpdateRoleCommand
            {
                Id = role.Id,
                Name = role.Name,
            };

            var response = await Policy<HttpResponseMessage>
                .Handle<Exception>()
                .WaitAndRetryAsync(2, _ => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () => await this.HttpClient.PutAsJsonAsync($"Roles/role", data));

            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The role was updated.", Severity.Success);
            }

            return result;
        }
    }
}
