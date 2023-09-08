using System.Diagnostics;
using System.Net.Http.Json;
using System.Reflection;

namespace Sat.Recruitment.FunctionalTests
{
    public static class TestHelpers
    {
        private const string _jsonMediaType = "application/json";
        private const int _expectedMaxElapsedMilliseconds = 6000;
        //private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        public static void AssertResponseWithContent(
            Stopwatch stopwatch,
            HttpResponseMessage response,
            System.Net.HttpStatusCode expectedStatusCode
        )
        {
            AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
            Assert.Equal(_jsonMediaType, response.Content.Headers.ContentType?.MediaType);
        }

        private static void AssertCommonResponseParts(
            Stopwatch stopwatch,
            HttpResponseMessage response, 
            System.Net.HttpStatusCode expectedStatusCode
        )
        {
            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.True(stopwatch.ElapsedMilliseconds < _expectedMaxElapsedMilliseconds);
        }

        public static async Task<T?> GetJsonContentAsync<T>(HttpResponseMessage response)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
