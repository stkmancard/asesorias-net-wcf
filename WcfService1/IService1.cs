using System.Collections.Generic;
using System.ServiceModel;
using WcfService1.Clases;

namespace WcfService1
{
	[ServiceContract]
	public interface IService1
	{
		//	Listado medicamentos
		[OperationContract]
		List<MedicamentoCLS> listarMedicamentos();

		//	Lista forma farmaceutica
		[OperationContract]
		List<FormaFarmaceuticaCLS> listarFormaFarmaceutica();

		//	Recuperar medicamento
		[OperationContract]
		MedicamentoCLS recuperarMedicamento(int idMedicamento);

		//	Agregar y editar medicamento
		[OperationContract]
		int agregarEditarMedicamento(MedicamentoCLS inputMedicamentoCLS);

		//	Eliminar medicamento
		[OperationContract]
		int eliminarMedicamento(int idMedicamento);
	}
}
