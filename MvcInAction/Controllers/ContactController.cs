using MvcInAction.Data.Entities;
using MvcInAction.Data.Repositories;
using MvcInAction.Utilities.ActionResults;
using System.Net;
using System.Web.Mvc;

namespace MvcInAction.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _db;

        public ContactController(IContactRepository repo)
        {
            _db = repo;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_db.GetAll());
        }

        // GET: Contact/GetXml/
        public ActionResult GetXml()
        {
            return this.XmlFileResult(_db.GetAll(), "contacts.xml");
        }

        // GET: Contact/GetJson/
        public ActionResult GetJson()
        {
            // TODO: Call here yout Json file ActionResult
            return null;
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _db.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            _db.Add(contact);

            return RedirectToAction("Index");
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _db.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email")] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            _db.Edit(contact);

            return RedirectToAction("Index");
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _db.Find(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = _db.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            _db.Delete(contact);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}