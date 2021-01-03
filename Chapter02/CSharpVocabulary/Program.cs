using System;
using System.Linq;
using System.Reflection;

namespace CSharpVocabulary
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare some unused variables using types in additional assemblies
            System.Data.DataSet dataSet;
            System.Net.Http.HttpClient client;
            
            foreach(var r in Assembly.GetEntryAssembly().GetReferencedAssemblies()) 
            {
                // Load throug the assemblies that this app references
                var a = Assembly.Load(new AssemblyName(r.FullName));
                var methodCount = 0;

                foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods
                    methodCount += t.GetMethods().Count();
                }

                Console.WriteLine($"{a.DefinedTypes.Count()} types with {methodCount} methods in {r.Name} assembly.");
            }
        }
    }
}