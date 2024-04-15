using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electron.Database.Models
{
    public class PersonDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public long? FatherId { get; set; }
        [ForeignKey(nameof(FatherId))]
        public PersonDbModel? Father { get; set; }

        public long? GrandFatherId { get; set; }
        [ForeignKey(nameof(GrandFatherId))]
        public PersonDbModel? GrandFather { get; set; }

        [InverseProperty(nameof(Father))]
        public IEnumerable<PersonDbModel> Kids { get; set; }

    }
}
