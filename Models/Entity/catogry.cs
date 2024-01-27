namespace bookstore1.Models.Entity
{
    public class Catogry
    {
        public int CatogryId{ set; get; }
        public string CatogryName { set; get;}
        public ICollection<Book>? Books { set; get; }    
    }
}
