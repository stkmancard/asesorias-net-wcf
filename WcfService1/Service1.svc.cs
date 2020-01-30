using System;
using System.Collections.Generic;
using System.Linq;
using WcfService1.Clases;
using WcfService1.Modelos;

namespace WcfService1
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{
		int IService1.agregarEditarMedicamento(MedicamentoCLS inputMedicamentoCLS)
		{
			throw new NotImplementedException();
		}

		int IService1.eliminarMedicamento(int idMedicamento)
		{
			int respuesta = 0;

			try
			{
				using (var bd = new MedicoEntities())
				{
					Medicamento oMedicamento = bd.Medicamento.Where(p => p.IIDMEDICAMENTO == idMedicamento).First();
					oMedicamento.BHABILITADO = 0;
					bd.SaveChanges();
					respuesta = 1;
				}
			}
			catch (Exception exc)
			{
				respuesta = 0;
			}
			return respuesta;
		}

		List<FormaFarmaceuticaCLS> IService1.listarFormaFarmaceutica()
		{
			List<FormaFarmaceuticaCLS> listaFormaFarmaceutica = new List<FormaFarmaceuticaCLS>();
			try
			{
				using (var bd = new MedicoEntities())
				{
					listaFormaFarmaceutica = bd.FormaFarmaceutica.Select(p => new FormaFarmaceuticaCLS
					{
						idFormaFarmaceutica = p.IIDFORMAFARMACEUTICA,
						nombreFormaFarmaceutica = p.NOMBRE
					}).ToList();
				}
			}
			catch (Exception exc)
			{
				listaFormaFarmaceutica = null;
			}
			return listaFormaFarmaceutica;
		}
		

		List<MedicamentoCLS> IService1.listarMedicamentos()
		{
			List<MedicamentoCLS> listaMedicamento = new List<MedicamentoCLS>();
			try
			{
				using (var bd = new MedicoEntities())
				{
					listaMedicamento = (from medicamento in bd.Medicamento
										join formafarmaceutica in bd.FormaFarmaceutica
										on medicamento.IIDFORMAFARMACEUTICA equals formafarmaceutica.IIDFORMAFARMACEUTICA
										select new MedicamentoCLS
										{
											idMedicamento = medicamento.IIDMEDICAMENTO,
											nombre = medicamento.NOMBRE,
											presentacion = medicamento.PRESENTACION,
											precio = (decimal)medicamento.PRECIO,
											concentracion = medicamento.CONCENTRACION,
											stock = (int)medicamento.STOCK
										}).ToList();
				}
			}
			catch (Exception)
			{
				listaMedicamento = null;
			}
			return listaMedicamento;
		}

		MedicamentoCLS IService1.recuperarMedicamento(int idMedicamento)
		{
			MedicamentoCLS oMedicamentoCLS = new MedicamentoCLS();
			try
			{
				using (var bd = new MedicoEntities())
				{
					Medicamento medicamento = bd.Medicamento.Where(p => p.IIDMEDICAMENTO == idMedicamento).First();
					oMedicamentoCLS.idMedicamento = medicamento.IIDMEDICAMENTO;
					oMedicamentoCLS.nombre = medicamento.NOMBRE;
					oMedicamentoCLS.precio = (decimal)medicamento.PRECIO;
					oMedicamentoCLS.stock = (int)medicamento.STOCK;
					oMedicamentoCLS.concentracion = medicamento.CONCENTRACION;
					oMedicamentoCLS.presentacion = medicamento.PRESENTACION;
				}
				return oMedicamentoCLS;
			}
			catch (Exception)
			{
				return oMedicamentoCLS;
			}
		}
	}
}
