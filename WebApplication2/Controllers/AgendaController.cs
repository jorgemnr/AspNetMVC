using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ReservarSalaoFestas.Models;

namespace ReservarSalaoFestas.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agenda
        [AllowAnonymous]
        public ActionResult Index()
        {
            var agenda = db.Agenda.Include(a => a.Cliente);
            var lAgenda = db.Agenda.ToList().OrderByDescending(x => x.DataReserva);
            //buscar o apto do usuario autenticado
            var Apto = "N";
            if (User.Identity.IsAuthenticated)
            {
                Apto = (from d in db.Users
                        where d.UserName == User.Identity.Name
                        select d.Apto).First().ToString();
            }
            ViewBag.Apto = Apto;
            return View(lAgenda);
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.DataInicial = DateTime.Today.ToString("yyyy-MM-dd");
            ViewBag.DataFinal = DateTime.Today.AddMonths(6).ToString("yyyy-MM-dd");
            return View();
        }

        // POST: Agenda/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgendaId,DataReserva,Evento,QtdePessoas,UserId,DataAtualizacao")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                var JaExisteReserva = (from a in db.Agenda
                                       where a.DataReserva == agenda.DataReserva
                                       select 1).Count();
                if (JaExisteReserva > 0)
                {
                    ModelState.AddModelError("DataReserva", "Esta data já foi reservada! Favor escolher outra.");
                }
                else
                {
                    //buscar o UserId do usuario autenticado
                    //{
                    //    agenda.UserId = (from d in db.Users
                    //                     where d.UserName == User.Identity.Name
                    //    select d.Id).First().ToString();
                    //}
                    agenda.UserId = User.Identity.GetUserId();
                    db.Agenda.Add(agenda);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);

            if (agenda == null)
            {
                return HttpNotFound();
            }
            //
            var agendaEditView = new AgendaEditView
            {
                AgendaId = agenda.AgendaId,
                DataReserva = agenda.DataReserva,
                DataReservaOriginal = agenda.DataReserva,
                Evento = agenda.Evento,
                QtdePessoas = agenda.QtdePessoas
            };
            ViewBag.DataInicial = DateTime.Today.ToString("yyyy-MM-dd");
            ViewBag.DataFinal = DateTime.Today.AddMonths(6).ToString("yyyy-MM-dd");
            return View(agendaEditView);
        }

        // POST: Agenda/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgendaId,DataReserva,DataReservaOriginal,Evento,QtdePessoas,UserId")] AgendaEditView agenda)
        {

            if (ModelState.IsValid)
            {
                if (agenda.DataReservaOriginal != agenda.DataReserva)
                {
                    var JaExisteReserva = (from a in db.Agenda
                                           where a.DataReserva == agenda.DataReserva
                                           select 1).Count();
                    if (JaExisteReserva > 0)
                    {
                        ModelState.AddModelError("DataReserva", "Esta data já foi reservada! Favor escolher outra.");
                    }
                }
                if (ModelState.IsValid)
                {
                    var agendaModel = new Agenda
                    {
                        AgendaId = agenda.AgendaId,
                        UserId = User.Identity.GetUserId(),
                        DataReserva = agenda.DataReserva,
                        Evento = agenda.Evento,
                        QtdePessoas = agenda.QtdePessoas,
                        DataAtualizacao = DateTime.Now
                    };
                    db.Entry(agendaModel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agenda.Find(id);
            db.Agenda.Remove(agenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
