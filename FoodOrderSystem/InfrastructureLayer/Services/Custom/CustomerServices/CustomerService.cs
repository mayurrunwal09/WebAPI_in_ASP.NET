using Domain.Model;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Services.Custom.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Customer student = await _repository.GetById(id);
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

        public Task<Customer> Find(Expression<Func<Customer, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<CustomerViewModel>> GetAll()
        {
           ICollection<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            ICollection<Customer> customers = await _repository.GetAll();
            foreach (Customer customer in customers)
            {
                CustomerViewModel viewmodel = new()
                {
                    Id = customer.Id,
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    City = customer.City,
                    Mobileno = customer.Mobileno,
                    Gender = customer.Gender,
                    

                };
                customerViewModels.Add(viewmodel);
            }
            return customerViewModels;
        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            var customer = await _repository.GetById(id);
            if (customer == null)
            {
                return null;
            }
            else
            {
                CustomerViewModel viewModel = new()
                {
                    Id = customer.Id,
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    City = customer.City,
                    Mobileno = customer.Mobileno,
                    Gender = customer.Gender,


                };
                return viewModel;
            }
        }

        public async Task<CustomerViewModel> GetByName(string name)
        {
            var customer = await _repository.GetByName(name);
            if (customer == null)
            {
                return null;
            }
            else
            {
                CustomerViewModel customersviewmodel = new()
                {
                    Id = customer.Id,
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    City = customer.City,
                    Mobileno = customer.Mobileno,
                    Gender = customer.Gender,
                };
                return customersviewmodel;
            }
        }

        public Customer GetLast()
        {
            return _repository.GetLast();
        }

        public Task<bool> Insert(InsertCustomer StudentInsertModel)
        {
            Customer customer = new()
            {
                CustomerId = StudentInsertModel.CustomerId,
                CustomerName = StudentInsertModel.CustomerName,
                City = StudentInsertModel.City,
                Gender = StudentInsertModel.Gender,
                Mobileno = StudentInsertModel.Mobileno,
            };
            return _repository.Insert(customer);
        }

        public async Task<bool> Update(UpdateCustomer StudentUpdateModel)
        {
            Customer customer = await _repository.GetById(StudentUpdateModel.Id);
            if (customer != null)
            {
                customer.CustomerId = StudentUpdateModel.CustomerId;
                customer.CustomerName = StudentUpdateModel.CustomerName;
                customer.City = StudentUpdateModel.City;
                customer.Gender = StudentUpdateModel.Gender;
                customer.Mobileno   = StudentUpdateModel.Mobileno;

                var result =  await _repository.Update(customer);
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
