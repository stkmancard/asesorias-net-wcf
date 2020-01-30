using System.Runtime.Serialization;

namespace WcfService1.Clases
{
	[DataContract]
	public class MedicamentoCLS
	{
		[DataMember(Order = 0)]
		public int idMedicamento { get; set; }

		[DataMember(Order = 1)]
		public string nombre { get; set; }

		[DataMember(Order = 2)]
		public decimal precio { get; set; }

		[DataMember(Order = 3)]
		public string concentracion { get; set; }

		[DataMember(Order = 4)]
		public string nombreFormaFarmaceutica { get; set; }

		[DataMember(Order = 5)]
		public string presentacion { get; set; }

		[DataMember(Order = 6)]
		public int stock { get; set; }
	}
}