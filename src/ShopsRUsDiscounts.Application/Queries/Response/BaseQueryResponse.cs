using System;
namespace ShopsRUsDiscounts.Application.Queries.Response
{
	public class BaseQueryResponse<T>
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
        public T Data { get; set; }
	}
}

