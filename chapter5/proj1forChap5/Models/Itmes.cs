namespace proj1forChap5.Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Item Related { get; set; }
        public static Item[] GetItems()
        {
            Item kayak = new Item
            {
                Name = "Kayak",
                Price = 275M
            };
            Item lifejacket = new Item
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            kayak.Related = lifejacket; //this an Item object too
            return new Item[] { kayak, lifejacket, null };
        }
    }
}