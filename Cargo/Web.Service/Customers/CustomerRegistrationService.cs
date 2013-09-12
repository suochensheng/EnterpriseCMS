using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Framework.Security;
using Web.Data;
using ApplicationUtility;

namespace Web.Service.Customers
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class CustomerRegistrationService:BaseService, ICustomerRegistrationService
    {
        private ICustomerService _customerService;
        private IEncryptionService _encryptionService;

        public CustomerRegistrationService(ICustomerService customerService, IEncryptionService encryptionService)
            : base()
        {
            this._customerService = customerService;
            this._encryptionService = encryptionService;
        }


       

        #region Methods

        /// <summary>
        /// Validate customer
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual bool ValidateCustomer(string email, string password)
        {
            Customer customer =  _customerService.GetCustomerByEmail(email);

            if (customer == null || customer.Deleted || !customer.Active)
                return false;

            //only registered can login
            if (!customer.IsRegistered())
                return false;

            string pwd = "";
            switch (customer.PasswordFormat())
            {
                case PasswordFormat.Encrypted:
                    pwd = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    pwd = _encryptionService.CreatePasswordHash(password, customer.PasswordSalt, _hashedPasswordFormat);
                    break;
                default:
                    pwd = password;
                    break;
            }

            bool isValid = pwd == customer.Password;

            //save last login date
            if (isValid)
            {
                customer.LastLoginDateUtc = DateTime.UtcNow;
                _customerService.UpdateCustomer(customer);
            }

            return isValid;
        }

        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Customer == null)
                throw new ArgumentException("Can't load current customer");

            var result = new CustomerRegistrationResult();

            if (request.Customer.IsRegistered())
            {
                result.AddError("Current customer is already registered");
                return result;
            }
            if (String.IsNullOrEmpty(request.Email))
            {
                result.AddError("Account.Register.Errors.EmailIsNotProvided");
                return result;
            }
            if (!CommonHelper.IsValidEmail(request.Email))
            {
                result.AddError("Email invalid.");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.Password))
            {
                result.AddError("PasswordIsNotProvided");
                return result;
            }

                if (String.IsNullOrEmpty(request.Username))
                {
                    result.AddError("UsernameIsNotProvided");
                    return result;
                }
            

            //validate unique user
            if (_customerService.GetCustomerByEmail(request.Email) != null)
            {
                result.AddError("Account.Register.Errors.EmailAlreadyExists");
                return result;
            }

                if (_customerService.GetCustomerByUsername(request.Username) != null)
                {
                    result.AddError("Account.Register.Errors.UsernameAlreadyExists");
                    return result;
                }


            //at this point request is valid
            request.Customer.Username = request.Username;
            request.Customer.Email = request.Email;
            request.Customer.PasswordFormatId = (int)request.PasswordFormat;

            switch (request.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    {
                        request.Customer.Password = request.Password;
                    }
                    break;
                case PasswordFormat.Encrypted:
                    {
                        request.Customer.Password = _encryptionService.EncryptText(request.Password);
                    }
                    break;
                case PasswordFormat.Hashed:
                    {
                        string saltKey = _encryptionService.CreateSaltKey(5);
                        request.Customer.PasswordSalt = saltKey;
                        request.Customer.Password = _encryptionService.CreatePasswordHash(request.Password, saltKey, _hashedPasswordFormat);
                    }
                    break;
                default:
                    break;
            }

            request.Customer.Active = request.IsApproved;

            //add to 'Registered' role
            var registeredRole = _customerService.GetCustomerRoleBySystemName(SystemCustomerRoleNames.Registered);
            if (registeredRole == null)
                throw new Exception("'Registered' role could not be loaded");
            Customer_CustomerRole_Mapping crm = new Customer_CustomerRole_Mapping();
            crm.Customer_Id = request.Customer.Id;
            crm.Customer = request.Customer;
            crm.CustomerRole = registeredRole;
            crm.CustomerRole_Id = registeredRole.Id;
            request.Customer.Customer_CustomerRole_Mappings.Add(crm);
            //remove from 'Guests' role
           
            var deletecrm= request.Customer.Customer_CustomerRole_Mappings.FirstOrDefault(e => e.CustomerRole.SystemName ==
                SystemCustomerRoleNames.Guests);

            if (deletecrm != null)
            {
                request.Customer.Customer_CustomerRole_Mappings.Remove(deletecrm);
            }

          
            _customerService.UpdateCustomer(request.Customer);
            return result;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual PasswordChangeResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var result = new PasswordChangeResult();
            if (String.IsNullOrWhiteSpace(request.Email))
            {
                result.AddError("Account.ChangePassword.Errors.EmailIsNotProvided");
                return result;
            }
            if (String.IsNullOrWhiteSpace(request.NewPassword))
            {
                result.AddError("Account.ChangePassword.Errors.PasswordIsNotProvided");
                return result;
            }

            var customer = _customerService.GetCustomerByEmail(request.Email);
            if (customer == null)
            {
                result.AddError("Account.ChangePassword.Errors.EmailNotFound");
                return result;
            }


            var requestIsValid = false;
            if (request.ValidateRequest)
            {
                //password
                string oldPwd = "";
                switch (customer.PasswordFormat())
                {
                    case PasswordFormat.Encrypted:
                        oldPwd = _encryptionService.EncryptText(request.OldPassword);
                        break;
                    case PasswordFormat.Hashed:
                        oldPwd = _encryptionService.CreatePasswordHash(request.OldPassword, customer.PasswordSalt, _hashedPasswordFormat);
                        break;
                    default:
                        oldPwd = request.OldPassword;
                        break;
                }

                bool oldPasswordIsValid = oldPwd == customer.Password;
                if (!oldPasswordIsValid)
                    result.AddError("Account.ChangePassword.Errors.OldPasswordDoesntMatch");

                if (oldPasswordIsValid)
                    requestIsValid = true;
            }
            else
                requestIsValid = true;


            //at this point request is valid
            if (requestIsValid)
            {
                switch (request.NewPasswordFormat)
                {
                    case PasswordFormat.Clear:
                        {
                            customer.Password = request.NewPassword;
                        }
                        break;
                    case PasswordFormat.Encrypted:
                        {
                            customer.Password = _encryptionService.EncryptText(request.NewPassword);
                        }
                        break;
                    case PasswordFormat.Hashed:
                        {
                            string saltKey = _encryptionService.CreateSaltKey(5);
                            customer.PasswordSalt = saltKey;
                            customer.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey, _hashedPasswordFormat);
                        }
                        break;
                    default:
                        break;
                }
                customer.PasswordFormatId = (int)request.NewPasswordFormat;
                _customerService.UpdateCustomer(customer);
            }

            return result;
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newEmail">New email</param>
        public virtual void SetEmail(Customer customer, string newEmail)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            newEmail = newEmail.Trim();
            string oldEmail = customer.Email;

            if (!CommonHelper.IsValidEmail(newEmail))
                throw new Exception("Account.EmailUsernameErrors.NewEmailIsNotValid");

            if (newEmail.Length > 100)
                throw new Exception("Account.EmailUsernameErrors.EmailTooLong");

            var customer2 = _customerService.GetCustomerByEmail(newEmail);
            if (customer2 != null && customer.Id != customer2.Id)
                throw new Exception("Account.EmailUsernameErrors.EmailAlreadyExists");

            customer.Email = newEmail;
            _customerService.UpdateCustomer(customer);

           
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newUsername">New Username</param>
        public virtual void SetUsername(Customer customer, string newUsername)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            newUsername = newUsername.Trim();

            if (newUsername.Length > 100)
                throw new Exception("Account.EmailUsernameErrors.UsernameTooLong");

            var user2 = _customerService.GetCustomerByUsername(newUsername);
            if (user2 != null && customer.Id != user2.Id)
                throw new Exception("Account.EmailUsernameErrors.UsernameAlreadyExists");
   
            customer.Username = newUsername;
            _customerService.UpdateCustomer(customer);
        }

        #endregion
    }
}
