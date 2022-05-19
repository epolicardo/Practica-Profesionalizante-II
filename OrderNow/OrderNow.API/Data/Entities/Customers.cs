namespace Data.Entities
{
    public class Customers : EntityBase
    {
        public bool IsMarkedAsVIP { get; set; }
        //public List<Products> FavoriteProducts { get; set; }
        // public List<Products> LastOrdered { get; set; }
        // public List<Businesses> FavoriteBusinesses { get; set; }
        //  public List<Businesses> LastVisited { get; set; }


        public People Person { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Activo = 1,
        Inactivo = 0
    }

}

