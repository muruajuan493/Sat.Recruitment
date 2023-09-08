using Sat.Recruitment.Api;
using Sat.Recruitment.Core.DTOs.Requests.User;
using Sat.Recruitment.Core.DTOs.Responses.User;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Sat.Recruitment.FunctionalTests.Controllers
{
    public class UsersControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UsersControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Test1_GetUserById()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var request = new HttpRequestMessage(HttpMethod.Post, "/Users/get-user")
            {
                Content = new StringContent(JsonSerializer.Serialize(new DtoGetUserRequest() { IdUser = 1 }), Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(request);
            var bodyResponse = await TestHelpers.GetJsonContentAsync<DtoGetUserResponse>(response);

            // Assert.
            TestHelpers.AssertResponseWithContent(stopwatch, response, expectedStatusCode);

            Assert.Equal(1, bodyResponse?.User.Id);
            Assert.Equal("Juan", bodyResponse?.User.Name);
            Assert.Equal("Juan@marmol.com", bodyResponse?.User.Email);
            Assert.Equal("Peru 2464", bodyResponse?.User.Address);
            Assert.Equal("+5491154762312", bodyResponse?.User.Phone);
            Assert.Equal("Normal", bodyResponse?.User.UserType);
            Assert.Equal("1234", bodyResponse?.User.Money.ToString());
        }

        [Fact]
        public async Task Test2_GetAllUsers()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var request = new HttpRequestMessage(HttpMethod.Post, "/Users/get-users")
            {
                Content = new StringContent(JsonSerializer.Serialize(new DtoGetUsersRequest() { }), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(request);

            var bodyResponse = await TestHelpers.GetJsonContentAsync<DtoGetUsersResponse>(response);

            // Assert.
            TestHelpers.AssertResponseWithContent(stopwatch, response, expectedStatusCode);

            Assert.Equal(3, bodyResponse.Users.Count);
            Assert.Contains(bodyResponse.Users, i => i.Email == SeedData.User1.Email);
            Assert.Contains(bodyResponse.Users, i => i.Email == SeedData.User2.Email);
            Assert.Contains(bodyResponse.Users, i => i.Email == SeedData.User3.Email);
        }

        [Fact]
        public async Task Test3_CreateNewUser()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var stopwatch = Stopwatch.StartNew();

            // Act.
            var request = new HttpRequestMessage(HttpMethod.Post, "/Users/create-user")
            {
                Content = new StringContent(JsonSerializer.Serialize(new DtoCreateUserRequest()
                {
                    Name = "Juan Pablo",
                    Email = "juan.pablo.99@gmail.com",
                    Address = "Algun lugar",
                    Phone = "+5491231234567",
                    UserType = "Premium",
                    Money = "500000"
                }), Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(request);
            var bodyResponse = await TestHelpers.GetJsonContentAsync<DtoCreateUserResponse>(response);

            // Assert.
            TestHelpers.AssertResponseWithContent(stopwatch, response, expectedStatusCode);

            Assert.Equal(4, bodyResponse?.User.Id);
            Assert.Equal("Juan Pablo", bodyResponse?.User.Name);
            Assert.Equal("juanpablo99@gmail.com", bodyResponse?.User.Email);
            Assert.Equal("Algun lugar", bodyResponse?.User.Address);
            Assert.Equal("+5491231234567", bodyResponse?.User.Phone);
            Assert.Equal("Premium", bodyResponse?.User.UserType);
            Assert.Equal("1000000", bodyResponse?.User.Money.ToString());
        }
    }
}
