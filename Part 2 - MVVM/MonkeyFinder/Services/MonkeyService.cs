using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public partial class MonkeyService
{
    #region Members

    List<Monkey> MonkeyList = new();
    HttpClient client;

    #endregion

    #region Constructor
    public MonkeyService()
    {
        client = new HttpClient();
    }
    #endregion

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (MonkeyList?.Count != 0) return MonkeyList;

        var url = "https://montemagno.com/monkeys.json";
        try
        {

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //Deserialize the string- 'response'
                MonkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();

            }
        }
        catch
        {

            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            MonkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);

        }


        return MonkeyList;
    }
}
