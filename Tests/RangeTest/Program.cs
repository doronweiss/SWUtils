using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSExtensions;

namespace RangeTest {
  class Program {
    static void Main(string[] args) {
      foreach (string x in Range.Get("a", "b", "c", "d"))
        Console.WriteLine($"Received {x}");
      foreach (int x in Range.Get(5))
        Console.WriteLine($"Received {x}");
      foreach (int x in Range.Get(100,5))
        Console.WriteLine($"Received {x}");
      foreach (double x in Range.Get(101.0, 117.0, 2.5))
        Console.WriteLine($"Received {x}");
    }
  }
}
