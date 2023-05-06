namespace OrderNow.Common.Data.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }

        //UserGroupId
        public string UGI { get; set; }

        public IList<Users>? Integrantes { get; set; }
    }
}