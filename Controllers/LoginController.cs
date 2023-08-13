using Microsoft.AspNetCore.Mvc;
using PhotoBookRepository;
using PhotoBookWeb.Models;
using PhotoBookWebService;
using System.Reflection;

namespace PhotoBookWeb.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        //[Route("Index")]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //model.Password = UtilityFunctions.encryptPassword(model.Password);
                    client.BaseAddress = new Uri("http://localhost:5033/api/"); //https://localhost:7288;http://localhost:5033
                    var responseTask = await client.GetAsync("Login/AuthenticateUser/?astrUserName=" + model.UserName + "&&astrPassword=" + model.Password).ConfigureAwait(false);

                    WebHttpResponse result = responseTask.Content.ReadFromJsonAsync<WebHttpResponse>().Result ;
                    if (result.IsSuccess)
                    {
                       // TempData["response"] = result.Data;
                        return RedirectToAction("Index", "Home", new { id = result.Data.ToString()});
                    }
                    else
                    {
                        ViewBag.message = "Username or Password is incorrect, Try Again.";
                    }
                }
            }
            return View();
        }
        [Route("Login/SignUpUser")]
        [HttpGet]
        public async Task<IActionResult> SignUpUser()
        {
            return View();
        }
        [Route("Login/SignUpUser")]
        [HttpPost]
        public async Task<IActionResult> SignUpUser(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5033/api/"); //https://localhost:7288;http://localhost:5033
                    PhotobookUser photobookUser = getPhotobookUserFromLoginUser(loginUser);

                    var responseTask = await client.PostAsJsonAsync("Login/CreateUser/", photobookUser);
                    
                    if (responseTask.IsSuccessStatusCode)
                    {
                        ViewBag.message = "User created successfully!";
                        return View();
                    }
                }
            }
            return View(loginUser);
        }

        private PhotobookUser getPhotobookUserFromLoginUser(LoginUser loginUser)
        {
            PhotobookUser lObjPhotobookUsernew = new PhotobookUser();
            lObjPhotobookUsernew.UserName = loginUser.UserName;
            lObjPhotobookUsernew.Password = loginUser.Password;
            lObjPhotobookUsernew.Person = new Person();
            lObjPhotobookUsernew.Person.Email = loginUser.Email;
            lObjPhotobookUsernew.Person.Mobile = loginUser.Mobile;
            lObjPhotobookUsernew.Person.IsCustomer = false;
            lObjPhotobookUsernew.Person.FirstName = loginUser.FirstName;
            lObjPhotobookUsernew.Person.LastName = loginUser.LastName;
            return lObjPhotobookUsernew;
        }
    }
}
