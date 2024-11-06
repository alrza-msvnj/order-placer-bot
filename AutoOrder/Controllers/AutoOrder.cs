namespace AutoOrder.Controllers
{
    public class AutoOrder : Setup
    {
        public void Run()
        {
            foreach (var order in root.Orders)
            {
                Console.WriteLine("AutoOrder is running...");

                for (int i = 0; i < order.OrderCount; i++)
                {
                    var login = new Login(webDriver, baseSiteUrl);
                    login.DoLogin(order.Customer);

                    var makeOrder = new Order(webDriver, baseSiteUrl, javaScriptExecutor);
                    makeOrder.DoOrder(order.Products);

                    var shipping = new Shipping(webDriver, baseSiteUrl);
                    shipping.DoShipping(order.Address);

                    var payment = new Payment(webDriver, baseSiteUrl, javaScriptExecutor);
                    payment.DoPayment(order.CustomerDescription, order.Gateway);

                    if (order.OrderCount > 1 && i != order.OrderCount - 1)
                    {
                        var random = new Random();
                        var randomDelay = random.Next(order.OrderDelayToSeconds.Min, order.OrderDelayToSeconds.Max);
                        Thread.Sleep(randomDelay * 1000);
                    }
                }

                Console.WriteLine("AutoOrder completed.");
            }
        }
    }
}