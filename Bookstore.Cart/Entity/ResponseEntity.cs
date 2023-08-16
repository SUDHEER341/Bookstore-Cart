namespace Bookstore.Cart.Entity
{
    public class ResponseEntity
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "Execution successfully done!";
    }
}
