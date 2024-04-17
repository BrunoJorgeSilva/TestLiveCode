namespace TestLiveCode.Model
{
    public class ExampleDetails
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public Guid ExampleId { get; set; }
        public Example Example { get; set; }
        
    }
}