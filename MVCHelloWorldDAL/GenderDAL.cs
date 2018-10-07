using MVCHelloWorldEntity.Models;
using MVCHelloWorldVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHelloWorldDAL
{
   public  class GenderDAL :IDisposable
    {
        MVCHelloWorldContext dbContext;

        #region Constructor
        public GenderDAL()
        {
            dbContext = new MVCHelloWorldContext();
        }

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        #endregion

        #region Get
        public IEnumerable<GenderVM> GetAllGenders()
        {
            List<Gender> ListGenders = dbContext.Genders.ToList();
            List<GenderVM> ListVMGenders = new List<GenderVM>();

            foreach (Gender _Gender2 in ListGenders)
            {
                GenderVM _GenderVM = new GenderVM();

                _GenderVM.ID = _Gender2.ID;
                _GenderVM.GenderDesc = _Gender2.GenderDesc;



                ListVMGenders.Add(_GenderVM);
            }

            return ListVMGenders;
        }
        #endregion
    }
}
