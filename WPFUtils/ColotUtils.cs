using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUtils {
  public static class ColotUtils {
    public static int ToArgb(this System.Windows.Media.Color color) {
      byte[] bytes = new byte[] { color.A, color.R, color.G, color.B };
      return BitConverter.ToInt32(bytes, 0);
    }
  }
}
