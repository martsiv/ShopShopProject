using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic.DTOs
{
	public class DeliveryDto
	{
		public int Id { get; set; }
		public int DeliveryCompanyId { get; set; }
		public string? DeliveryCompanyName { get; set; }
		public int? DeliveryHomeAddressId { get; set; }
		public int AdvertisementId { get; set; }
		public string? Street { get; set; }
		public string? Build { get; set; }
		public string? Appartment { get; set; }
		public string? ExtraInfoForCourier { get; set; }
		public string City { get; set; }
		public string PostOffice { get; set; }
		public DateTime CheckoutDate { get; set; }

	}
}
