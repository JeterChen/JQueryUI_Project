using JQGridUIDemo.Models;
using JQGridUIDemo.Services.Implement;
using JQGridUIDemo.Services.Interface;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JQGridUIDemo.Controllers
{
    public class JqGridDemoOneController : Controller
    {
        private readonly IUserService _userService;
        public JqGridDemoOneController()
        {
            this._userService = new UserService();
        }

        public ActionResult jqGridFirst()
        {
            return View();
        }

        public JsonResult GetAllUser()
        {
            var alluser = this._userService.GetAll().ToList();

            var jsonData = new
            {
                rows = alluser
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InserUser(UserModel userModel)
        {
            ResultModel resultModel = this._userService.Insert(userModel);
            return Json(resultModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ModifyUser(UserModel userModel)
        {
            ResultModel resultModel = this._userService.Modify(userModel);
            return Json(resultModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult RemoveUser(int Id)
        {
            ResultModel resultModel = this._userService.Remove(Id);
            return Json(resultModel, JsonRequestBehavior.DenyGet);
        }
    }
}

