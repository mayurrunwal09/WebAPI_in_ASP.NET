using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.SupplierServices
{
    public  interface ISupplierService
    {
        Task<ICollection<SupplierViewModel>> GetAll();
        Task<SupplierViewModel> GetById(int id);
        Task<SupplierViewModel> GetByName(string name);
        Supplier GetLast();
        Task<bool> Insert(InsertSupplier inserFood);
        Task<bool> Update(UpdateSupplier StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Supplier> Find(Expression<Func<Supplier, bool>> match);
    }
}
