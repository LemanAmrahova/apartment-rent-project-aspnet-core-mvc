using ApartmentSaleProject.Models;
using ApartmentSaleProject.Models.ViewModels;
using Microsoft.CodeAnalysis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApartmentSaleProject.Repositories
{
    public class ContractRepository
    {
        public void AddContract(Contract contract)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            db.Contracts.Add(contract);
            db.SaveChanges();
        }

        public void Update(Contract contract)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            Contract data = db.Contracts.Where(x => x.Id == contract.Id).FirstOrDefault();
            data.Name = contract.Name;
            data.Surname = contract.Surname;
            data.Price = contract.Price;
            data.StartDate = contract.StartDate;
            data.EndDate = contract.EndDate;
            db.SaveChanges();
        }

        public void Deactive(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            Contract contract = db.Contracts.Where(x => x.Id == id).FirstOrDefault();
            contract.Status = false;
            db.SaveChanges();
        }

        public IQueryable<ContractTableViewModel> GetDatas()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<ContractTableViewModel> contracts = (from a in db.Apartments
                            join c in db.Contracts on a.Id equals c.AId
                            select new ContractTableViewModel 
                            {
                                Id = c.Id,
                                ANumber = a.Number,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Name = c.Name,
                                Surname = c.Surname,
                                Price = c.Price,
                                Status = c.Status
                            });
            return contracts; 
        }
        public IQueryable<Contract> GetContract(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<Contract> contract = db.Contracts;
            return contract.Where(x => x.Id == id);
        }
    }
}
