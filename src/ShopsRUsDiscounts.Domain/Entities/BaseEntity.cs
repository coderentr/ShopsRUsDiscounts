namespace ShopsRUsDiscounts.Domain.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }

		public DateTime CreaatedDate { get; set; } = DateTime.Now.ToUniversalTime();

		public DateTime? UpdatedDate { get; set; }
	}
}

