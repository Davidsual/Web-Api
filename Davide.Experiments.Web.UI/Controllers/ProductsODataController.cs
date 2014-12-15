using Davide.Experiments.Web.UI.Models;
using Microsoft.OData.Core;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;

namespace Davide.Experiments.Web.UI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Davide.Experiments.Web.UI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("ProductsOData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsODataController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/ProductsOData
        public async Task<IHttpActionResult> GetProductsOData(ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Product>>(products);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ProductsOData(5)
        public async Task<IHttpActionResult> GetProduct([FromODataUri] int key, ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Product>(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/ProductsOData(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Product> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(product);

            // TODO: Save the patched entity.

            // return Updated(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ProductsOData
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ProductsOData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(product);

            // TODO: Save the patched entity.

            // return Updated(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ProductsOData(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
