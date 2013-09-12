using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Data;
using System.Linq.Expressions;

namespace Web.Service.Customers
{
    public class CustomerService:BaseService,ICustomerService
    {
        public CustomerService()
            : base()
        {

        }
        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (customer.IsSystemAccount)
                throw new Exception(string.Format("System customer account ({0}) could not be deleted", customer.SystemName));

            customer.Deleted = true;

            
            UpdateCustomer(customer);
        }

        public Customer GetCustomerById(int customerId)
        {
           return _dataContext.Customers.FirstOrDefault(e => e.Id == customerId);
        }

        public IList<Customer> GetCustomersByIds(int[] customerIds)
        {
            return _dataContext.Customers.Where(e =>customerIds.Contains(e.Id)).ToList();
        }

        public Customer GetCustomerByGuid(Guid customerGuid)
        {
            return _dataContext.Customers.FirstOrDefault(e => e.CustomerGuid == customerGuid);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _dataContext.Customers.FirstOrDefault(e => e.Email == email);
        }

        public Customer GetCustomerBySystemName(string systemName)
        {
            return _dataContext.Customers.FirstOrDefault(e => e.SystemName == systemName);
        }

        public Customer GetCustomerByUsername(string username)
        {
            return _dataContext.Customers.FirstOrDefault(e => e.Username == username);
        }

        public Customer InsertGuestCustomer()
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            _dataContext.Customers.InsertOnSubmit(customer);
            SubmitContext();
        }

        public void UpdateCustomer(Customer customer)
        {
           //Customer c= GetCustomerById(customer.Id);
           //c.Active = customer.Active;
           //c.AdminComment = customer.AdminComment;
           //c.AffiliateId = customer.AffiliateId;
           //c.CreatedOnUtc = customer.CreatedOnUtc;
           //c.CustomerGuid = customer.CustomerGuid;
           //c.Deleted = customer.Deleted;
           // c.Email=
            //make sure the customer is from db.
            SubmitContext();
        }

        public int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            var guestRole = GetCustomerRoleBySystemName(SystemCustomerRoleNames.Guests);
            if (guestRole == null)
                throw new Exception("'Guests' role could not be loaded");

            var query =_dataContext.Customers.AsQueryable();
            if (createdFromUtc.HasValue)
                query = query.Where(c => createdFromUtc.Value <= c.CreatedOnUtc);
            if (createdToUtc.HasValue)
                query = query.Where(c => createdToUtc.Value >= c.CreatedOnUtc);
           
          
            //don't delete system accounts
            query = query.Where(c => !c.IsSystemAccount);

            //only distinct customers (group by ID)
            query = from c in query
                    group c by c.Id
                        into cGroup
                        orderby cGroup.Key
                        select cGroup.FirstOrDefault();
            query = query.OrderBy(c => c.Id);
            var customers = query.ToList();


            int numberOfDeletedCustomers = customers.Count;

            _dataContext.Customers.DeleteAllOnSubmit(customers);
            base.SubmitContext();

            return numberOfDeletedCustomers;
        }

        public void DeleteCustomerRole(CustomerRole customerRole)
        {
            _dataContext.CustomerRoles.DeleteOnSubmit(customerRole);
            base.SubmitContext();
        }

        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            return _dataContext.CustomerRoles.FirstOrDefault(e => e.Id == customerRoleId);
        }

        public CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            return _dataContext.CustomerRoles.FirstOrDefault(e => e.SystemName == systemName);
        }

        public IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            return _dataContext.CustomerRoles.Where(e => e.Active == showHidden).ToList();
        }

        public void InsertCustomerRole(CustomerRole customerRole)
        {
            _dataContext.CustomerRoles.InsertOnSubmit(customerRole);
            base.SubmitContext();
        }

        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            //todo....
            //base.SubmitContext(); throw new NotImplementedException();
        }
    }
}
