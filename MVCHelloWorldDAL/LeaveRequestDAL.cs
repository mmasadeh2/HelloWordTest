using MVCHelloWorldEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHelloWorldDAL
{
    class LeaveRequestDAL
    {
        MVCHelloWorldContext dbContext;
        #region Constructor
        public LeaveRequestDAL()
        {
            dbContext = new MVCHelloWorldContext();
        }
         
        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        #endregion
    }
}
