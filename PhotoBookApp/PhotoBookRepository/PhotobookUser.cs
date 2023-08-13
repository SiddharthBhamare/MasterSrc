using System.ComponentModel.DataAnnotations;

namespace PhotoBookRepository
{
    public class PhotobookUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Person Person { get; set; }
    }
}