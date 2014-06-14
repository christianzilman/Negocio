using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Models;

namespace Negocio.Controllers
{
    public class OfertaController : Controller
    {
        private NegocioContext db = new NegocioContext();

        //
        // GET: /Oferta/

        public ActionResult Index()
        {
            return View(db.Ofertas.ToList());
        }

        //
        // GET: /Oferta/Details/5

        public ActionResult Details(int id = 0)
        {
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        //
        // GET: /Oferta/Create

        public ActionResult Create()
        {
            IList<Producto> products = db.Productoes.ToList<Producto>();
            ViewBag.Products = products;
            return View();
        }

        //
        // POST: /Oferta/Create

        public class ModelOferta 
        {
            public int OfertaId { get; set; }
            public string Descripcion { get; set; }
            public Nullable<System.DateTime> FechaDesde { get; set; }
            public Nullable<System.DateTime> FechaHasta { get; set; }
            public Nullable<double> Total { get; set; }

            public List<int> DetalleOfertaId { get; set; }
            public List<int> DetalleOfertaCantidad { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelOferta model)
        {


            if (ModelState.IsValid)
            {
                Oferta oferta = new Oferta();
                oferta.FechaDesde = model.FechaDesde;
                oferta.FechaHasta = model.FechaHasta;
                oferta.Descripcion = model.Descripcion;
                oferta.Total = model.Total;

                List<DetalleOferta> detalleOfertas = new List<DetalleOferta>();
                for(int i = 0; i< model.DetalleOfertaId.Count;i++)
                {
                    DetalleOferta detalleOferta = new DetalleOferta();
                    detalleOferta.Cantidad = model.DetalleOfertaCantidad[i];
                    detalleOferta.ProductoId = model.DetalleOfertaId[i];

                    var producto = db.Productoes.Find(model.DetalleOfertaId[i]);
                    detalleOferta.Producto = producto;
                    detalleOferta.Precio = producto.PrecioVenta;
                    detalleOferta.SubTotal = producto.PrecioVenta * model.DetalleOfertaCantidad[i];

                    detalleOfertas.Add(detalleOferta);
                }

                oferta.DetalleOfertas = detalleOfertas;
                db.Ofertas.Add(oferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /Oferta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        //
        // POST: /Oferta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oferta);
        }

        //
        // GET: /Oferta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Oferta oferta = db.Ofertas.Find(id);
            if (oferta == null)
            {
                return HttpNotFound();
            }
            return View(oferta);
        }

        //
        // POST: /Oferta/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oferta oferta = db.Ofertas.Find(id);
            db.Ofertas.Remove(oferta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}