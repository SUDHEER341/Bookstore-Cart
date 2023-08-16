using Bookstore.Cart.Entity;
using Bookstore.Cart.Interface;
using Newtonsoft.Json;

namespace Bookstore.Cart.Service
{
    public class BookService : IBookServices
    {
        public async Task<BookEntity> GetBookById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7075/api/Book/GetById?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiContent = await response.Content.ReadAsStringAsync();
                    ResponseEntity responseEntity = JsonConvert.DeserializeObject<ResponseEntity>(apiContent);
                    string bookContent = responseEntity.Data.ToString();
                    BookEntity book = JsonConvert.DeserializeObject<BookEntity>(bookContent);
                    return book;
                }
                return null;
            }

        }
    }
}
