using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFUtils {
  // datacontext for a combobox whos items are a list of objects
  public class ComboboxWithListHelper<T> : DependencyObject {
    public delegate void SetWelderNameDelegate(string welderName);
    public event SetWelderNameDelegate OnWelderNameChanged;
    private bool preventCallback = false;

    public static readonly DependencyProperty DPCBSourceItems =
      DependencyProperty.Register("DPCBSourceItems", typeof(List<T>),
        typeof(ComboboxWithListHelper<T>), new UIPropertyMetadata(null));
    public static readonly DependencyProperty DPCBIndex =
      DependencyProperty.Register("DPCBIndex", typeof(int),
        typeof(ComboboxWithListHelper<T>), new FrameworkPropertyMetadata(-1,
          FrameworkPropertyMetadataOptions.AffectsRender,
          new PropertyChangedCallback(OnIndexChanged)
        ));

    public List<T> CBSourceItems {
      get { return (List<T>)GetValue(DPCBSourceItems); }
      set { SetValue(DPCBSourceItems, value); }
    }
    public int CBIndex {
      get { return (int)GetValue(DPCBIndex); }
      set {
        SetValue(DPCBIndex, value);
      }
    }

    private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      (d as ComboboxWithListHelper<T>).IndexChangeHelper();
    }

    private T t = default(T);
    void IndexChangeHelper() {
      if (!preventCallback)
        OnWelderNameChanged?.Invoke((CBIndex < 0 || CBIndex >= CBSourceItems.Count ? t : CBSourceItems[CBIndex]).ToString());
    }

    public void InitWelderName(T welderName) {
      preventCallback = true;
      CBIndex = CBSourceItems.IndexOf(welderName);
      preventCallback = false;
    }

  }

}
