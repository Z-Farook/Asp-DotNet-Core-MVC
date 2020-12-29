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
        public async Task<string> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return $"Length: {length}";
        }
    }
}