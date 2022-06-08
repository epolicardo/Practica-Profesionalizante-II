namespace OrderNow.API.Services
{
    public class OrdersServices
    {


        public Orders CreateOrder(Businesses businesses, User user)
        {
            Orders order = new Orders();
            order.Business = businesses;
            order.User = user;
            return order;
            
        }
        public void AddProductToOrder(Orders orders, Products product, float quantity)
        {

        }

        public void RemoveProductFromOrder(Orders orders, Products product, float quantity)
        {

        }

        public void ModifyProductInOrder(Orders orders, Products product, float quantity)
        {

        }
    }
}
