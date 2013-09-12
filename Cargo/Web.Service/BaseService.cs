using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Data;
using System.Web;
using Web.Framework.Core;
using Web.Service.Customers;
using Web.Framework.Security;
using Web.Framework.Cache;

namespace Web.Service
{
    public class BaseService: IDisposable
    {
        private string _errorMessage;

        protected DBDataClassesDataContext _dataContext;

        protected readonly string _hashedPasswordFormat = "SHA1";

        private readonly ICacheManager _cacheManager=new MemoryCacheManager();
        private const string DBCONTEXT_PATTERN_KEY = "cargo.dbcontext.all";

        #region Ctors

        protected BaseService()
        {
            if (_dataContext == null)
            {
                this._dataContext =
                _cacheManager.Get(DBCONTEXT_PATTERN_KEY, () =>
                {
                    return InitDBContext();
                });
            }
           
        }
        protected  DBDataClassesDataContext InitDBContext()
        {
            return new DBDataClassesDataContext();
        }

        protected void RemoveDBContextCache()
        {
            _cacheManager.RemoveByPattern(DBCONTEXT_PATTERN_KEY);
        }

        #endregion

        protected bool SubmitContext()
        {
            bool result = true;
            try
            {
                _dataContext.SubmitChanges();
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                _errorMessage = exception.Message;
                result = false;
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                result = false;
            }
            return result;
        }

        public string ErrorMessage { get { return _errorMessage; } }


        #region IDisposable Members

        public void Dispose()
        {
            _dataContext.Dispose();
            this._dataContext = null;
        }

        #endregion
    }
}
