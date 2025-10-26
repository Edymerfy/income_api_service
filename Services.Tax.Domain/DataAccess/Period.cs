namespace Services.Tax.Domain.DataAccess
{
    public class Period
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int SplitValue { get; set; }
    }
}
