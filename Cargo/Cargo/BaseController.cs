using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service.Authentication;
using Web.Service.Customers;
using Web.Service;
using Web.Framework.Core;
using Web.Framework.Security;
using Web.Service.Security;
using Web.Data;
using Web.Framework.UI;

namespace Cargo
{
    public class BaseController:Controller
    {
        protected readonly IAuthenticationService _authenticationService;
        protected readonly ICustomerService _customerService;
        protected readonly ICustomerRegistrationService _customerRegService;
        protected readonly IWorkContext _workContext;
        protected readonly IEncryptionService _encryptionService;
        protected HttpContextBase _httpContext;

        protected readonly IPermissionService _permissionService;
       // protected DBDataClassesDataContext _dbContext;
        public BaseController()
        {
            if (_httpContext == null)
            {
                _httpContext = System.Web.HttpContext.Current != null ?
                     (new HttpContextWrapper(System.Web.HttpContext.Current) as HttpContextBase) :
                     (new FakeHttpContext("~/") as HttpContextBase);
            }
            //if (_dbContext == null)
            //{
            //    _dbContext = new DBDataClassesDataContext();
            //}
            if (_customerService == null)
            {
                _customerService = new CustomerService();
            }
            if(_encryptionService==null)
            {
                _encryptionService=new EncryptionService();
            }
            if (_customerRegService == null)
            {
                _customerRegService = new CustomerRegistrationService(_customerService, _encryptionService);
            }
            if (_authenticationService == null)
            {
                this._authenticationService = new FormsAuthenticationService(_httpContext, _customerService);
            }
            if (_workContext == null)
            {
                this._workContext = new WebWorkContext(_httpContext, _customerService);
            }
            if (_permissionService == null)
            {
                this._permissionService = new PermissionService(_workContext);
            }
            if (_workContext != null && _workContext.CurrentCustomer != null)
            {
                ViewBag.UserName = _workContext.CurrentCustomer.Username;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
           
            //todo....
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exc">Exception</param>
        private void LogException(Exception exc)
        {
           //todo...
        }
        /// <summary>
        /// Display success notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyTypeEnum.Success, message, persistForTheNextRequest);
        }
        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyTypeEnum.Error, message, persistForTheNextRequest);
        }
        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="logException">A value indicating whether exception should be logged</param>
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            if (logException)
                LogException(exception);
            AddNotification(NotifyTypeEnum.Error, exception.Message, persistForTheNextRequest);
        }
        /// <summary>
        /// Display notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void AddNotification(NotifyTypeEnum type, string message, bool persistForTheNextRequest)
        {
            string dataKey = string.Format("cargo.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }
    }
}