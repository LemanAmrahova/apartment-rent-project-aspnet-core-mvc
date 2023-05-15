using ApartmentSaleProject.Models;
using ApartmentSaleProject.Models.ViewModels;

namespace ApartmentSaleProject.Repositories
{
    public class ApartmentRepository
    {
        public void AddApartment(Apartment apartment)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            db.Apartments.Add(apartment);
            db.SaveChanges();
        }

        public void Update(Apartment apartment)
        {            
            ApartmentDbContext db = new ApartmentDbContext();
            Apartment data = db.Apartments.Where(x => x.Id == apartment.Id).FirstOrDefault();
            data.Number = apartment.Number;
            data.NumOfRooms = apartment.NumOfRooms;
            data.Kv = apartment.Kv;
            data.Price = apartment.Price;
            db.SaveChanges();
        }

        public void Deactive(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            Apartment apartment = db.Apartments.Where(x => x.Id == id).FirstOrDefault();
            apartment.Status = false;
            db.SaveChanges();
        }

        public IQueryable<Apartment> GetDatas()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<Apartment> apartments = db.Apartments;
            return apartments;
        }

        public List<Apartment> GetActiveNumbers()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            return db.Apartments.Where(x => x.Status == true).ToList();
        }

        public double GetPrice(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            return db.Apartments.Where(x => x.Id == id).Select(x => x.Price).FirstOrDefault();
        }

        public IQueryable<Apartment> GetApartment(int id)
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<Apartment> apartment = db.Apartments;
            return apartment.Where(x => x.Id == id);
        }

        public IQueryable<ApartmentTableViewModel> GetAllApartment()
        {
            ApartmentDbContext db = new ApartmentDbContext();
            IQueryable<ApartmentTableViewModel> apartments = (from b in db.Blocks
                                                            join a in db.Apartments on b.Id equals a.BId
                                                            select new ApartmentTableViewModel
                                                            {
                                                                Id = a.Id,
                                                                Block = b.Name,
                                                                Number = a.Number,
                                                                NumOfRooms = a.NumOfRooms,
                                                                Kv = a.Kv,
                                                                Price = a.Price,
                                                                Status = a.Status
                                                            });
            return apartments;
        }
    }
}
