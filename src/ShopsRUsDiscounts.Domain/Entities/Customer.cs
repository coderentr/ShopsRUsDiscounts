using System;
using ShopsRUsDiscounts.Domain.Enums;

namespace ShopsRUsDiscounts.Domain.Entities
{
	public class Customer : BaseEntity
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string PasswordSald { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}

