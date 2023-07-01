using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Infrastructure.Extensions;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart Cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

            Cart.Session = session;
            return Cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }

        public override void RemoveLine(Product product)
        {

            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}
