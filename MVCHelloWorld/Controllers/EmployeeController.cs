using MVCHelloWorldVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace MVCHelloWorld.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["WebAPIURi"]);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;

            response = client.GetAsync(string.Format("api/EmployeeAPI/GetEmployees")).Result;

            IEnumerable<EmployeeVM> _EmployeeVMList= null;
            _EmployeeVMList = response.Content.ReadAsAsync<IEnumerable<EmployeeVM>>().Result;

            return View("Index", _EmployeeVMList);


        }

        public ActionResult InsertEmployee()
        {
            SelectList List = new SelectList(GetAllGenders(), "ID", "GenderDesc");
            ViewBag.Genders = List;
            return View("InsertEmployee",new EmployeeVM());
        }

        public ActionResult InsertEmployeeAdd(string Name,int Age,string Email,int GenderID)
        {
            EmployeeVM _EmployeeVM = new EmployeeVM();
            _EmployeeVM.Name = Name;
            _EmployeeVM.Age = Age;
            _EmployeeVM.Email = Email;
            _EmployeeVM.GenderID = GenderID;

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["WebAPIURi"]);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var content = new ObjectContent(_EmployeeVM.GetType(), _EmployeeVM, new JsonMediaTypeFormatter());
            HttpResponseMessage response = client.PostAsync("api/EmployeeAPI/InsertEmployee", content).Result;

            return RedirectToAction("Index", "Employee");
        }

        #region Functions
        private IEnumerable<GenderVM> GetAllGenders()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["WebAPIURi"]);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = null;

            response = client.GetAsync(string.Format("api/GenderAPI/GetGenders")).Result;

            IEnumerable<GenderVM> _List = null;
            _List = response.Content.ReadAsAsync<IEnumerable<GenderVM>>().Result;

            return _List;
        }
        #endregion
    }
}