using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using proj1forChap5.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace proj1forChap5.Controllers
{
    //visit at: http://localhost:5000/AsyncAndAwait/index
    public class AsyncAndAwaitController : Controller
    {
#if false
        public async Task<string> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return $"Length: {length}";
        }
#endif

#if false
        //Using the first method which waits for the whole completion oF HTTP request 
         public async Task<List<string>> Index()
        {
            List<string> output = new List<string>();
            foreach (long? len in await MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length: { len}");
            }
            return output;
        }
#endif
        public async Task<List<string>> Index()
        {
            List<string> output = new List<string>();
            await foreach (long? len in MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length: { len}");
            }
            return output;
        }

    }
}