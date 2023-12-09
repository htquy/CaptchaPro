using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static OpenQA.Selenium.WebDriver;
using Captcha.Models;

using HtmlAgilityPack;
using System.Xml;


namespace Captcha.Controllers
{
    public class WebScrapingController : Controller
    {
        //Ver 1
        //public async Task<IActionResult> Index()
        //{
        //    ChromeOptions options = new ChromeOptions();
        //    options.AddArgument("--headless");
        //    // Lấy kiểu dữ liệu từ thẻ input
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync("https://localhost:7010");
        //    var pageContents = await response.Content.ReadAsStringAsync();

        //    var htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(pageContents);

        //    var inputNodes = htmlDoc.DocumentNode.SelectNodes("//input");
        //    foreach (var inputNode in inputNodes)
        //    {
        //        var inputType = inputNode.GetAttributeValue("type", "text");
        //        Console.WriteLine($"Input Type: {inputType}");
        //    }

        //    // Chèn dữ liệu vào trường sử dụng Selenium
        //    var driver = new ChromeDriver();
        //    driver.Navigate().GoToUrl("https://localhost:7010/");

        //    foreach (var inputNode in inputNodes)
        //    {
        //        var inputType = inputNode.GetAttributeValue("type", "text");
        //        var inputField = driver.FindElements(By.XPath($"//input"));
        //        inputField[inputNodes.IndexOf(inputNode)].SendKeys("Your Data Here");
        //    }

        //    // Đóng trình duyệt
        //    driver.Quit();

        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    TTModel model = new TTModel();
        //    // Khởi tạo các thuộc tính của model nếu cần
        //    model.Fullname = "Tên mặc định";
        //    model.Age = 30; 
        //    model.Sexual = "Giới tính mặc định";
        //    model.Country = "Quốc gia mặc định";
        //    model.Password = "Mật khẩu mặc định";
        //    return View(model);
        //}

        //Ver 2
        //[HttpPost]
        //public IActionResult Submit(TTModel model)
        //{
        //    string Url = "https://localhost:7010";
        //    using (IWebDriver driver = new ChromeDriver())
        //    {
        //        driver.Navigate().GoToUrl(Url);
        //        var inputElements = driver.FindElements(By.XPath("//input")).ToList();

        //        foreach (var inputElement in inputElements)
        //        {
        //            var inputType = inputElement.GetAttribute("type");
        //            var propertyName = inputElement.GetAttribute("name");
        //            var propertyValue = typeof(TTModel).GetProperty(propertyName)?.GetValue(model);
        //            if (propertyValue != null || inputType == "password")
        //            {
        //                switch (inputType)
        //                {
        //                    case "text":
        //                        inputElement.SendKeys(propertyValue?.ToString());
        //                        break;
        //                    case "password":
        //                        if (model.Password != null)
        //                        {
        //                            inputElement.SendKeys(model.Password);
        //                        }
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }

        //        var submitButton = inputElements.FirstOrDefault(x => x.GetAttribute("type") == "submit");
        //        submitButton?.Click();

        //        // Chờ cho đến khi trang được load sau khi submit
        //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //        // Bỏ qua bước chuyển hướng vì bạn muốn ở lại trang hiện tại sau khi submit
        //        // driver.Navigate().GoToUrl(Url); // Dòng này không cần thiết và đã được bỏ đi
        //    }

        //    // Trả về View với model đã được điền thông tin
        //    return Ok(model);
        //}

        //Ver3
        [HttpPost]
        public IActionResult Submit()
        {
            string Url = "https://localhost:7010";
            string HomeUrl = "https://localhost:7010/home"; // Đảm bảo rằng đây là URL mong muốn sau khi submit
            ChromeOptions options = new ChromeOptions();
            using (IWebDriver driver = new ChromeDriver(options))
            {
                {
                    driver.Navigate().GoToUrl(Url);

                    var inputElements = driver.FindElements(By.TagName("input"));
                    foreach (var inputElement in inputElements)
                    {
                        var inputType = inputElement.GetAttribute("type");
                        var inputName = inputElement.GetAttribute("name");

                        switch (inputType)
                        {
                            case "text":
                                inputElement.SendKeys("Dữ liệu mẫu cho text");
                                break;
                            case "number":
                                inputElement.SendKeys("123");
                                break;
                            case "email":
                                inputElement.SendKeys("example@example.com");
                                break;
                            case "password":
                                inputElement.SendKeys("admin@123");
                                break;
                            default:
                                break;
                        }
                    }

                    // Submit form
                    var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));
                    submitButton?.Click();

                    // Chờ cho đến khi trang được load sau khi submit
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                    // Điều hướng đến trang home để xem kết quả
                    driver.Navigate().GoToUrl(HomeUrl);


                }

                return View("~/Views/Register/Index.cshtml");
            }
        }





    }
}
