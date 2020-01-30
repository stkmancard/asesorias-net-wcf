using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ServiceMedicamento;
using WebApplication1.ServiceMedicamentoDos;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ServiceMedicamentoDos.Service1Client cliente = new ServiceMedicamentoDos.Service1Client();
			List<ServiceMedicamentoDos.MedicamentoCLS> lista = cliente.listarMedicamentos().ToList();
			ViewBag.medicamentos = lista;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		
	}
}