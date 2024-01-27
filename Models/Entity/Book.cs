using Microsoft.AspNetCore.Identity;

namespace bookstore1.Models.Entity
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId {  get; set; }
       public int CatogryId { set; get; }
        
     
        public string Title { get; set; }
       public int PublicationYrar {  get; set; }
        public decimal Price { get; set; }
        public Author? Author { get; set; }

        
        public Catogry? Catogry { get; set;}

      public ICollection<Cart> ?Carts { get; set; }
      
       
    }
}
