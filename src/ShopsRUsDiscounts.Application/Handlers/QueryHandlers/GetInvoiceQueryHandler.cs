using System;
using MediatR;
using ShopsRUsDiscounts.Application.Queries.Request;
using ShopsRUsDiscounts.Application.Queries.Response;
using ShopsRUsDiscounts.Domain.Interfaces;

namespace ShopsRUsDiscounts.Application.Handlers.QueryHandlers
{
    public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQueryRequest, BaseQueryResponse<GetInvoiceQueryResponse>>
    {
        IInvoiceRepository _invoiceRepository;
        public GetInvoiceQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<BaseQueryResponse<GetInvoiceQueryResponse>> Handle(GetInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseQueryResponse<GetInvoiceQueryResponse>() { IsSuccess = false };

            try
            {
                var data = _invoiceRepository.GetInvoiceByInvoiceNumber(request.InvoiceNumber);

                if (data is not null)
                {
                    var responseData = new GetInvoiceQueryResponse
                    {
                        InvoiceNumber = data.InvoiceNumber,
                        InvoiceAmount = data.InvoiceAmount,
                        OrderId = data.OrderId,
                        Description = data.Description,
                        DiscountAmount = data.DiscountAmount,
                        TotalAmount = data.TotalAmount
                    };
                    result.Data = responseData;
                    result.IsSuccess = true;
                }
                else
                {
                    result.Message = "Invoice not found";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invoice not found")
                {
                    result.Message = "Invoice not found"; 
                }
                else
                {
                    result.Message = "An unexpected error occurred.";
                }
            }

            return result;
        }
    }
}

