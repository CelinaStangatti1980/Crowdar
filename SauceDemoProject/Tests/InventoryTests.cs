using SauceDemoProject.PageObjects;



namespace SauceDemoProject.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTest
    {
        //private string fullPath = AppDomain.CurrentDomain.BaseDirectory;
        private string user = (Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User));
        private string pass = (Environment.GetEnvironmentVariable("SAUCE_CLAVE", EnvironmentVariableTarget.User));
        private LoginPage login;

        [Test]
        [Description("This test is going to fail")]
        public void AddOneProductToCart()
        {
            login = new LoginPage(Driver);
            login.LogIn(user,pass);
            string productName = "Sauce Labs BackpackWrong NAme";
            InventoryPage invPage = new InventoryPage(Driver);
            Assert.IsTrue(invPage.ProductExist(productName),"Product: "+ productName+" not found");
            invPage.AddOneElementToCart(productName);
            Assert.True(((invPage.ButtonOFProduct(productName)).Text).Contains("Remove"), "The Button's name should be Remove");
            Assert.True(invPage.NumOFProduct()==1);
        }

        [Test]
        public void AddProductsToCart()
        {
            string[] productName = new string[] {"Sauce Labs Backpack", "Sauce Labs Bolt T-Shirt", "Sauce Labs Fleece Jacket" };
            login = new LoginPage(Driver);
            login.LogIn(user, pass);
            InventoryPage invPage = new InventoryPage(Driver);
            invPage.AddElementsToCart(productName);
            foreach (var item in productName)
            {
                Assert.True(((invPage.ButtonOFProduct(item)).Text).Contains("Remove"), "The Button's name should be Remove");
               
            }
            Assert.True(invPage.NumOFProduct() == productName.Count());
        }
    }
}