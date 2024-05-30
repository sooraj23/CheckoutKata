namespace checkout
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> prices = new Dictionary<string, int>
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };

        private readonly Dictionary<string, (int Quantity, int SpecialPrice)> specialPrices = new Dictionary<string, (int Quantity, int SpecialPrice)>
        {
            { "A", (3, 130) },
            { "B", (2, 45) }
        };

        private readonly Dictionary<string, int> items = new Dictionary<string, int>();

        public void Scan(string item)
        {
            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items[item] = 1;
            }
        }

        public int GetTotalPrice()
        {
            int total = 0;
            foreach (var item in items)
            {
                if (specialPrices.ContainsKey(item.Key) && item.Value >= specialPrices[item.Key].Quantity)
                {
                    var specialOffer = specialPrices[item.Key];
                    int specialCount = item.Value / specialOffer.Quantity;
                    int remainder = item.Value % specialOffer.Quantity;
                    total += specialCount * specialOffer.SpecialPrice + remainder * prices[item.Key];
                }
                else
                {
                    total += item.Value * prices[item.Key];
                }
            }
            return total;
        }
    }
}
