using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CSExtensions {
  // useful extensions to the XmlNode class
  public static class XMLNodeExtensions {
    // get the first child of a given type
    public static XmlNode GetFirstChildOf(this XmlNode self, string childType) {
      string xpath = string.Format("./{0}", childType);
      XmlNodeList optChildren = self.SelectNodes(xpath);
      if (optChildren == null || optChildren.Count == 0)
        return null;
      return optChildren[0];
    }

    // get an int value held as innertext of a child
    public static int? GetChildIntValue(this XmlNode self, string childName, bool isHex = false) {
      XmlNode ch = self.GetFirstChildOf(childName);
      if (ch == null)
        return null;
      int value;
      if (!isHex) { // decimal
        if (!Int32.TryParse(ch.InnerText, out value))
          return null;
      } else { // hex
        try {
          value = Convert.ToInt32(ch.InnerText, 16);
        } catch {
          return null;
        }
      }
      return value;
    }

    // get an int value held as inner text of a child
    public static double? GetChildDblValue(this XmlNode self, string childName) {
      XmlNode ch = self.GetFirstChildOf(childName);
      if (ch == null)
        return null;
      double value;
      if (!Double.TryParse(ch.InnerText, out value))
        return null;
      return value;
    }

    // get bool from node inner text
    public static bool? GetChildBoolValue(this XmlNode self, string childName) {
      XmlNode ch = self.GetFirstChildOf(childName);
      if (ch == null)
        return null;
      bool value;
      if (!Boolean.TryParse(ch.InnerText, out value))
        return null;
      return value;
    }

    // get inner text of a child
    public static string GetChildStrValue(this XmlNode self, string childName) {
      XmlNode ch = self.GetFirstChildOf(childName);
      if (ch == null)
        return null;
      return ch.InnerText;
    }

    // get int attribute or null
    public static int? GetIntAttribute(this XmlNode self, string attribName, bool isHex = false) {
      XmlAttribute attr = (XmlAttribute)self.Attributes.GetNamedItem(attribName);
      if (attr == null)
        return null;
      int value;
      if (!isHex) { // decimal
        if (!Int32.TryParse(attr.InnerText, out value))
          return null;
      } else { // hex
        try {
          value = Convert.ToInt32(attr.InnerText, 16);
        } catch {
          return null;
        }
      }
      return value;
    }

    // get ulong attribute or null
    public static ulong? GetULongAttribute(this XmlNode self, string attribName, bool isHex = false) {
      XmlAttribute attr = (XmlAttribute)self.Attributes.GetNamedItem(attribName);
      if (attr == null)
        return null;
      ulong value;
      if (!isHex) { // decimal
        if (!ulong.TryParse(attr.InnerText, out value))
          return null;
      } else { // hex
        try {
          value = Convert.ToUInt64(attr.InnerText, 16);
        } catch {
          return null;
        }
      }
      return value;
    }

    // get double attribute or null
    public static double? GetDblAttribute(this XmlNode self, string attribName) {
      XmlAttribute attr = (XmlAttribute)self.Attributes.GetNamedItem(attribName);
      if (attr == null)
        return null;
      double value;
      if (!Double.TryParse(attr.InnerText, out value))
        return null;
      return value;
    }

    // get attribute as bool
    public static bool GetBoolAttribute(this XmlNode self, string attribName, bool defaultVal = false) {
      XmlAttribute attr = (XmlAttribute)self.Attributes.GetNamedItem(attribName);
      if (attr == null || string.IsNullOrEmpty(attr.InnerText))
        return defaultVal;
      bool res;
      string str = attr.InnerText;
      if (str == "0")
        return false;
      else if (str == "1")
        return true;
      else if (!bool.TryParse(attr.InnerText, out res))
        return defaultVal;
      return res;
    }

    // get attribute innertext
    public static string GetStrAttribute(this XmlNode self, string attribName) {
      XmlAttribute attr = (XmlAttribute)self.Attributes.GetNamedItem(attribName);
      if (attr == null)
        return null;
      return attr.InnerText;
    }
  }

  // useful extensions to the XElement class
  public static class XElementExtensions {
    // get int attribute or null
    public static int? GetIntAttribute(this XElement self, string attribName, bool isHex = false) {
      XAttribute attr = GetAttributeByName(self, attribName);
      if (attr == null)
        return null;
      int value;
      if (!isHex) { // decimal
        if (!Int32.TryParse(attr.Value, out value))
          return null;
      } else { // hex
        try {
          value = Convert.ToInt32(attr.Value, 16);
        } catch {
          return null;
        }
      }
      return value;
    }

    // get double attribute or null
    public static double? GetDblAttribute(this XElement self, string attribName) {
      XAttribute attr = GetAttributeByName(self, attribName);
      if (attr == null)
        return null;
      double value;
      if (!Double.TryParse(attr.Value, out value))
        return null;
      return value;
    }

    // get attribute as bool
    public static bool GetBoolAttribute(this XElement self, string attribName) {
      XAttribute attr = GetAttributeByName(self, attribName);
      if (attr == null || string.IsNullOrEmpty(attr.Value))
        return false;
      bool res;
      string str = attr.Value;
      if (str == "0")
        return false;
      else if (str == "1")
        return true;
      else if (!bool.TryParse(attr.Value, out res))
        return false;
      return res;
    }

    // get attribute innertext
    public static string GetStrAttribute(this XElement self, string attribName) {
      XAttribute attr = GetAttributeByName(self, attribName);
      if (attr == null)
        return null;
      return attr.Value;
    }

    // helper method to find the attribute
    private static XAttribute GetAttributeByName(this XElement self, string attributeName) {
      if (!self.HasAttributes)
        return null;
      foreach (XAttribute attr in self.Attributes()) {
        if (attr.Name == attributeName)
          return attr;
      }
      return null;
    }
  }
}
