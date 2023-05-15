namespace ApartmentSaleProject.Models.ViewModels
{
    public class ContractTableViewModel
    {
        public int Id { get; set; }
        public int ANumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Price { get; set; }
        public bool? Status { get; set; }
    }
}
