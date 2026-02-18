namespace MyCustomAttribute
{
    public class Table:Attribute
    {
        public string TableName { get; set; }
    }

    public class Column:Attribute
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
    }
}
