using System.Diagnostics;
using Newtonsoft.Json;
using Main.Models;


var root = new Root();
var rootPath = Path.Combine(Environment.CurrentDirectory + @"\..\..\..\CustomerMobiles.json");
var rootJson = File.ReadAllText(rootPath);
root.CustomerMobiles = JsonConvert.DeserializeObject<List<string>>(rootJson);

foreach (var customerMobile in root.CustomerMobiles)
{
    Process.Start(@"G:\AutoOrder-main\AutoOrder\AutoOrder\bin\Debug\net6.0\AutoOrder.exe", customerMobile);
}