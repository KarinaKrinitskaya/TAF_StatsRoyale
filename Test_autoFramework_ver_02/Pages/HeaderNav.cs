using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HeaderNav//what can the user do on the page?
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

        public void GoToCardsPage()
        {
            Map.CardsTabLink.Click();
        }

    }

    public class HeaderNavMap //What is on the page?
    {
        IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardsTabLink => _driver.FindElement(By.CssSelector("a[href='/cards']"));

    }

}


