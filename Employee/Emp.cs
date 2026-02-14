using MyCustomAttribute;
namespace Employee
{
    [Serializable]
    [Table(TableName ="Employee")]
    public class Emp
    {
         
        [Column(ColumnName ="EId", ColumnType ="int")]
        public int Id { get; set; }
        [Column(ColumnName = "EName", ColumnType = "varchar(50)")]
        public int EName { get; set; }
        [Column(ColumnName = "Address", ColumnType = "varchar(50)")]
        public string EAdddress { get; set; }
    }
}
