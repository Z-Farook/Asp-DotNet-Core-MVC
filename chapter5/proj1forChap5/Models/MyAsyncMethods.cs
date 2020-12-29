using System.Net.Http;
using System.Threading.Tasks;
namespace proj1forChap5.Models
{
    public class MyAsyncMethods
    {
#if false //when Working with Tasks directly
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
           {
               return antecedent.Result.Content.Headers.ContentLength;
           });
        }
#endif
        //when using keywords await
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}