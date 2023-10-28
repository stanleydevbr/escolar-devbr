namespace DevBr.Core.Dominio.Entidades
{
    public class FilterList
    {
        public string Description { get; set; }
        public int Row { get; set; }
        public int NumberItem { get; set; }
        public Ordering Ordering { get; set; }
    }

    public class Ordering
    {
        public string[] Property { get; set; }
        public string Type { get; set; }
    }
}
