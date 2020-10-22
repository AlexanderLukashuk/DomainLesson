using System;
using System.Threading;

namespace DomainLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteAndUnload(out WeakReference alcWeakRef);
            for(int i = 0; alcWeakRef.IsAlive && i < 10; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Console.Read();
        }

        static void ExecuteAndUnload(out WeakReference alcWeakRef)
        {
            var context = new DllLoadContext();

            var sumAssembly = context.LoadFromAssemblyPath(@"C:\Users\Luka_ry90\source\repos\ClassLibrary1\ClassLibrary1\bin\Debug\netcoreapp3.1\ClassLibrary1.dll");
            alcWeakRef = new WeakReference(sumAssembly, true);

            var class1Type = sumAssembly.GetType("ClassLibrary1.Class1");
            var sumMethodInfo = class1Type.GetMethod("Sum");

            var class1Object = Activator.CreateInstance(class1Type);
            var result = (int)sumMethodInfo.Invoke(class1Object, new object[] { 3, 5 });

            Console.WriteLine(result);

            context.Unload();

            //context.Unload();
            //sumAssembly = null;

            //assemblies = domain.GetAssemblies();

            //for (int i = 0; i < 10; i++)
            //{
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //Thread.Sleep(10000);

            //Console.ReadLine();
        }

        private static void Unload(System.Runtime.Loader.AssemblyLoadContext obj)
        {

        }
    }
}
