// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var repos = await ProcessRepositoriesAsync(client);

foreach (var repo in repos) {
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"Github: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers}");
    Console.WriteLine("==============================");
}

static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream = await client.GetStreamAsync(
        "https://api.github.com/orgs/dotnet/repos");
    var respositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    return respositories ?? new();    
}
