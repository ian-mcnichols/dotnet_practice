// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream = await client.GetStreamAsync(
        "https://api.github.com/orgs/dotnet/repos");
    var respositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    foreach (var repo in respositories ?? Enumerable.Empty<Repository>())
        Console.Write(repo.Name, " \n");
}
