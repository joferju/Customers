using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Customers.Authentication
{
    public class SecurityRequirementsDocumentFilter : IDocumentFilter
    {
        //NOTE: this is required by latest version of Swashbuckle to apply the auth.
        public void Apply(SwaggerDocument document, DocumentFilterContext context)
        {
            document.Security = new List<IDictionary<string, IEnumerable<string>>>()
            {
                new Dictionary<string, IEnumerable<string>>()
                {
                    { "basic", new string[]{ } }
                }
            };
        }
    }
}
