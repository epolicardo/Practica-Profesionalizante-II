namespace OrderNow.Common.Data.Entities
{
    public class Document : EntityBase
    {
        public DocumentType Type { get; set; }
        public string DocumentPrefix { get; set; }
        public string DocumentNumber { get; set; }
        public Users GeneratedBy { get; set; }
        // public Users ModifiedBy { get; set; }
    }
}