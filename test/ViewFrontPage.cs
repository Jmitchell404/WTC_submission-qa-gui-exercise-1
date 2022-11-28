using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace test;

public class ViewFrontPage
{
    private static IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("headless");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
    }

    [Test]
    public void FrontPageTest()
    {
        driver.Navigate().GoToUrl("http://localhost:90");
        var title = driver.Title; 
        Assert.That(title, Is.EqualTo("Your store. Home page title"));
        var altText = driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div[2]/div[1]/a/img")).GetAttribute("alt");
        Assert.That(altText, Is.EqualTo("Your store name"));
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }

}
