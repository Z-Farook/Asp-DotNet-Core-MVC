namespace proj1forChap5.Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        // Property Initializers
        public string Category { get; set; } = "Watersports";
        public Item Related { get; set; }
        // read-only property by using an initializer and omitting the set keyword
        public bool InStock { get; } = true;
        public static Item[] GetItems()
        {
            Item kayak = new Item
            {
                Name = "Kayak",
                ///new value to the Category = "Water Craft",
                Category = "Water Craft",
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