using Microsoft.AspNetCore.Mvc;
using WeeCompanyEjercicio.Models;
namespace WeeCompanyEjercicio.Controllers
{
    public class ListaController : Controller
    {
        // GET: ListaController
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44323/api/Datos";
            List<ModelDatos> listadatos = await client.GetFromJsonAsync<List<ModelDatos>>(url);
            List<ModelDatos> ShowDatos = new List<ModelDatos>();
            foreach (var item in listadatos)
            {
                ShowDatos.Add(new ModelDatos
                {
                    Id= item.Id,
                    Compania = item.Compania,
                    Contacto = item.Contacto,
                    Correo = item.Correo,
                    Telefono = item.Telefono,
                }
                    );
            }
            var datos = ShowDatos.ToList();
            return View(datos.ToList());
        }

        // GET: ListaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
