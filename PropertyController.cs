using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientCredentialsGrant.Controllers
{
    public class PropertyController : ApiController
    {
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetProperty(int propertyID)
        {
            int clientID = OwinContextExtensions.GetClientID();
            try
            {
                //var result = Service or DB Call(clientID, propertyID)
                return Json(new
                {
                    PropertyName = string.Format("Property - {0}", propertyID),
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
