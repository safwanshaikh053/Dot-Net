using System.Reflection;
using System.Reflection.Metadata;

namespace DemoDay1Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = @"F:\CDAC\ASP.Net Mugdha Ma'am\Demo1\DemoDay1\bin\Debug\net9.0\DemoDay1.dll";
            Assembly asm = Assembly.LoadFrom(assemblyPath);

            Type[] allTypes = asm.GetTypes();


            for (int i = 0; i < allTypes.Length; i++)
            {
                Type type = allTypes[i];

                object? dynamicallyCreateObject = asm.CreateInstance(type.FullName);

                MethodInfo[] allMethods = type.GetMethods();

                for (int j = 0; j < allMethods.Length; j++)
                {
                    string methodSignature = "";
                    MethodInfo currentMethod = allMethods[j];

                    methodSignature = methodSignature + $"{currentMethod.ReturnType.ToString()} {currentMethod.Name} (";

                    ParameterInfo[] allParameters = currentMethod.GetParameters();

                    for (int k = 0; k < allParameters.Length; k++)
                    {
                        ParameterInfo currentParameter = allParameters[k];

                        methodSignature = methodSignature + " " + currentParameter.ParameterType.ToString() + " " + currentParameter.Name + ",";
                    }

                    object[] userInputs = new object[allParameters.Length];
                    for(int p = 0; p<allParameters.Length; p++)
                    {
                        ParameterInfo para = allParameters[p];
                        Console.WriteLine($"Enter value for{para.Name} of type {para.ParameterType.ToString()}");
                        object? value = Convert.ChangeType(Console.ReadLine(), para.ParameterType);
                        userInputs[p] = value;
                    }
                    methodSignature = methodSignature.Trim(',') + ")";
                    Console.WriteLine(methodSignature);
                    object result = type.InvokeMember(currentMethod.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, dynamicallyCreateObject, userInputs);

                    Console.WriteLine($"Result={result}");
                }

            }

        }
    }
}
