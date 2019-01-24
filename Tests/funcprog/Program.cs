using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSExtensions;

namespace funcprog {
  class Program {
    static bool isAscending(List<int> numbers) {
      var p = numbers.Pairwise().Select(x => Math.Abs(x.Item1 - x.Item2)).ToList().Pairwise().Select(x => x.Item2 - x.Item1).ToList();
      return !p.Any(x => x >= 0);
    }

    static void Main(string[] args) {
      bool res = isAscending(new List<int>() { 2, 4, 6 });
      Console.WriteLine(res);
      res = isAscending(new List<int>() { 5, 3, 2 });
      Console.WriteLine(res);
      //
      int[] lst = new[] {1, 2, 3, 10, 11, 12, 458, 445, -35};
      List<int> lres = lst.Select((x, index) => x * index).ToList();
      Console.WriteLine(string.Join(",", lres));
    }
  }
}
