// <copyright file="_Imports.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

global using System.Net.Mail;
global using System.Reflection;

global using AutoMapper;
global using AutoMapper.QueryableExtensions;
global using BlazorShop.Application.Commands.AccountCommand;
global using BlazorShop.Application.Commands.CartCommand;
global using BlazorShop.Application.Commands.ClotheCommand;
global using BlazorShop.Application.Commands.InvoiceCommand;
global using BlazorShop.Application.Commands.MusicCommand;
global using BlazorShop.Application.Commands.OrderCommand;
global using BlazorShop.Application.Commands.ReceiptCommand;
global using BlazorShop.Application.Commands.RoleCommand;
global using BlazorShop.Application.Commands.SubscriberCommand;
global using BlazorShop.Application.Commands.SubscriptionCommand;
global using BlazorShop.Application.Commands.TodoItemCommand;
global using BlazorShop.Application.Commands.TodoListCommand;
global using BlazorShop.Application.Commands.UserCommand;
global using BlazorShop.Application.Common.Behaviours;
global using BlazorShop.Application.Common.Interfaces;
global using BlazorShop.Application.Common.Mappings;
global using BlazorShop.Application.Common.Models;
global using BlazorShop.Application.Queries.CartQuery;
global using BlazorShop.Application.Queries.ClotheQuery;
global using BlazorShop.Application.Queries.InvoiceQuery;
global using BlazorShop.Application.Queries.MusicQuery;
global using BlazorShop.Application.Queries.OrderQuery;
global using BlazorShop.Application.Queries.ReceiptQuery;
global using BlazorShop.Application.Queries.RoleQuery;
global using BlazorShop.Application.Queries.SubscriberQuery;
global using BlazorShop.Application.Queries.SubscriptionQuery;
global using BlazorShop.Application.Queries.TodoItemQuery;
global using BlazorShop.Application.Queries.TodoListQuery;
global using BlazorShop.Application.Queries.UserQuery;
global using BlazorShop.Application.Responses;
global using BlazorShop.Application.Utils;
global using BlazorShop.Domain.Entities;
global using BlazorShop.Domain.Entities.Identity;
global using BlazorShop.Domain.Enums;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
