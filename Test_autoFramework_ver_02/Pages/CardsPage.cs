using System;
using OpenQA.Selenium;

namespace Royale.Pages
{
	public class CardsPage : PageBase
	{
        public readonly CardsPageMap Map;

		public CardsPage(IWebDriver driver) : base(driver)
		{
            Map = new CardsPageMap(driver);
		}

        // Given the cardName "Ice Spirit" => should turn into "Ice+Spirit" to work with our locator.
        public IWebElement GetCardByName(string cardName) //для удобства работы с локатором
        {
            if(cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }

            return Map.Card(cardName);
        }

        public CardsPage GoTo()
        {
            HeaderNav.GoToCardsPage();
            return this;
        }
	}
    
    public class CardsPageMap
    {
        IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        //public IWebElement IceSpiritCard => _driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));

        public IWebElement Card(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}

