using Domain.Model;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Order student = await _repository.GetById(id);
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

        public Task<Order> Find(Expression<Func<Order, bool>> match)
        {
           return _repository.Find(match);
        }

        public async Task<ICollection<OrderViewModel>> GetAll()
        {
            ICollection<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            ICollection<Order> orders = await _repository.GetAll();
            foreach (Order order in orders)
            {
                OrderViewModel viewModel = new()
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    FoodId = order.FoodId,
                    Quantity = order.Quantity,
                    
                };
                orderViewModels.Add(viewModel);
            }
            return orderViewModels;
        }

        public async Task<OrderViewModel> GetById(int id)
        {
            var result = await _repository.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderViewModel viewModel = new()
                {
                    Id = result.Id,
                    CustomerId = result.CustomerId,
                    FoodId = result.FoodId,
                    Quantity = result.Quantity,
                };
                return viewModel;
            }
        }

        public async Task<OrderViewModel> GetByName(string name)
        {
            var result = await _repository.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                OrderViewModel viewModel = new()
                {
                    Id = result.Id,
                    CustomerId = result.CustomerId,
                    FoodId = result.FoodId,
                    Quantity = result.Quantity,
                };
                return viewModel;
            }
        }

        public Order GetLast()
        {
           return _repository.GetLast();
        }

        public Task<bool> Insert(InsertOrder inserFood)
        {
            Order order = new Order()
            {
                CustomerId = inserFood.CustomerId,
                FoodId = inserFood.FoodId,
                Quantity = inserFood.Quantity,
            };
            return _repository.Insert(order);
        }

        public async Task<bool> Update(UpdateOrder StudentUpdateModel)
        {
            Order student = await _repository.GetById(StudentUpdateModel.Id);
            if (student != null)
            {
                student.CustomerId = StudentUpdateModel.CustomerId;
                student.FoodId  = StudentUpdateModel.FoodId;
                student.Quantity = StudentUpdateModel.Quantity;

                var result = await _repository.Update(student);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
