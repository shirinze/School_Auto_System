using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using School.Core.Service;
using School.Model.Entities;
using School_WebUI.Models.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace School_WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<Teacher> _teach;
        private readonly ICoreService<Student> _stu;
        public AccountController(ICoreService<Teacher> teach,ICoreService<Student> stu)
        {
            _teach = teach;
            _stu = stu;
        }
      
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        // Metodu Asenkron metod olarak tanımladık. Asenkron metodlar aynı anda birden fazla işleme cevap verebilirler.

        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if(lvm.LoginType==1)
            {
                var result = _teach.GetRecord(x => x.TeacherName == lvm.name && x.TeacherSurname == lvm.surename);
                if(result!=null)
                {
                    //talepler(claims)
                    var claims = new List<Claim>()
                    {
                        new Claim("ID",result.ID.ToString()),
                        new Claim("LoginType",lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Name,result.TeacherName),
                        new Claim(ClaimTypes.Surname,result.TeacherSurname)
                    };
                    var user = new ClaimsIdentity(claims, "Login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(user);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Teacher", new { area = "User" });
                }
            }


            return View();
        }

      
    }
}
