using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium_Yahoo
{
    class Program
    {
        static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("/Users/katelynncampbell/Documents/Selenium_Yahoo/bin/Debug/netcoreapp2.1");
            IWebDriver driver = new FirefoxDriver(service);

            driver.Url = "https://login.yahoo.com/?.src=finance&.intl=us&authMechanism=primary&done=https%3A%2F%2Ffinance.yahoo.com%2Fscreener%2Fpredefined&eid=100&add=1";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            driver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);
            driver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            driver.FindElement(By.XPath("//a[contains(text(), 'My Portfolio')]")).Click();
            driver.FindElement(By.XPath("//*[@id='main']/section/section/div[2]/table/tbody/tr[2]/td[1]/a")).Click();

            IList<IWebElement> stockNames = driver.FindElements(By.ClassName("_61PYt"));

            System.Console.WriteLine("Number of stocks in Katelynn's Portfolio: " + stockNames.Count);

            for (int i = 0; i < stockNames.Count; i++)
            {
                Console.WriteLine(stockNames[i].Text);
            }

            System.Console.WriteLine("\n");

            driver.Close();
        }
    }
}
