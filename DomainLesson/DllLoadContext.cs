using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace DomainLesson
{
    class DllLoadContext : AssemblyLoadContext
    {
        public DllLoadContext() : base(true)
        {

        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }

    }
}
