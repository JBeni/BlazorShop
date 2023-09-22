// <copyright file="_Imports.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

global using System.Net;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Runtime.Serialization;
global using System.Security.Claims;
global using System.Text.Json;

global using Blazored.LocalStorage;
global using Blazored.Toast;
global using Blazored.Toast.Services;
global using BlazorShop.Application.Commands.AccountCommand;
global using BlazorShop.Application.Commands.RoleCommand;
global using BlazorShop.Application.Commands.UserCommand;
global using BlazorShop.Application.Common.Models;
global using BlazorShop.Application.Responses;
global using BlazorShop.Application.Utils;
global using BlazorShop.WebClient;
global using BlazorShop.WebClient.Auth;
global using BlazorShop.WebClient.AuthPolicies;
global using BlazorShop.WebClient.Interceptor;
global using BlazorShop.WebClient.Interfaces;
global using BlazorShop.WebClient.Services;
global using BlazorShop.WebClient.Shared;
global using MatBlazor;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.JSInterop;
global using MudBlazor;
global using MudBlazor.Services;
global using Polly;
global using Serilog;
global using Toolbelt.Blazor;
global using Toolbelt.Blazor.Extensions.DependencyInjection;
