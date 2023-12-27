using Microsoft.EntityFrameworkCore;
 
namespace TestSectorsApp.Domin
{
    [PrimaryKey("Id")]
    public class Sectors
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}


 