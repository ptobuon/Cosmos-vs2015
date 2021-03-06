using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Build.Common {
  public abstract class PropertiesBase {
    protected Dictionary<string, string> mPropTable = new Dictionary<string, string>();

    public Dictionary<string, string> GetProperties() {
      Dictionary<string, string> clonedTable = new Dictionary<string, string>();

      foreach (KeyValuePair<string, string> pair in mPropTable) {
        clonedTable.Add(pair.Key, pair.Value);
      }

      return clonedTable;
    }

    public void Reset() {
      mPropTable.Clear();
    }

    public void SetProperty(string name, string value) {
      if (mPropTable.ContainsKey(name) == false) { 
        mPropTable.Add(name, value); 
      } else { 
        mPropTable[name] = value; 
      }
    }

    public void SetProperty(string name, Object value) {
      SetProperty(name, value.ToString());
    }

    public string GetProperty(string name) {
      return GetProperty(name, string.Empty);
    }

    public T GetProperty<T>(string name, T @default) {
      T value = @default;
      if (mPropTable.ContainsKey(name) == true) {
        string stringValue = mPropTable[name];
        Type valueType = typeof(T);
        string valueTypeName = valueType.Name;

        if (valueType.IsEnum == true) {
          value = EnumValue.Parse(stringValue, @default);
        } else {
          // TODO Check on types directly instead of string literal
          if (valueType == typeof(string)) {
            value = (T)((Object)stringValue);
          } else if ((valueTypeName == "Int16") || (valueTypeName == "Short")) {
            Int16 newValue;
            if (Int16.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if ((valueTypeName == "Int32") || (valueTypeName == "Integer")) {
            Int32 newValue;
            if (Int32.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if ((valueTypeName == "Int64") || (valueTypeName == "Long")) {
            Int32 newValue;
            if (Int32.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if (valueTypeName == "Boolean") {
            Boolean newValue;
            if (Boolean.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if ((valueTypeName == "UInt16") || (valueTypeName == "UShort")) {
            UInt16 newValue;
            if (UInt16.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if ((valueTypeName == "UInt32") || (valueTypeName == "UInteger")) {
            UInt32 newValue;
            if (UInt32.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else if ((valueTypeName == "UInt64") || (valueTypeName == "ULong")) {
            UInt64 newValue;
            if (UInt64.TryParse(stringValue, out newValue) == true) { value = (T)((Object)newValue); }

          } else {
            throw new ArgumentException("Unsupported value type.", "T");
          }
        }
      }

      return value;
    }

  }
}
