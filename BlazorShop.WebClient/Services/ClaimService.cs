// <copyright file="ClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IClaimService"/>.
    /// </summary>
    public class ClaimService : IClaimService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimService"/> class.
        /// </summary>
        /// <param name="httpClient">The instance of the <see cref="System.Net.Http.HttpClient"/> to use.</param>
        /// <param name="snackBar">The instance of the <see cref="ISnackbar"/> to use.</param>
        public ClaimService(HttpClient httpClient, ISnackbar snackBar)
        {
            this.HttpClient = httpClient;
            this.Options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            this.SnackBar = snackBar;
        }

        /// <summary>
        /// Gets the instance of the <see cref="System.Net.Http.HttpClient"/> to use.
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
        public async Task<RequestResponse> AddClaim(ClaimResponse claim)
        {
            var response = await this.HttpClient.PostAsJsonAsync($"Claims/Claim", claim);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Claim was added.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RequestResponse> DeleteClaim(int id)
        {
            var response = await this.HttpClient.DeleteAsync($"Claims/Claim/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Claim was deleted.", Severity.Success);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ClaimResponse> GetClaim(int id)
        {
            var response = await this.HttpClient.GetAsync($"Claims/Claim/{id}");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClaimResponse>>(
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
        public async Task<List<ClaimResponse>> GetClaims()
        {
            var response = await this.HttpClient.GetAsync("Claims/Claims");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Result<ClaimResponse>>(
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
        public async Task<RequestResponse> UpdateClaim(ClaimResponse claim)
        {
            var data = new UpdateClaimCommand
            {
                Id = claim.Id,
                Value = claim.Value,
                Type = claim.Type,
            };

            var response = await this.HttpClient.PutAsJsonAsync($"Claims/Claim", data);
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RequestResponse>(
                responseResult, this.Options);

            if (response.IsSuccessStatusCode == false)
            {
                this.SnackBar.Add(result.Error, Severity.Error);
            }
            else
            {
                this.SnackBar.Add("The Claim was updated.", Severity.Success);
            }

            return result;
        }
    }
}
