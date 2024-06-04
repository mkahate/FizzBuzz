using FizzBuzzApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class FizzBuzzIntegrationTests : IClassFixture<WebApplicationFactory<FizzBuzzApp.Startup>>
{
    private readonly HttpClient _client;

    public FizzBuzzIntegrationTests(WebApplicationFactory<FizzBuzzApp.Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_ReturnsCorrectResults()
    {
        // Arrange
        var jsonData = "[1, 3, 5, 15, \"A\"]";
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


        // Act
        var response = await _client.PostAsync("/api/fizzbuzz", content);
        response.EnsureSuccessStatusCode();

        // Assert
        var responseString = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<List<string>>(responseString);

        Assert.NotNull(results);
        Assert.Equal(6, results.Count);
        Assert.Equal("Divided 1 by 3", results[0]);
        Assert.Equal("Divided 1 by 5", results[1]);
        Assert.Equal("Fizz", results[2]);
        Assert.Equal("Buzz", results[3]);
        Assert.Equal("FizzBuzz", results[4]);
        Assert.Equal("Invalid item", results[5]);
    }
}
