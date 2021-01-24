using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using proj1forchap7.Infrastructure;
namespace proj1forchap7.Models
{
    public class SessionCart : Cart
    {
        /// <summary>
        /// Getting hold of the ISession object is a little complicated. 
        /// I obtain an instance of the IHttpContextAccessor service, whichprovides me with access to an HttpContext object that, in turn, provides me with the ISession.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}