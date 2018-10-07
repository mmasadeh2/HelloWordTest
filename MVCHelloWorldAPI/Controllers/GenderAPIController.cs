using MVCHelloWorldDAL;
using MVCHelloWorldVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVCHelloWorldAPI.Controllers
{
    public class GenderAPIController : ApiController
    {
        #region GET
        [HttpGet]
        [Route("api/GenderAPI/GetGenders")]
        [ResponseType(typeof(IEnumerable<GenderVM>))]
        public IHttpActionResult GetGenders()
        {
            try
            {
                using (GenderDAL _GenderDAL = new GenderDAL())
                {
                    return Ok(_GenderDAL.GetAllGenders());
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        #endregion
    }
}
