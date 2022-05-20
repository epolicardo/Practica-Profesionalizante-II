namespace Data.Entities
{
    public class Customers : EntityBase
    {
        public bool IsMarkedAsVIP { get; set; }
        //[ForeignKey("FavoriteProducts")]
        ////public List<Products> FavoriteProducts { get; set; }
        //[ForeignKey("LastOrdered")]
        //public List<Products> LastOrdered { get; set; }
        //public List<Businesses> FavoriteBusinesses { get; set; }
        //public List<Businesses> LastVisited { get; set; }


        public Users User { get; set; }
       
    }

    public enum Status
    {
        Activo = 1,
        Inactivo = 0
    }

}

