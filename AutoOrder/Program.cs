using Newtonsoft.Json;
using AutoOrder.Models;

var root = new Root();
var rootPath = Path.Combine(Environment.CurrentDirectory + @"\..\..\..\Orders.json");
var rootJson = File.ReadAllText(rootPath);
root.Orders = JsonConvert.DeserializeObject<List<Order>>(rootJson);

foreach (var orderMobile in args)
{
    var matchingOrder = root.Orders.FindAll(orders => orders.Customer.Mobile == orderMobile);
    foreach (var orderInfo in matchingOrder)
    {
        var autoOrder = new AutoOrder.Controllers.AutoOrder();
        autoOrder.WebDriverSetup();
        autoOrder.Run();
    }
}