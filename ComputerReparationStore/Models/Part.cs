namespace ComputerReparationStore.Models
{
    public class Part
    {
        public int Id { get; set; }
        public bool InStock { get; set; }
        public PartListItem PartListItem { get; set; }
    }
}