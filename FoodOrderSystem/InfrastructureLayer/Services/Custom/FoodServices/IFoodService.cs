using Domain.Model;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.FoodServices
{
    public  interface IFoodService
    {
        Task<ICollection<FoodViewModel>> GetAll();
        Task<FoodViewModel> GetById(int id);
        Task<FoodViewModel> GetByName(string name);
        Food GetLast();
        Task<bool> Insert( InserFood inserFood);
        Task<bool> Update(UpdateFood StudentUpdateModel);
        Task<bool> Delete(int id);
        Task<Food> Find(Expression<Func<Food, bool>> match);
    }
}
