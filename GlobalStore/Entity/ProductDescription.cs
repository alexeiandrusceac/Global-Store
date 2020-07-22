using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalStore.Entity
{


	public class ProductDescription
    {

		public int ID { get; set; }

		/// <summary>
		/// Numele descrierii
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Valoarea descrierii
		/// </summary>
		public string Value { get; set; }
		/// <summary>
		/// Valoarea descrierii in limba romana
		/// </summary>
		public string ValueRO { get; set; }
		/// <summary>
		/// Valoarea descrierii in limba rusa
		/// </summary>
		public string ValueRU { get; set; }
		/// <summary>
		/// Valoarea descrierii in limba engleza
		/// </summary>
		public string ValueEN { get; set; }
		/// <summary>
		/// Codul de identificare al produsului
		/// </summary>

		public int ProductCod { get; set; }
	}
}
