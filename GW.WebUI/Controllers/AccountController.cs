using GW.BLL.Models;
using GW.BLL.Services;
using GW.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace GW.WebUI.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUnitOfWorkUserManager unitOfWorkUserManager;
        public AccountController(IUnitOfWorkUserManager unitOfWorkUserManager)
        {
            this.unitOfWorkUserManager = unitOfWorkUserManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = unitOfWorkUserManager.RoleService.GetAll();
            return View(model);
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl = "/Home/Index")
        {
            if (ModelState.IsValid)
            {
                try
                {

                    UserDTO user = unitOfWorkUserManager.UserService.FindBy(u => u.Email.ToUpper() == model.Email.ToUpper()).FirstOrDefault();

                    if (user == null || !Crypto.VerifyHashedPassword(user.PasswordHash, model.Password))
                        throw new AccountException("Не верный логин или пароль!");

                    FormsAuthentication.SetAuthCookie(model.Email, true);

                    return Redirect(ReturnUrl);
                }
                catch (AccountException exc)
                {
                    ModelState.AddModelError("", exc.Message);
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError("", "Критическая ошибка!");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model, string ReturnUrl = "/Home/Index")
        {
            if (ModelState.IsValid)
            {
                using (unitOfWorkUserManager.Transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        UserDTO user = unitOfWorkUserManager.UserService.FindBy(u => u.Email.ToUpper() == model.Email.ToUpper()).FirstOrDefault();

                        if (user != null)
                            throw new AccountException($"Пользователь с почтой { model.Email } уже существует!");

                        user = unitOfWorkUserManager.UserService.Add(new UserDTO
                        {
                            Email = model.Email,
                            PasswordHash = Crypto.HashPassword(model.Password),
                        });

                        if (user == null)
                            throw new AccountException("Ошибка при создании пользователя!");

                        var role = unitOfWorkUserManager.UserInRoleService.Add(new UserInRoleDTO
                        {
                            RoleId = 1,
                            UserId = user.UserId
                        });

                        unitOfWorkUserManager.Commit();

                        FormsAuthentication.SetAuthCookie(model.Email, true);

                        return Redirect(ReturnUrl);
                    }
                    catch (AccountException exc)
                    {
                        unitOfWorkUserManager.Rollback();
                        ModelState.AddModelError("", exc.Message);
                    }
                    catch (Exception exc)
                    {
                        unitOfWorkUserManager.Rollback();
                        ModelState.AddModelError("", "Критическая ошибка!");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Sign()
        {
            if (User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}