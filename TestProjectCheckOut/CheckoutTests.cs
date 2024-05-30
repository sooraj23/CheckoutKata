using checkout;

namespace TestProjectCheckOut
{
    public class CheckoutTests
    {
        [Fact]
        public void Scan_SingleItemA()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }

        [Fact]
        public void Scan_MultipleItems()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("A");
            Assert.Equal(160, checkout.GetTotalPrice()); // 130 for three A's and 30 for B
        }

        [Fact]
        public void Scan_SpecialPriceForB()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            checkout.Scan("B");
            Assert.Equal(45, checkout.GetTotalPrice());
        }

        [Fact]
        public void Scan_TotalPriceForCAndA()
        {
            var checkout = new Checkout();
            checkout.Scan("C");
            checkout.Scan("A");
            Assert.Equal(45, checkout.GetTotalPrice());  //70 is the Actual Price
        }
    }
}