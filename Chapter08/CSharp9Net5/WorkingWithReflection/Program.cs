using System;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;
using WorkingWithReflection;
using static System.Console;

namespace WorkingWithReflection
{
    class Program
    {
        [Coder("Larry King", "24 January 2021")]
        [Coder("Other Coder", "22 January 2021")]
        public static void DoStuff()
        {
        }

        static void Main(string[] args)
        {
            WriteLine("Assembly Metadata");
            Assembly assembly = Assembly.GetEntryAssembly();

            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();

            WriteLine($" Attributes");
            foreach (Attribute attribute in attributes)
            {
                WriteLine($" {attribute.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Version: {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Company: {company.Company}");

            WriteLine();
            WriteLine($" * Types:");
            var types = assembly.GetTypes().
                Where(t => !t.GetTypeInfo().IsDefined(typeof(CompilerGeneratedAttribute), true));
            foreach (Type type in types)
            {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                MemberInfo[] members = type.GetMembers();

                foreach (MemberInfo member in members)
                {
                    WriteLine("{0}: {1} ({2})",
                        member.MemberType,
                        member.Name,
                        member.DeclaringType.Name);

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);

                    foreach (CoderAttribute coder in coders)
                    {
                        WriteLine("-> Modified by {0} on {1}",
                            coder.Coder, coder.LastModified.ToShortDateString());
                    }
                }
            }
        }
    }
}
