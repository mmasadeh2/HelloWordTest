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
    public class EmployeeAPIController : ApiController
    {
        #region GET
        [HttpGet]
        [Route("api/EmployeeAPI/GetEmployees")]
        [ResponseType(typeof(IEnumerable<EmployeeVM>))]
        public IHttpActionResult GetEmployees()
        {
            try
            {
                using (EmployeeDAL _EmployeeDAL = new EmployeeDAL())
                {
                    return Ok(_EmployeeDAL.GetAllEmployees());
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
           
        }
        #endregion

        #region Insert
        [HttpPost]
        [Route("api/EmployeeAPI/InsertEmployee")]
        [ResponseType(typeof(int))]
        public IHttpActionResult InsertEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                using (EmployeeDAL _EmployeeDAL=new EmployeeDAL())
                {
                 return Ok(_EmployeeDAL.InsertEmployee(_EmployeeVM));

                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion

        #region Update
        [HttpPost]
        [Route("api/EmployeeAPI/UpdateEmployee")]
        [ResponseType(typeof(int))]
        public IHttpActionResult UpdateEmployee(EmployeeVM _EmployeeVM)
        {
            try
            {
                using (EmployeeDAL _EmployeeDAL = new EmployeeDAL())
                {
                    return Ok(_EmployeeDAL.UpdateEmployee(_EmployeeVM));

                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion

        #region Delete
        [HttpPost]
        [Route("api/EmployeeAPI/DeleteEmployee")]
        [ResponseType(typeof(int))]
        public IHttpActionResult DeleteEmployee(int EmployeeID)
        {
            try
            {
                using (EmployeeDAL _EmployeeDAL = new EmployeeDAL())
                {
                    return Ok(_EmployeeDAL.DeleteEmployee(EmployeeID));

                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion
    }
}
