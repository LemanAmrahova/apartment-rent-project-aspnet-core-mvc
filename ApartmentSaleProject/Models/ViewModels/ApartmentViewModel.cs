namespace ApartmentSaleProject.Models.ViewModels
{
    public class ApartmentViewModel
    {
        public int Id { get; set; }
        public int BId { get; set; }
        public int Number { get; set; }
        public int NumOfRooms { get; set; }
        public double Kv { get; set; }
        public double Price { get; set; }
        public List<Block>? bList { get; set; }
    }
}
