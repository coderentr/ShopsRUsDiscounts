using System;
using ShopsRUsDiscounts.Domain.Entities;

namespace ShopsRUsDiscounts.Domain.Events
{
	public class SyncInvoiceEvent
	{
        public Invoice Invoice { get; set; }
    }
}

