using Captcha.Datas;
using Captcha.Models;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MyDbContext _db;
        public RegisterController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(ErrorMessage = "Please Enter Valid Captcha")]
        public IActionResult PostTT(TTModel tt)
        {
            if(ModelState.IsValid)
            {
                int id;
                if (_db.TTs.Count() != 0) { id = _db.TTs.Max(x => x.Id) + 1; }
                else id = 1;
                var newtt = new TT()
                {
                    Fullname = tt.Fullname,
                    Age= tt.Age,
                    Country= tt.Country,
                    Sexual= tt.Sexual,
                    Password= tt.Password,
                };
                _db.TTs.Add(newtt);
                _db.SaveChanges();
                return Redirect("https://localhost:7010/");
            }
            else return BadRequest(ModelState);
        }
    }
}
