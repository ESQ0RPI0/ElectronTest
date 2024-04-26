using System.ComponentModel.DataAnnotations;

namespace Electron.Api.Forms
{
    public sealed record UpdatePersonForm
    {
        [Range(1, long.MaxValue, ErrorMessage = $"Значение идентификатора вне допустимого диапазона")]
        public long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = $"Значение идентификатора отца вне допустимого диапазона")]
        public long? FatherId { get; set; }
    }
}
