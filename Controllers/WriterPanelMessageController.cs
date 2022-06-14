using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageMaanger = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public IActionResult MyInbox()
        {
            var messagevalue = messageMaanger.GetListInbox();
            return View(messagevalue);
        }
        public PartialViewResult MyMessageMenu()
        {
            return PartialView();
        }
        public IActionResult MySendbox()
        {
            var messagevalue = messageMaanger.GetListSendbox();
            return View(messagevalue);
        }
        public IActionResult GetMyInboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }
        public IActionResult GetMySendboxMessageDetails(int id)
        {
            var messagetvalues = messageMaanger.GetByID(id);
            return View(messagetvalues);
        }
        [HttpGet]
        public IActionResult NewMyMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMyMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageSenderMail = "admin@gmail.com";
                p.MessageDate = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
                messageMaanger.MessageAdd(p);
                return RedirectToAction("MySendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
