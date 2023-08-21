    using Microsoft.AspNetCore.Mvc;
using TestCaseWebApp.Models;
using TestCaseWebApp.Utils;

namespace TestCaseWebApp.Controllers
{
    public class AuthController : Controller
    {

        private IHttpClientFactory clientFactory;
        public AuthController(IHttpClientFactory _clientFactory)
        {
            clientFactory = _clientFactory;
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var client = clientFactory.CreateClient("general");

            var response = await client.GetAsync($"Auth/Login?email={model.Email}&password={model.Password}");

            if(response != null) 
            {
                if(response.IsSuccessStatusCode) 
                {
                    var token = await response.Content.ReadAsStringAsync();
                    if(!string.IsNullOrEmpty(token))
                    {
                        GlobalData.Instance.JWTToken = token;
                    }
                }
            }

            return RedirectToAction("Index","Product");
        }
    }
}
