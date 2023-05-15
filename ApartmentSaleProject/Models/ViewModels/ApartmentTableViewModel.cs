namespace ApartmentSaleProject.Models.ViewModels
{
    public class ApartmentTableViewModel
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public int Number { get; set; }
        public int NumOfRooms { get; set; }
        public double Kv { get; set; }
        public double Price { get; set; }
        public bool? Status { get; set; }
    }
}
