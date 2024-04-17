namespace TestLiveCode.ViewModel
{
    public class ExampleViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<ExampleDetailsViewModel> ExamplesDetails { get; set; }
    }
}
