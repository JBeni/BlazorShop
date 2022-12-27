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
        public RoleService(HttpClient httpClient, ISnackbar snackBar)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _snackBar = snackBar;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> AddRole(RoleResponse role)
        {
            var response = await _httpClient.PostAsJsonAsync($"Roles/role", role);
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
                _snackBar.Add("The role was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteRole(int id)
        {
            var response = await _httpClient.DeleteAsync($"Roles/role/{id}");
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
                _snackBar.Add("The role was deleted.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RoleResponse> GetRole(int id)
        {
            var response = await _httpClient.GetAsync($"Roles/role/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
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
        public async Task<List<RoleResponse>> GetRoles()
        {
            var response = await _httpClient.GetAsync("Roles/roles");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
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
        public async Task<List<RoleResponse>> GetRolesForAdmin()
        {
            var response = await _httpClient.GetAsync("Roles/rolesAdmin");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<RoleResponse>>(
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
        public async Task<RequestResponse> UpdateRole(RoleResponse role)
        {
            var data = new UpdateRoleCommand
            {
                Id = role.Id,
                Name = role.Name,
            };
            var response = await _httpClient.PutAsJsonAsync($"Roles/role", data);
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
                _snackBar.Add("The role was updated.", Severity.Success);
            }

            return result;
        }
    }
}
