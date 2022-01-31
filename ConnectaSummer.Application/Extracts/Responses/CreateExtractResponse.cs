using ConnectaSummer.Domain;
using System;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Extracts.Responses
{
    public class CreateExtractResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public Guid ExtractId { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
