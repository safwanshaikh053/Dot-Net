using MyCustomAttribute;
using System.Reflection;

namespace MyORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = @"F:\CDAC\ASP.Net Mugdha Ma'am\Demo1\Employee\bin\Debug\net9.0\Employee.dll";
            Assembly asm = Assembly.LoadFrom(assemblyPath);
            Type[] allTypes = asm.GetTypes();
            string query = "";

            for (int i = 0; i < allTypes.Length; i++)
            {
                Type type = allTypes[i];
                Attribute[] allAttribute = type.GetCustomAttributes().ToArray();

                for (int j = 0; j < allAttribute.Length; j++)
                {
                    Attribute attri = allAttribute[j];
                    if (attri is SerializableAttribute){
                        Console.WriteLine($"Type: {type.FullName} is Serializable");
                        
                    }
                     query = "Create Table ";
                    if (attri is Table)
                    {
                        Table table = attri as Table;
                        query = query + table.TableName + "(";
                        
                    }

                    PropertyInfo[] allProps = type.GetProperties();

                    for (int k = 0; k < allProps.Length; k++)
                    {
                        PropertyInfo props = allProps[k];
                       Attribute[] propAttri =  props.GetCustomAttributes().ToArray();

                        for(int m=0; m<propAttri.Length; m++)
                        {
                            Attribute attribute = propAttri[m];

                            if (attribute is Column)
                            {
                                  Column col = attribute as Column;
                                query =  query + col.ColumnName + " " + col.ColumnType + ",";
                            }
                            {
                                
                            }
                        }
                    }

                    

                }

            }
            query = query.TrimEnd(',') + ");";
            //Console.WriteLine(query);
            string filePath = @"F:\CDAC\ASP.Net Mugdha Ma'am\Demo1\MyORM\DBQuery\MyQuery.sql";
            File.WriteAllText(filePath, query);
            Console.WriteLine("Done");
        }
    }
}
