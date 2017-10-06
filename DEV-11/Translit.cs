using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DEV_11
{
  // This class is used for transliteration the string from
  // cyrillic to latin or vice versa.
  class Translit
  {
    public Dictionary<string, string> dictionary { get; set; }
    public Translit()
    {

    }
    // Those constructors are used for initialization the dictionary
    // we will use after with different ways.
    public Translit(Dictionary<string, string> dictionary)
    {
      this.dictionary = dictionary;
    }
    public Translit(string nameOfDictionary)
    {
      dictionary = GetDictionary(nameOfDictionary);
    }
    // This method is used for check if this string is correct to
    // transliteration. It means it checks if all the symbols in the string
    // are belong to the same alphabet.
    private bool CheckForCorrect(string text)
    {
      for (int i = 0; i < text.Length; i++)
      {
        if (char.ToLower(text[i]) > 96 && char.ToLower(text[i]) < 123)
        {
          for (int j = i; j < text.Length; j++)
          {
            if (char.ToLower(text[j]) > 1071 && char.ToLower(text[j]) < 1104 || char.ToLower(text[j]) == 1105)
            {
              return false;
            }
          }
          return true;
        }
        if (char.ToLower(text[i]) > 1071 && char.ToLower(text[i]) < 1104 || char.ToLower(text[i]) == 1105)
        {
          for (int j = i; j < text.Length; j++)
          {
            if (char.ToLower(text[j]) > 96 && char.ToLower(text[j]) < 23)
            {
              return false;
            }
          }
        }
      }
      return true;
    }
    // This method transliterates string from one alphabet
    // to another one.
    public string Transliteration(string text)
    {
      StringBuilder result = new StringBuilder(text);
      if (CheckForCorrect(text))
      {
        string[] keys = new string[dictionary.Count];
        dictionary.Keys.CopyTo(keys, 0);
        for (int i = 0; i < dictionary.Count; i++)
        {
          string symbol = keys[i].ToString();
          if (text.ToLower().Contains(symbol))
          {
            result.Replace(symbol[0].ToString().ToUpper() + symbol.Substring(1),
              dictionary[symbol][0].ToString().ToUpper() + dictionary[symbol].ToString().Substring(1));
            result.Replace(symbol, dictionary[symbol]);
          }
        }
      }
      else
      {
        throw new NotCorrectStringException();
      }
      return result.ToString();
    }
    // Those methods are used for parse the dictionaries from file.
    private Dictionary<string, string> GetDictionary(string nameOfDictionary)
    {
      dictionary = new Dictionary<string, string>();
      StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\" + nameOfDictionary, Encoding.Default);
      string symbols;
      while (true)
      {
        symbols = reader.ReadLine();
        if (symbols == null)
        {
          break;
        }
        string[] translits = symbols.Split('-');
        dictionary.Add(translits[0], translits[1]);
      }
      return dictionary;
    }
    public Dictionary<string, string> GetDictionaryByPath(string path)
    {
      dictionary = new Dictionary<string, string>();
      StreamReader reader = new StreamReader(path, Encoding.Default);
      string symbols;
      while (true)
      {
        symbols = reader.ReadLine();
        if (symbols == null)
        {
          break;
        }
        string[] translits = symbols.Split('-');
        dictionary.Add(translits[0], translits[1]);
      }
      return dictionary;
    }
  }
}
