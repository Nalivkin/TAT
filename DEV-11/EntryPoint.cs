using System;
using System.Collections.Generic;
using System.IO;

namespace DEV_11
{
  // The point where program starts.
  class EntryPoint
  {
    static void Main(string[] args)
    {
      Translit translit = new Translit("EN-RU.txt");
      string enText = "hello world";
      Translit translit2 = new Translit("RU-EN.txt");
      string ruText = "Лондон ис э кэпитал оф Грейт Британ";
      try
      {
        Console.Write(translit.Transliteration(enText) + "\n");
      }
      catch (NotCorrectStringException ex)
      {
        Console.Write(ex.Message + "\n");
      }
      try
      {
        Console.Write(translit2.Transliteration(ruText) + "\n");
      }
      catch (NotCorrectStringException ex)
      {
        Console.Write(ex.Message + "\n");
      }
      Console.ReadKey(true);
    }
  }
}
  