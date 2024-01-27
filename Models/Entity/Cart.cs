
namespace bookstore1.Models.Entity
{
    public class Cart
    {
        
        public int CartId { get; set; }
      
        public int BookId {  get; set; }
        public string Titel { get; set;}
        public decimal price {  get; set;}
        public int count {  get; set;}
        public decimal total { get; set;}

       public Book? Book { get; set;}
       
    }
}
