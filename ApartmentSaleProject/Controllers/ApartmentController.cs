using ApartmentSaleProject.Models;
using ApartmentSaleProject.Models.ViewModels;
using ApartmentSaleProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentSaleProject.Controllers
{
    public class ApartmentController : Controller
    {
        BlockRepository blockRepository = new BlockRepository();
        ApartmentRepository apartmentRepository = new ApartmentRepository();
        ContractRepository contractRepository = new ContractRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBlock()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddBlock(Block block)
        {
            blockRepository.AddBlock(block);
            return RedirectToAction("Blocks");
        }

        public IActionResult EditBlock(int id)
        {
            Block block = blockRepository.GetBlock(id).FirstOrDefault();
            return View(block);
        }

        [HttpPost]
        public IActionResult EditBlock(Block block)
        {

            Block data = new Block()
            {
                Name = block.Name,
                Id = block.Id,
                Status = block.Status
            };
            blockRepository.Update(data);
            
            return RedirectToAction("Blocks");
        }

        public IActionResult DeactiveBlock(int id)
        {
            blockRepository.Deactive(id);
            return RedirectToAction("Blocks");

        }

        public IActionResult Blocks()
        {
            IQueryable<Block> block = blockRepository.GetAllBlocks();
            return View(block);
        }

        public IActionResult AddApartment()
        {
            ApartmentViewModel model = new ApartmentViewModel()
            {
                bList = blockRepository.GetActiveBlocks()

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddApartment(ApartmentViewModel apartmentViewModel)
        {
            Apartment apartment = new Apartment()
            {
                BId = apartmentViewModel.BId,
                Number = apartmentViewModel.Number,
                NumOfRooms = apartmentViewModel.NumOfRooms,
                Kv = apartmentViewModel.Kv,
                Price = apartmentViewModel.Price
            };
            apartmentRepository.AddApartment(apartment);

            return RedirectToAction("Apartments");

        }

        public IActionResult EditApartment(int id)
        {
            Apartment apartment = apartmentRepository.GetApartment(id).FirstOrDefault();

            ApartmentViewModel model = new ApartmentViewModel()
            {
                Id = apartment.Id,
                BId = apartment.BId,
                Number = apartment.Number,
                NumOfRooms = apartment.NumOfRooms,
                Kv = apartment.Kv,
                Price = apartment.Price
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditApartment(ApartmentViewModel apartment)
        {

            Apartment data = new Apartment()
            {
                Id = apartment.Id,
                BId = apartment.BId,
                Number = apartment.Number,
                NumOfRooms = apartment.NumOfRooms,
                Kv = apartment.Kv,
                Price = apartment.Price
            };
            apartmentRepository.Update(data);

            return RedirectToAction("Apartments");
        }

        public IActionResult DeactiveApartment(int id)
        {
            apartmentRepository.Deactive(id);
            return RedirectToAction("Apartments");

        }

        public IActionResult Apartments()
        {
            IQueryable<ApartmentTableViewModel> apartment = apartmentRepository.GetAllApartment();
            return View(apartment);
        }

        public IActionResult AddContract()
        {
            ContractViewModel model = new ContractViewModel()
            {
                aList = apartmentRepository.GetActiveNumbers()

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddContract(ContractViewModel model)
        {
            Contract contract = new Contract()
            {
                AId = model.AId,
                Name = model.Name,
                Surname = model.Surname,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Price = apartmentRepository.GetPrice(model.AId)
            };
            contractRepository.AddContract(contract);
            apartmentRepository.Deactive(model.AId);
            return RedirectToAction("Contracts");
        }

        public IActionResult EditContract(int id)
        {
            Contract contract = contractRepository.GetContract(id).FirstOrDefault();

            ContractViewModel model = new ContractViewModel()
            {
                Id = contract.Id,
                AId = contract.AId,
                Name = contract.Name,
                Surname = contract.Surname,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditContract(ContractViewModel contract)
        {
            Contract data = new Contract()
            {
                Id = contract.Id,
                AId = contract.AId,
                Name = contract.Name,
                Surname = contract.Surname,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate
            };
            contractRepository.Update(data);

            return RedirectToAction("Contracts");
        }

        public IActionResult DeactiveContract(int id)
        {
            contractRepository.Deactive(id);
            return RedirectToAction("Contracts");

        }

        public IActionResult Contracts()
        {
            IQueryable<ContractTableViewModel> contract = contractRepository.GetDatas();
            return View(contract);
        }

    }
}
