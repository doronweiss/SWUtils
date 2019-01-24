using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSExtensions {
  public static class EnumExtensions {
    public static List<Tuple<T, T>> Pairwise<T>(this IEnumerable<T> src) {
      return src.Zip(src.Skip(1), Tuple.Create).ToList();
    }

  }
}
