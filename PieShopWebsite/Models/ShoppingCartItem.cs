using System;
namespace PieShopWebsite.Models
{
	public class ShoppingCartItem
	{
		public int ShoppingCartItemId { get; set; }

        //The "= default!;" part initializes the property to the default value of "Pie" type, and the "!" indicates that it is non-nullable.
        public Pie Pie { get; set; } = default!;

		public int Amount { get; set; }

        //The "?" indicates that the property is nullable, meaning it can hold a null value in addition to a string value
        public string? ShoppingCartId { get; set; }
	}
}

