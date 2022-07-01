using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Structural.Adapter;

namespace DesignPatterns.Demonstrations
{
    /// <summary>
    ///     Class to demonstrate Structural Design Patterns
    /// </summary>
    public class StructuralDemo
    {
        /// <summary>
        ///     Run the demonstration for the Adapter Pattern
        /// </summary>
        public static void RunAdapterDemo()
        {
            Console.WriteLine("******** Vector to Point Adapter ********");
            AdapterDemo.ShowVectorToPointAdapter();

            Console.WriteLine("\n******** Autofac for Adapter in DI ********");
            AutofacSamples.RunAutofacSample();
        }
    }
}
