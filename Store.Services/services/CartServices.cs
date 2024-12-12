using Store.Data.Models;
using Store.Repo.interfaces;
using Store.Repo.repos;
using Store.Services.DTO;
using Store.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.services
{
    public class CartServices : IcartServices
    {
        private readonly Icart _cart;
        private readonly IcartOnProduct _cartOnProduct;
        private readonly IProduct _product;

        public CartServices(Icart cart,IcartOnProduct cartOnProduct)
        {
            _cart = cart;
            _cartOnProduct = cartOnProduct;
        }

        public async Task addCartAsync(string userID, cartAddDto cartDTO)
        {

            var userCart = await _cart.GetUserCartByIdAsync(userID);
            if (userCart == null)
            {
                Cart cart = new Cart()
                {
                    userID = userID,
                };
                var newCart = await _cart.creatCartGetAsync(cart);
                ProductOnCart productOnCart = new ProductOnCart()
                {
                    quantity = cartDTO.quantityInCart,
                    productID = cartDTO.productsID,
                    cartID = newCart.ID
                };
                await _cartOnProduct.addCartOnProductAsync(productOnCart);
            }
            else
            {
                ProductOnCart productOnCart = new ProductOnCart()
                {
                    quantity = cartDTO.quantityInCart,
                    productID = cartDTO.productsID,
                    cartID = userCart.ID
                };
                await _cartOnProduct.addCartOnProductAsync(productOnCart);
            }
        }

        public void removeCartGetAsync(string userID, int id)
        {

        }

        public async Task updateProudctCart(string userID, cartAddDto cartDTO)
        {
            var cart= await _cart.GetUserCartByIdAsync(userID);
            var productFromCart = await _cartOnProduct.getProductFromCartAsync(cartDTO.productsID,cart.ID);
            productFromCart.quantity = cartDTO.quantityInCart;
            if (cartDTO.quantityInCart == 0)
            {
                _cartOnProduct.removeProductFromCart(productFromCart);
            }
            else
            {
                _cartOnProduct.updateCartOnProduct(productFromCart);
            }
            
        }
    }
}
