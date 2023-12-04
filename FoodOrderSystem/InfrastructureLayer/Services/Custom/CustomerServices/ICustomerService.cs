using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.CustomerServices
{
    public  interface ICustomerService
    {
        Task<ICollection<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(int id);
        Task<CustomerViewModel> GetByName(string name);
        Customer GetLast();
        Task<bool> Insert(InsertCustomer StudentInsertModel);
        Task<bool> Update(UpdateCustomer StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Customer> Find(Expression<Func<Customer, bool>> match);
    }
}
