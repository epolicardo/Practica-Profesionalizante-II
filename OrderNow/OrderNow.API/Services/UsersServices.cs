namespace Services
{
    public class UsersServices
    {

        public bool AssignFavoriteBusinessToUser(User user, Businesses business)
        {

            if (user == null) { return false; }

            if (business == null) { return false; }

            if (user.FavoriteBusiness==null)
            {
                user.FavoriteBusiness = new List<Businesses>();
            }
            user.FavoriteBusiness.Add(business);
            return true;
        }

        public bool AssignFavoriteProductsToUsers(User user, Products product)
        {
            if (user == null) { return false; }

            if (product == null) { return false; }

            if (user.FavoriteProducts == null)
            {
                user.FavoriteProducts  = new List<Products>();
            }
            user.FavoriteProducts.Add(product);
            return true;
        }
    }
}
