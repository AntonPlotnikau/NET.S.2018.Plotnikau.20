using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using DI;
using Logger;
using Parser;
using Serializer;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ConfigModule());
            Parser.Parser parser = new Parser.Parser(kernel.Get<ILogger>());
            IEnumerable<Uri> uriCollecton = parser.ParseFromStorage(kernel.Get<IStorage>());
            kernel.Get<ISerializer>().Serialize(uriCollecton);
        }
    }
}
