using System;
namespace ShopsRUsDiscounts.Application.Commands.Response
{
    public class BaseCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

