using ConnectaSummer.Domain;
using System.Collections.Generic;

namespace ConnectaSummer.Application.Extracts.Responses
{
    public class UpdateExtractResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<BrokenRoles> Erros { get; set; }
    }
}
