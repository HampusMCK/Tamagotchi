class store
{
    public int ItemPrice;
    public string ItemName;
    public int HungerDecrease;
    public int ExhibitionScore;
    public List<store> StockItems = new();

    public void addItems()
    {
        StockItems.Add(new() { ItemPrice = 5, ItemName = "Apple", HungerDecrease = 7 });
        StockItems.Add(new() { ItemPrice = 7, ItemName = "Candy Bag", HungerDecrease = 15 });
        StockItems.Add(new() { ItemPrice = 15, ItemName = "Steak", HungerDecrease = 25 });
        StockItems.Add(new() { ItemPrice = 20, ItemName = "Bow", ExhibitionScore = 10 });
        StockItems.Add(new() { ItemPrice = 25, ItemName = "Necklace", ExhibitionScore = 15 });
        StockItems.Add(new() { ItemPrice = 40, ItemName = "Cape", ExhibitionScore = 20 });
    }

    public void PrintFood()
    {
        for (int i = 0; i < StockItems.Count; i++)
        {
            if (i < 3)
            {
                Console.WriteLine($"{i + 1}. {StockItems[i].ItemName}, Hunger Solving: {StockItems[i].HungerDecrease}, Price: ${StockItems[i].ItemPrice}");
            }

        }
    }

    public void PrintItem()
    {
        for (int i = 0; i < StockItems.Count; i++)
        {
            if (i > 2)
            {
                Console.WriteLine($"{i - 2}. {StockItems[i].ItemName}, Exhibition Score: {StockItems[i].ExhibitionScore}, Price: ${StockItems[i].ItemPrice}");
            }
        }
    }
}