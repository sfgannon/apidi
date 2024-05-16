using ApiDi.Classes;

public interface IBasicService
{
    public Task<string> GetString();
    public Task<string> GetApi();
    public Task<string> ApiCall();
    }