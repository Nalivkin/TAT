using System;
namespace DEV_11
{
  // This exception is used for warn us the string
  // we used in translit isnt correct.
  class NotCorrectStringException:Exception
  {
    public override string Message
    {
      get
      {
        return "This string is not correct!";
      }
    }
  }
}
