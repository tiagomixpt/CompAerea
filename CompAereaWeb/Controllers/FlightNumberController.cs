using CompAerea.Dominio.Entidades;
using CompAerea.Infrastrutura.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompAerea.Application.Common.Interfaces;
using CompAerea.Web.ViewModels;

namespace CompAereaWeb.Controllers
{

	public class FlightNumberController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public FlightNumberController(UnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork; 
        }
        public IActionResult Index()
        {
			var flightNumbers = _unitOfWork.FlightNumber.GetAll(includeProperties: "Flight");
			
            return View(flightNumbers);
        }
		public IActionResult Create()
		{
			FlightNumberVM flightNumberVM = new()
			{
				FlightList = _unitOfWork.Flight.GetAll().Select(u => new SelectListItem
				{
					Text = u.Plane,
					Value = u.Id.ToString()
				})
			};
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]	
		public IActionResult Create(FlightNumberVM obj)
		{
			bool flightNumberExists = _unitOfWork.FlightNumber.Any(u => u.Flight_Number == obj.FlightNumber.Flight_Number);

			if (ModelState.IsValid && !flightNumberExists)
			{
				_unitOfWork.FlightNumber.Add(obj.FlightNumber);
				_unitOfWork.Save();
				TempData["success"] = "The Flight has been created successfully.";
				return RedirectToAction(nameof(Index));
			}

			if (flightNumberExists)
			{
				TempData["error"] = "The flight number already exists.";
			}
			obj.FlightList = _unitOfWork.FlightNumber.GetAll().Select(u => new SelectListItem
			{
				Text = u.Plane,
				Value = u.Id.ToString()

			});

			return View(obj);
		}

		public IActionResult Update(int flightNumberId)
		{
			FlightNumberVM flightNumberVM = new()
			{

				FlightList = _unitOfWork.Flight.GetAll().Select(u => new SelectListItem
				{
					Text = u.Plane,
					Value = u.Id.ToString()

				}),
				FlightNumber = _unitOfWork.FlightNumber.Get(_ => _.Flight_Number == flightNumberId)
			};
			if (flightNumberVM.FlightNumber is null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(flightNumberVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(FlightNumberVM flightNumberVM)
		{


			if (ModelState.IsValid)
			{
				_unitOfWork.FlightNumber.Update(flightNumberVM.FlightNumber);
				_unitOfWork.Save();
				TempData["success"] = "The Flight has been updated successfully.";
				return RedirectToAction(nameof(Index));
			}

			flightNumberVM.FlightList = _unitOfWork.Flight.GetAll().Select(u => new SelectListItem
			{
				Text = u.Plane,
				Value = u.Id.ToString()

			});

			return View(flightNumberVM);

		}
		public IActionResult Delete(int flightNumberId)
		{
			FlightNumberVM flightNumberVM = new()
			{

				FlightList = _unitOfWork.Flight.GetAll().Select(u => new SelectListItem
				{
					Text = u.Plane,
					Value = u.Id.ToString()

				}),
				FlightNumber = _unitOfWork.FlightNumber.Get(_ => _.Flight_Number == flightNumberId)
			};
			if (flightNumberVM.FlightNumber is null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(flightNumberVM);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(FlightNumberVM flightNumberVM)
		{
			FlightNumber? objFromDb = _unitOfWork.FlightNumber
				.Get(_ => _.Flight_Number == flightNumberVM.FlightNumber.Flight_Number);
			if (objFromDb is not null)
			{
				_unitOfWork.FlightNumber.Remove(objFromDb);
				_unitOfWork.Save();

				TempData["success"] = "The Flight Number has been deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "The Flight could not be deleted.";
			return View(flightNumberVM);
		}
	}
}
