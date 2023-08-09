using OpenQA.Selenium;
using SauceDemoProject.Actions;


namespace SauceDemoProject.PageObjects
{
    public class InventroyPageLocators : BasePage
    {
        public InventroyPageLocators(IWebDriver driver)
        {
            Driver = driver;
        }

        //Page elements for interaction
        public IList<IWebElement> ListOfProducts => Driver.FindElements(By.CssSelector(".inventory_item"));
        public IWebElement Cart => Driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement ProductButton(IWebElement button) => button.FindElement(By.TagName("button"));

    }
    public class InventoryPage : InventroyPageLocators
    {
        public static IWebDriver inventoryDriver;
        
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            inventoryDriver = driver;
        }

        public UserActions userActs = new UserActions(inventoryDriver);

        public void AddOneElementToCart (string productName)
        {
            foreach (var product in ListOfProducts)
            {
                if (product.Text.Contains(productName))
                {
                    userActs.clickOn(ProductButton(product));
                    return;
                }

            }

            throw new Exception("The product is not in the list");
        }

        public void AddElementsToCart(string[] productName)
        {
            for (int i = 0; i < productName.Count(); i++)
            {
                AddOneElementToCart(productName[i]);

            }            
        }

        public bool ProductExist(string productName)
        {
            foreach (var product in ListOfProducts)
            {
                if (product.Text.Contains(productName))
                {
                    return true;
                }

            }

            return false;
        }

        public IWebElement ButtonOFProduct(string productName)
        {
            IWebElement empty = null;
            foreach (var product in ListOfProducts)
            {
                if (product.Text.Contains(productName))
                {
                    return product;
                }

            }

            return empty;
        }

       

        public int NumOFProduct()
        {
            int aux = Int16.Parse(Cart.Text);
            
            return aux ;

        }
        public void RemoveFromCart(string productToRemove)
        {

            Assert.True(ProductExist(productToRemove), "The product is not in the cart");

        }
    }
    
}
