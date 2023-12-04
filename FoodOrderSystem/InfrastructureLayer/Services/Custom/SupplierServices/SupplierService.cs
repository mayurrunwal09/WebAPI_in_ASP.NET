using Domain.Model;
using Domain.ViewModels;
using Repository_And_Services.Repository;
using System.Linq.Expressions;

namespace Repository_And_Services.Services.Custom.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _repository;
        public SupplierService(IRepository<Supplier> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            if (id != null)
            {
                Supplier student = await _repository.GetById(id);
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

        public Task<Supplier> Find(Expression<Func<Supplier, bool>> match)
        {
            return _repository.Find(match);
        }

        public async Task<ICollection<SupplierViewModel>> GetAll()
        {
            ICollection<SupplierViewModel> studentViewModels = new List<SupplierViewModel>();

            ICollection<Supplier> students = await _repository.GetAll();

            foreach (Supplier student in students)
            {
                SupplierViewModel viewModel = new()
                {
                    Id = student.Id,
                   SupplierId = student.SupplierId,
                   SupplierName = student.SupplierName,
                   City = student.City,
                   Mobileno = student.Mobileno,
                   Gender = student.Gender, 
                };
                studentViewModels.Add(viewModel);
            }
            return studentViewModels;
        }

        public async Task<SupplierViewModel> GetById(int id)
        {
            var result = await _repository.GetById(id);
            if (result == null)
            {
                return null;
            }
            else
            {
                SupplierViewModel viewModel = new()
                {
                    Id = result.Id,
                    SupplierId = result.SupplierId,
                    SupplierName = result.SupplierName,
                    City = result.City,
                    Mobileno = result.Mobileno,
                    Gender = result.Gender,
                };
                return viewModel;
            }
        }

        public async Task<SupplierViewModel> GetByName(string name)
        {
            var result = await _repository.GetByName(name);
            if (result == null)
            {
                return null;
            }
            else
            {
                SupplierViewModel viewModel = new()
                {
                    Id = result.Id,
                    SupplierId = result.SupplierId,
                    SupplierName = result.SupplierName,
                    City = result.City,
                    Mobileno = result.Mobileno,
                    Gender = result.Gender,
                };
                return viewModel;
            }
        }

        public Supplier GetLast()
        {
            return _repository.GetLast();
        }

        public Task<bool> Insert(InsertSupplier inserFood)
        {
            Supplier supplier = new()
            {
                SupplierId = inserFood.SupplierId,
                SupplierName = inserFood.SupplierName,
                City = inserFood.City,
                Mobileno = inserFood.Mobileno,
                Gender = inserFood.Gender,
            };
            return _repository.Insert(supplier);
        }

        public async Task<bool> Update(UpdateSupplier StudentUpdateModel)
        {
            Supplier student = await _repository.GetById(StudentUpdateModel.Id);
            if (student != null)
            {
                student.SupplierId = StudentUpdateModel.SupplierId;
                student.SupplierName = StudentUpdateModel.SupplierName;
                student.City = StudentUpdateModel.City;
                student.Mobileno = StudentUpdateModel.Mobileno;
                student.Gender = StudentUpdateModel.Gender;
                    

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
