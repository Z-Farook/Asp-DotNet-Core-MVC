using System.Collections.Generic;
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
#if false
        //Using an Asynchronous Enumerable 
        //this method does not pass the result to the caller until all HTTP are done
        public static async Task<IEnumerable<long?>> GetPageLengths(List<string> output, params string[] urls)
        {
            List<long?> results = new List<long?>();
            HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                results.Add(httpMessage.Content.Headers.ContentLength);
                output.Add($"Completed request for {url}");
            }
            return results;
        }
#endif
        //Using an Asynchronous Enumerable 
        // this method solve the problem above (the wating)
        public static async IAsyncEnumerable<long?> GetPageLengths(List<string> output, params string[] urls)
        {
            List<long?> results = new List<long?>();
            HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync($"http://{url}");
                results.Add(httpMessage.Content.Headers.ContentLength);
                output.Add($"Completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }

        }

    }
}