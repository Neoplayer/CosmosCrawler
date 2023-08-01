using NetSearch.Models;
using NetSearch.Models.Response;
using Newtonsoft.Json;

namespace NetSearch;

public class Parser
{
    // http://65.21.133.114:26657


    private List<Node> Nodes = new List<Node>();
    private List<Node> NodesToRequest = new List<Node>();
    private List<Node> Requested = new List<Node>();

    private HttpClient client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(5)
    };

    public void Start(string network)
    {
        NodesToRequest.Add(new Node()
        {
            Address = "65.21.133.114",
            Moniker = "Staketab-Relayer-2"
        });

        do
        {
            SearchIteration(network);
        } while (NodesToRequest.Count > 0);

        var json = JsonConvert.SerializeObject(new
        {
            Nodes, Requested
        }, Formatting.Indented);
        File.WriteAllText("res.json", json);
    }

    private void SearchIteration(string network)
    {
        List<Node> toRequest = new List<Node>();

        object counterLock = new object();
        int counter = 0;
        
        NodesToRequest.AsParallel().ForAll(node =>
        {
            lock (counterLock)
            {
                Console.WriteLine($"[{++counter}/{NodesToRequest.Count}] Requesting: " + node.Address);
            }
            
            var res = RequestNode(node);

            lock (Requested)
            {
                Requested.Add(node);
            }
            
            if (res is { Result: not null })
            {
                lock (Nodes)
                {
                    Nodes.Add(node);   
                }
                
                foreach (var peer in res.Result.Peers)
                {
                    var newNode = new Node()
                    {
                        Address = peer.RemoteIp,
                        Moniker = peer.NodeInfo.Moniker
                    };

                    lock (toRequest)
                    {
                        if(peer.NodeInfo.Network == network)
                        {
                            toRequest.Add(newNode);
                        };
                    }
                }
            }
        });


        var distinctNodes = toRequest.Distinct().ToList();

        var duplicates = Requested.Intersect(distinctNodes).ToList();
        foreach (var duplicate in duplicates)
        {
            distinctNodes.Remove(duplicate);
        }

        NodesToRequest.Clear();
        NodesToRequest.AddRange(distinctNodes);
    }

    private NetInfoResponse? RequestNode(Node node)
    {
        try
        {
            
            var res = client.GetAsync("http://" + node.Address + ":26657" + "/net_info").Result;
            var s = res.Content.ReadAsStringAsync().Result;

            Console.WriteLine("Success: " + node.Address);
            
            return JsonConvert.DeserializeObject<NetInfoResponse>(s);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}