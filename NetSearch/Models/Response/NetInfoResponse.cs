using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetSearch.Models.Response;


public partial class NetInfoResponse
{
    [JsonProperty("jsonrpc")]
    public string Jsonrpc { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("result")]
    public Result Result { get; set; }
}

public partial class Result
{
    [JsonProperty("listening")]
    public bool Listening { get; set; }

    [JsonProperty("listeners")]
    public string[] Listeners { get; set; }

    [JsonProperty("n_peers")]
    public long NPeers { get; set; }

    [JsonProperty("peers")]
    public Peer[] Peers { get; set; }
}

public partial class Peer
{
    [JsonProperty("node_info")]
    public NodeInfo NodeInfo { get; set; }

    [JsonProperty("is_outbound")]
    public bool IsOutbound { get; set; }

    [JsonProperty("connection_status")]
    public ConnectionStatus ConnectionStatus { get; set; }

    [JsonProperty("remote_ip")]
    public string RemoteIp { get; set; }
}

public partial class ConnectionStatus
{
    [JsonProperty("Duration")]
    public string Duration { get; set; }

    [JsonProperty("SendMonitor")]
    public Monitor SendMonitor { get; set; }

    [JsonProperty("RecvMonitor")]
    public Monitor RecvMonitor { get; set; }

    [JsonProperty("Channels")]
    public Channel[] Channels { get; set; }
}

public partial class Channel
{
    [JsonProperty("ID")]
    public long Id { get; set; }

    [JsonProperty("SendQueueCapacity")]
    public long SendQueueCapacity { get; set; }

    [JsonProperty("SendQueueSize")]
    public long SendQueueSize { get; set; }

    [JsonProperty("Priority")]
    public long Priority { get; set; }

    [JsonProperty("RecentlySent")]
    public long RecentlySent { get; set; }
}

public partial class Monitor
{
    [JsonProperty("Start")]
    public DateTimeOffset Start { get; set; }

    [JsonProperty("Bytes")]
    public long Bytes { get; set; }

    [JsonProperty("Samples")]
    public long Samples { get; set; }

    [JsonProperty("InstRate")]
    public long InstRate { get; set; }

    [JsonProperty("CurRate")]
    public long CurRate { get; set; }

    [JsonProperty("AvgRate")]
    public long AvgRate { get; set; }

    [JsonProperty("PeakRate")]
    public long PeakRate { get; set; }

    [JsonProperty("BytesRem")]
    public long BytesRem { get; set; }

    [JsonProperty("Duration")]
    public string Duration { get; set; }

    [JsonProperty("Idle")]
    public string Idle { get; set; }

    [JsonProperty("TimeRem")]
    public long TimeRem { get; set; }

    [JsonProperty("Progress")]
    public long Progress { get; set; }

    [JsonProperty("Active")]
    public bool Active { get; set; }
}

public partial class NodeInfo
{
    [JsonProperty("protocol_version")]
    public ProtocolVersion ProtocolVersion { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("listen_addr")]
    public string ListenAddr { get; set; }

    [JsonProperty("network")]
    public string Network { get; set; }

    [JsonProperty("version")]
    public Version Version { get; set; }

    [JsonProperty("channels")]
    public string Channels { get; set; }

    [JsonProperty("moniker")]
    public string Moniker { get; set; }

    [JsonProperty("other")]
    public Other Other { get; set; }
}

public partial class Other
{
    [JsonProperty("tx_index")]
    public string TxIndex { get; set; }

    [JsonProperty("rpc_address")]
    public string RpcAddress { get; set; }
}

public partial class ProtocolVersion
{
    [JsonProperty("p2p")]
    public long P2P { get; set; }

    [JsonProperty("block")]
    public long Block { get; set; }

    [JsonProperty("app")]
    public long App { get; set; }
}