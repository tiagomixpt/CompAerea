using CompAerea.Dominio.Entidades;
using CompAerea.Infrastrutura.Data;
using Microsoft.AspNetCore.Mvc;

namespace CompAereaWeb.Controllers
{

    public class VoosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VoosController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            var voos = _db.Voos.ToList();
            return View(voos);
        }
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Voos obj)
		{
			
			if (ModelState.IsValid)
			{
				_db.Voos.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Voo criado com sucesso.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "Não foi possivel a criação do voo.";
			return View(obj);
		}

		public IActionResult Update(int aviaoId)
		{

			Avioes? obj = _db.Avioes.FirstOrDefault(u => u.Id == aviaoId);


			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Avioes obj)
		{

			if (ModelState.IsValid && obj.Id > 0)
			{
				_db.Avioes.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Avião editado com sucesso.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "Não foi possivel a edição do avião.";
			return View(obj);
		}
		public IActionResult Delete(int aviaoId)
		{
			Avioes? obj = _db.Avioes.FirstOrDefault(u => u.Id == aviaoId);


			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Avioes obj)
		{
			Avioes? objFromDb = _db.Avioes.FirstOrDefault(_ => _.Id == obj.Id);
			if (objFromDb is not null)
			{
				_db.Avioes.Remove(objFromDb);
				_db.SaveChanges();

				TempData["success"] = "The Villa has been deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "The Villa could not be deleted.";
			return View(obj);
		}

	}
}
