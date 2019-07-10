using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSExtensions {
  public static class GenUtils {
    // check if value in list (params[])
    public static bool IsOneOf<T>(T value, params T[] valuesList) {
      return valuesList.ToList().Contains(value);
    }
  }


  // usage:       foreach (typename x in Range.Get( elem1, elem2, elem3,... ))...
  public static class Range {
    public static IEnumerable<T> Get<T>(params T[] a) {
      foreach (var item in a) {
        yield return item;
      }
    }

    public static IEnumerable<object> Get(params object[] a) {
      foreach (var item in a) {
        yield return item;
      }
    }

    public static IEnumerable<int> Get(int hlim) {
      int idx = 0;
      while (idx< hlim)
        yield return idx++;
    }

    public static IEnumerable<int> Get(int start, int count) {
      int idx = start;
      while (idx < start+count)
        yield return idx++;
    }

    public static IEnumerable<double> Get(double hlim) {
      double idx = 0;
      while (idx < hlim) {
        yield return idx;
        idx += 1.0;
      }
    }

    public static IEnumerable<double> Get(double start, double hlim) {
      double idx = start;
      while (idx < hlim) {
        yield return idx;
        idx += 1.0;
      }
    }

    public static IEnumerable<double> Get(double start, double hlim, double step) {
      double idx = start;
      while (idx < hlim) {
        yield return idx;
        idx += step;
      }
    }

  }

}
