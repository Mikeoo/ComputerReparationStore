namespace ComputerReparationStore.Models
{
    public class ListAllParts
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Part Part { get; set; }
    }
}