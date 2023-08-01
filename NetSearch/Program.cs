// See https://aka.ms/new-console-template for more information

using NetSearch;
using NetSearch.Models;
using Newtonsoft.Json;


Parser parser = new Parser();
parser.Start();









// var fileJson = File.ReadAllText("/home/neerd/.osmosisd/config/addrbook.json");
//
// var addrBook = JsonConvert.DeserializeObject<AddrBookModel>(fileJson);
//
// var f = addrBook.Addrs.Where(x => x.LastSuccess > DateTime.Now - TimeSpan.FromDays(365)).ToList();
//
// HttpClient client = new HttpClient()
// {
//     Timeout = TimeSpan.FromSeconds(5)
// };
//
// f.AsParallel().ForAll((element =>
// {
//
// }));

Console.ReadLine();