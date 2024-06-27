using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Models;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Registration(IFormCollection col)
        {
            UserEntity user = new UserEntity();


            user.Name = col["name"].ToString();
            user.PhoneNumber = col["phoneNumber"].ToString();
            user.Email = col["email"].ToString();
            user.Gender = col["gender"].ToString();

            var strVal = JsonConvert.SerializeObject(user);

            string strRet = APICall.SendAPIPostRequest("https://localhost:7180/api/User/SaveUser", strVal);


            return View("Form");
        }

        public IActionResult Update(IFormCollection col)
        {
            UserEntity user = new UserEntity();

            user.Id = Convert.ToInt32(col["uid"].ToString());
            user.Name = col["name"].ToString();
            user.PhoneNumber = col["phoneNumber"].ToString();
            user.Email = col["email"].ToString();
            user.Gender = col["gender"].ToString();

            string u = "https://localhost:7180/api/User/UpdateUser";

            var strVal = JsonConvert.SerializeObject(user);

            string strRet = APICall.SendAPIPostRequest(u, strVal);


            return RedirectToAction("DisplayUsers");
        }

        public ViewResult DisplayUsers()
        {
            string strUsers = APICall.SendAPIGetRequest("https://localhost:7180/api/User/GetAllUsers");


            List<UserEntity> lstUser = JsonConvert.DeserializeObject<List<UserEntity>>(strUsers);

            return View("DisplayUsers", lstUser);
        }

        public IActionResult Edit(int id)
        {
            string u = "https://localhost:7180/api/User/GetUser?Id=" + id;
            string strUser = APICall.SendAPIGetRequest(u);

            UserEntity user = new UserEntity();
            user = JsonConvert.DeserializeObject<UserEntity>(strUser);

            return View("Edit", user);
        }

        public IActionResult Delete(int id)
        {
            string u = "https://localhost:7180/api/User/DeleteUser?Id=" + id;
            string strUsers = APICall.SendAPIDeleteRequest(u);

            return RedirectToAction("DisplayUsers");
        }
    }
}

