using CompAerea.Application.Common.Interfaces;
using CompAerea.Dominio.Entidades;
using CompAerea.Infrastrutura.Data;
using Microsoft.AspNetCore.Mvc;

namespace CompAereaWeb.Controllers
{

    public class FlightController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork; 
        }
        public IActionResult Index()
        {
            var flights = _unitOfWork.Flight.GetAll();
            return View(flights);
        }
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Flight obj)
		{
			
			if (ModelState.IsValid)
			{
				_unitOfWork.Flight.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Flight created successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "Error creating the flight.";
			return View(obj);
		}

		public IActionResult Update(int flightId)
		{

			Flight? obj = _unitOfWork.Flight.Get(u => u.Id == flightId);


			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Flight obj)
		{

			if (ModelState.IsValid && obj.Id > 0)
			{
				_unitOfWork.Flight.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Flight edited successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "Error editing the flight.";
			return View(obj);
		}
		public IActionResult Delete(int flightId)
		{
			Flight? obj = _unitOfWork.Flight.Get(u => u.Id == flightId);


			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Flight obj)
		{
			Flight? objFromDb = _unitOfWork.Flight.Get(_ => _.Id == obj.Id);
			if (objFromDb is not null)
			{
				_unitOfWork.Flight.Remove(objFromDb);
				_unitOfWork.Save();

				TempData["success"] = "Flight deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "Error deleting the flight.";
			return View(obj);
		}

	}
}
