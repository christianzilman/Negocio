using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Models;
using System.IO;
using System.Drawing;
using System.Data.Entity.Validation;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Negocio.Controllers
{
    public class ProductoController : Controller
    {
        private NegocioContext db = new NegocioContext();

        //
        // GET: /Producto/

        //public ActionResult Index()
        //{
        //    var productoes = db.Productoes.Include(p => p.Item).Include(p => p.Negocio);
        //    return View(productoes.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            var productoes = db.Productoes.Include(p => p.Item).Include(p => p.Negocio);

            if (!String.IsNullOrEmpty(searchString))
            {
                productoes = productoes.Where(p => p.Nombre.ToUpper().Contains(searchString.ToUpper()));
                //students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                //                       || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    productoes = productoes.OrderByDescending(p => p.Nombre);
                    break;
                case "price_desc":
                    productoes = productoes.OrderByDescending(p => p.PrecioVenta);
                    break;
                default:
                    productoes = productoes.OrderBy(p => p.Nombre);
                    break;
            }
            return View(productoes.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre");
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre");
            return View(new ModelProducto());
        }


        public class ModelProducto 
        {
            public int ProductoId { get; set; }
            [Required(ErrorMessage = "Debe Ingresar un Producto")]
            public string Nombre { get; set; }
            [Required(ErrorMessage = "Debe Ingresar un Precio")]
            public Nullable<double> PrecioCompra { get; set; }
            [Required(ErrorMessage = "Debe Ingresar una Cantidad")]
            public Nullable<int> Cantidad { get; set; }
            [Required(ErrorMessage = "Debe Ingresar una Fecha")]
            public Nullable<System.DateTime> FechaActualizacion { get; set; }
            //public byte[] Imagen { get; set; }
            public HttpPostedFileBase File {get;set;}
            [Required(ErrorMessage = "Debe Seleccionar un Item")]
            public int ItemId { get; set; }
            [Required(ErrorMessage = "Debe Seleccionar un Negocio")]
            public Nullable<int> NegocioId { get; set; }
            [Required(ErrorMessage = "Debe Ingresar un Precio")]
            public Nullable<double> PrecioVenta { get; set; }
            public Nullable<int> Destacado { get; set; }
            public Item Item { get; set; }
            public Negocio.Models.Negocio Negocio { get; set; }
        }


        public byte[] ImageAArray(Image Imagen)
        {
            MemoryStream ms = new MemoryStream();
            Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        ///De byte [] a image:
        public Image ArrayAImage(byte[] ArrBite)
        {
            MemoryStream ms = new MemoryStream(ArrBite);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        } 

        //
        // POST: /Producto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelProducto model)
        {
            if (ModelState.IsValid)
            {
                Producto producto = new Producto();

                producto.Cantidad = model.Cantidad;
                producto.Destacado = model.Destacado;
                //producto.FechaActualizacion = model.FechaActualizacion;

                MemoryStream target = new MemoryStream();
                model.File.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                producto.Imagen = data;

                // var rutaArchivo = this.Request.Form["file1"];

                var  rutaArchivo = "C:\\Users\\cjzilman\\Pictures\\Hola.png";
                //producto.Imagen = ImageAArray(Image.FromFile(rutaArchivo));

                producto.Item = db.Items.Find(model.ItemId);
                producto.ItemId = model.ItemId;
                producto.Negocio = db.Negocios.Find(model.NegocioId);
                producto.NegocioId = model.NegocioId;
                producto.Nombre = model.Nombre;
                producto.PrecioCompra = model.PrecioCompra;
                producto.PrecioVenta = model.PrecioVenta;
                producto.FechaActualizacion = DateTime.Now;
                producto.Destacado = 1;
                db.Productoes.Add(producto);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", model.ItemId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", model.NegocioId);
            return View(model);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", producto.ItemId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", producto.NegocioId);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Nombre", producto.ItemId);
            ViewBag.NegocioId = new SelectList(db.Negocios, "NegocioId", "Nombre", producto.NegocioId);
            return View(producto);
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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