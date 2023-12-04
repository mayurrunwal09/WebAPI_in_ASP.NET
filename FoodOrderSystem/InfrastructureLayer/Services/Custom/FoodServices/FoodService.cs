using Domain.Model;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _repository;
        private readonly IRepository<Order> _orderRepository;  // Assuming IOrderRepository is your order repository interface

        public FoodService(IRepository<Food> repository, IRepository<Order> orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Food student = await _repository.GetById(id);
                if (student != null)
                {
                    return await _repository.Delete(student);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Task<Food> Find(Expression<Func<Food, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<FoodViewModel>> GetAll()
        {
            ICollection<FoodViewModel> foodViewModels = new List<FoodViewModel>();
            ICollection<Food> foods = await _repository.GetAll();
            foreach (Food food in foods)
            {
                FoodViewModel foodView = new()
                {
                    Id = food.Id,
                    FoodName = food.FoodName,
                    FoodDescription = food.FoodDescription,
                };
                foodViewModels.Add(foodView);

            }
            return foodViewModels;
        }







        public async Task<FoodViewModel> GetById(int id)
        {
            var result = await _repository.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                FoodViewModel viewModel = new()
                {
                    Id = result.Id,
                    FoodName = result.FoodName,
                    FoodDescription = result.FoodDescription,
                };
                return viewModel;
            }
        }

        public async Task<FoodViewModel> GetByName(string name)
        {

            var result = await _repository.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                FoodViewModel viewModel = new()
                {
                    Id = result.Id,
                    FoodName = result.FoodName,
                    FoodDescription = result.FoodDescription,
                };
                return viewModel;
            }
        }

        public Food GetLast()
        {
            return _repository.GetLast();
        }

        public Task<bool> Insert(InserFood inserFood)
        {
            Food food = new()
            {
                FoodName = inserFood.FoodName,
                FoodDescription = inserFood.FoodDescription,
            };
            return _repository.Insert(food);
        }

        public async Task<bool> Update(UpdateFood StudentUpdateModel)
        {
            Food food = await _repository.GetById(StudentUpdateModel.Id);
            if (food != null)
            {
                food.FoodName = StudentUpdateModel.FoodName;
                food.FoodDescription = StudentUpdateModel.FoodDescription;

                var res = await _repository.Update(food);
                return res;
            }
            else
            {
                return false;
            }
        }
    }
}
