using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MessageBoardClient.Models;

namespace MessageBoardClient.Controllers
{
  public class MessagesController : Controller
  {
    private readonly MessageBoardClientContext _db;

    public MessagesController(MessageBoardClientContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      var allMessages = Message.GetMessages();
      return View(allMessages);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Message message)
    {
      _db.Messages.Add(message);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisMessage = _db.Messages.FirstOrDefault(message => message.MessageId == id);
        return View(thisMessage);
    }

    public ActionResult Edit(int id)
    {
      var thisMessage = _db.Messages.FirstOrDefault(message => message.MessageId ==id);
      return View(thisMessage);
    }

    [HttpPost]
    public ActionResult Edit(Message message)
    {
      _db.Entry(message).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMessage = _db.Messages.FirstOrDefault(message => message.MessageId == id);
      return View(thisMessage);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMessage = _db.Messages.FirstOrDefault(message => message.MessageId == id);
      _db.Messages.Remove(thisMessage);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}