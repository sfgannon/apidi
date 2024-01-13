public class BasicService : IBasicService
{
    private readonly HttpClient _client;
    public BasicService(HttpClient client) {
        _client = client;
    }
    public async Task<string> GetString() {
        return "okay";
    }
}