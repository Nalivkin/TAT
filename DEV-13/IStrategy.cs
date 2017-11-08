using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  // interface to impelemnt the Strategy pattern.
  public interface IStrategy
  {
    Programmist[] Algorithm();
  }
}
