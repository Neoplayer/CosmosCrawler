using Newtonsoft.Json;

namespace NetSearch.Models;

public class AddrBookModel
{
    [JsonProperty("key")]
    public string Key { get; set; }

    [JsonProperty("addrs")]
    public AddrElement[] Addrs { get; set; }
}

public partial class AddrElement
{
    [JsonProperty("addr")]
    public SrcClass Addr { get; set; }

    [JsonProperty("src")]
    public SrcClass Src { get; set; }

    [JsonProperty("buckets")]
    public long[] Buckets { get; set; }

    [JsonProperty("attempts")]
    public long Attempts { get; set; }

    [JsonProperty("bucket_type")]
    public long BucketType { get; set; }

    [JsonProperty("last_attempt")]
    public DateTimeOffset LastAttempt { get; set; }

    [JsonProperty("last_success")]
    public DateTimeOffset LastSuccess { get; set; }

    [JsonProperty("last_ban_time")]
    public DateTimeOffset LastBanTime { get; set; }
}

public partial class SrcClass
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("ip")]
    public string Ip { get; set; }

    [JsonProperty("port")]
    public long Port { get; set; }
}
