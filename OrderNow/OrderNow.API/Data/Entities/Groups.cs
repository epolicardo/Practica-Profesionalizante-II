namespace Data.Entities
{
    public class Groups : EntityBase
    {
        public string Name { get; set; }

        //UserGroupId
        public string UGI { get; set; }

        public List<Users> Integrantes { get; set; }
    }
}