namespace OrderNow.Common.Data.Entities
{
    public class Groups : EntityBase
    {
        public string Name { get; set; }

        //UserGroupId
        public string UGI { get; set; }

        public IList<Users>? Integrantes { get; set; }
    }
}