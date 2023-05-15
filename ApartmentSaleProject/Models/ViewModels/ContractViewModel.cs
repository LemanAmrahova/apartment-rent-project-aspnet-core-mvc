namespace ApartmentSaleProject.Models.ViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public int AId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Apartment>? aList { get; set; }
    }
}
