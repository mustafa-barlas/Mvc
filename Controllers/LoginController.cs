using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MvcProjeKampii.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                //FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                //Microsoft.AspNetCore.Session["AdminUserName"] = adminUserInfo.AdminUserName;
                //return RedirectToAction("Index", "AdminCategory");   
                
            }
            else
            {
                return RedirectToAction("Index");       
            }
            return View();
        }
        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (writerUserInfo != null)
            {
                //FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail,false);
                //Microsoft.AspNetCore.Session["writerUserInfo"] = writerUserInfo.WriterMail;
                //return RedirectToAction("MyContent", "WriterPanelContent");   

            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            return View();
        }
    }
}
