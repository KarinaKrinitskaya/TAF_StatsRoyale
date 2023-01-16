namespace Royale.Tests;

public class CardTests
{
    IWebDriver driver;
    //WebDriverWait waiter;

    [SetUp]
    public void BeforeEach()
    {
        driver = new ChromeDriver();
        driver.Url = "https://statsroyale.com/";
        //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.1);
        //waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        //driver.FindElement(By.CssSelector("button[title='Accept']")).Click();
    }

    [Test]
    public void Ice_Spirit_is_on_Card_Page()
    {
        //new
        var cardsPage = new CardsPage(driver);
        var iceSpirit = cardsPage.GoTo().GetCardByName("Ice Spirit");

        //old
        //driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
        //var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));

        Assert.That(iceSpirit.Displayed);

    }

    [Test]
    public void Ice_Spirit_are_correct_on_Card_Details_Page()
    {
        //new
        var cardsPage = new CardsPage(driver);
        cardsPage.GoTo().GetCardByName("Ice Spirit").Click();
        var cardDetails = new CardDetailsPage(driver);
        var (category, arena) = cardDetails.GetCardCategory();
        var cardName = cardDetails.Map.CardName.Text;
        var cardRarity = cardDetails.Map.CardRarity.Text;

        //old
        //driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
        //driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']")).Click();
        //var cardName = driver.FindElement(By.CssSelector("div[class='ui__headerMedium card__cardName']")).Text;
        //var cardCategories = driver.FindElement(By.CssSelector(".card__rarity")).Text.Split(", ");
        //var cardType = cardCategories[0];
        //var cardArena = cardCategories[1];
        //var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

        Assert.That(cardName, Is.EqualTo("Ice Spirit"));
        Assert.That(category, Is.EqualTo("Troop"));
        Assert.That(arena, Is.EqualTo("Arena 8"));
        Assert.That(cardRarity, Is.EqualTo("Common"));

    }

    [TearDown]
    public void AfterEach()
    {
        driver.Quit();
    }
}
