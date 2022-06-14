using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public IActionResult MyContent(string p)
        {
            Context context = new Context();    
            //  p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();  
            // ViewBag.d = p;
            var contentValue = contentManager.GetListByWriter(writerIdInfo);    
            return View(contentValue);
        }
    }
}
