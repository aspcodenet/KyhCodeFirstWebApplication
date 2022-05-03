using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KyhCodeFirstWebApplication.Services;

public interface IKrisInfoService
{
    List<KrisInfo> GetLatest();
}

public class KrisInfoService : IKrisInfoService
{
    private readonly IOptions<KrisInfoSettings> _settings;

    public KrisInfoService(IOptions<KrisInfoSettings> settings)
    {
        _settings = settings;
    }
    public List<KrisInfo> GetLatest()
    {
        var httpClient = new HttpClient();
        var data = httpClient.GetStringAsync(
            _settings.Value.Url).Result;

        return JsonConvert.DeserializeObject<List<KrisInfo>>(data);
    }
}

public class KrisInfo
{
    public string Identitifer { get; set; }
    public string BodyText { get; set; }
    public string Headline { get; set; }
    public string Language { get; set; }
}

public class KrisInfoSettings
{
    public string Url { get; set; }
    public int MaxAntal { get; set; }
}
