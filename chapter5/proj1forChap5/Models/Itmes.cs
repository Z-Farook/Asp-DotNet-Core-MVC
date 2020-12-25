namespace proj1forChap5.Models
{
    public class Item
    {
        #region //Pattern Matching in switch Statements
        public void MyMethod(string parameter)
        {

            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case /*Type check*/ decimal /*A local Variable */ decimalValue:
                        total += decimalValue;
                        break;
                    case /*Type check*/ int /*A local Variable */ intValue /*condition key word:*/ when intValue > 50:
                        total += intValue;
                        break;
                }
            }
        }
        #endregion

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