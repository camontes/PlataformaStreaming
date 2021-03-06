﻿using Newtonsoft.Json;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using SampleAPI.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class UsersControllerFunctionalTest : WebTest
    {
        [Fact]
        public async Task Get_ReturnsSeededList()
        {
            // Execute
            var response = await _client.GetAsync(Endpoints.USERS);
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(SeedExtensions.UsersSeed.Serialize(), content);
        }

        [Fact]
        public async Task GetByUsername_UnexistingUser_ReturnsError()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.USERS}/unknown");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetByUsername_User_ReturnsUser()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{Endpoints.USERS}/{SeedExtensions.UsersSeed.FirstOrDefault().Username}");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(SeedExtensions.UsersSeed.FirstOrDefault().Serialize(), content);
        }

        [Fact]
        public async Task Create_WithoutUsername_ReturnsError()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Name = "something@nothing.com"
            };

            // Execute
            var response = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsUser()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Username = "Mr. ejemplo",
                Name = "ejemplo.",
                Photo = "photo.jpg",
            };

            // Execute
            var responseCreate = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var contentCreate = await responseCreate.Content.ReadAsStringAsync();

            // Check
            var expectedBasicUser = new BasicUserViewModel
            {
                Username = createUserCommand.Username,
                Name = createUserCommand.Name,
                Photo=createUserCommand.Photo,
                IsActive = true
            };
            Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
            Assert.Equal(expectedBasicUser.Serialize(), contentCreate);

        }

        [Fact]
        public async Task Create_UserAndThenQuerying_ReturnsUser()
        {
            // Prepare
            var createUserCommand = new CreateUserCommand
            {
                Username = "MrTest",
            };

            // Execute
            var responseCreate = await _client.PostAsJsonAsync(Endpoints.USERS, createUserCommand);
            var contentCreate = await responseCreate.Content.ReadAsStringAsync();

            var responseGetByUsername = await _client.GetAsync(
                $"{Endpoints.USERS}/{createUserCommand.Username}");
            var resultUser = JsonConvert.DeserializeObject<User>(await responseGetByUsername.Content.ReadAsStringAsync());

            // Check
            // Creation
            var expectedBasicUser = new BasicUserViewModel
            {
                Username = createUserCommand.Username,
                IsActive = true
            };
            Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
            Assert.Equal(expectedBasicUser.Serialize(), contentCreate);

            // GetByUsername
            Assert.Equal(HttpStatusCode.OK, responseGetByUsername.StatusCode);
            Assert.Equal(createUserCommand.Username, resultUser.Username);
        }


        [Fact]
        public async Task Delete_WithoutUsername_ReturnsError()
        {
            // Execute
            var response = await _client.DeleteAsync(
                $"{Endpoints.USERS}/unknown");


            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task Update_username()
        {
            // Prepare
            var updateUserCommand = new UpdateUserCommand
            {
                IsActive = true,
                Email = "hola@hotmail.com"
            };

            // Execute
            var responseUpdate = await _client.PutAsJsonAsync($"{Endpoints.USERS}/{SeedExtensions.UsersSeed.FirstOrDefault().Username}", updateUserCommand);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);

        }


        [Fact]
        public async Task Update_WithoutUsername_ReturnsError()
        {
            // Prepare
            var updateUserCommand = new UpdateUserCommand
            {
                IsActive = true,
                Email = "hola@hotmail.com"
            };

            // Execute
            var responseUpdate = await _client.PutAsJsonAsync($"{Endpoints.USERS}/unknown", updateUserCommand);

            Assert.Equal(HttpStatusCode.NotFound, responseUpdate.StatusCode);

        }

        [Fact]
        public async Task Delete_username()
        {
            // Execute
            var response = await _client.DeleteAsync(
                 $"{Endpoints.USERS}/{SeedExtensions.UsersSeed.FirstOrDefault().Username}");


            // Check
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
