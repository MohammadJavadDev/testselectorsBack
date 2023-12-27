using System.ComponentModel.DataAnnotations;

namespace testselectors.Domin
{
    public class AcceptForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorsId { get; set; }
        public bool Agree { get; set; }
    }
}

