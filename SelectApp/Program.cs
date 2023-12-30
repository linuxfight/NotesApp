internal class Program
{
	private static void Main(string[] args)
	{
		var orders = new List<Order>()
		{
			new Order() { Id = 1, Products=new List<string>() { "Phone", "PC" }},
			new Order() { Id = 2, Products=new List<string>() { "Vegetables" }},
			new Order() { Id = 3, Products=new List<string>() { "AdventuresLab Metro" }}
		};

		//var products = orders.SelectMany(x => x.Products).ToList();
		//var products = orders.Where(x => x.Id % 2 != 0).SelectMany(x => x.Products).ToList();
		var res = orders.Where(x => x.Products.Contains("Phone")).ToList();
	}
}

class Order
{
	public int Id { get; set; }
	public List<string> Products { get; set; }
}