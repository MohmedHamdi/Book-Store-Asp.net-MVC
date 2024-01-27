namespace bookstore1.Models.Entity
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
       public ICollection<Book>? Books { get; set; }
    }
}
