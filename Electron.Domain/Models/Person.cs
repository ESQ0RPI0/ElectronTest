namespace Electron.Domain.Models
{
    public sealed class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Person Father { get; set; }
        public Person GrandFather { get; set; }
    }
}
