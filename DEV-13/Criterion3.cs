using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  // This class is used for implementation of the third criterion
  // using the Strategy pattern.

  class Criterion3:IStrategy
  {
    int Performance;
    Programmist junior = new Programmist(90, 120, "junior");
    Programmist middle = new Programmist(380, 420, "middle");
    Programmist senior = new Programmist(900, 900, "senior");
    Programmist lead = new Programmist(2250, 2000, "lead");
    public Criterion3(int performance)
    {
      Performance = performance;
    }

    public Programmist[] Algorithm()
    {
      int currentPerformance = 0;
      Programmist[] team = { junior, middle, senior, lead };
      Sort(team);
      Programmist[] result = null;
      int[] Performances = new int[team.Length];
      int maxJuniorsCount = Performance / team[0].Performance;
      for (int i = maxJuniorsCount; currentPerformance <= Performance; i--)
      {
        team[0].Count = i;
        Performances[0] = team[0].Count * team[0].Performance;
        currentPerformance = Performances[0];
        for (int j = 0; currentPerformance <= Performance; j++)
        {
          team[3].Count = j;
          Performances[3] = team[3].Count * team[3].Performance;
          currentPerformance = Performances[0] + Performances[3];
          for (int k = 0; currentPerformance <= Performance; k++)
          {
            team[2].Count = k;
            Performances[2] = team[2].Count * team[2].Performance;
            currentPerformance = Performances[0] + Performances[2] + Performances[3];
            for (int l = 0; currentPerformance <= Performance; l++)
            {
              team[1].Count = l;
              Performances[1] = team[1].Count * team[1].Performance;
              currentPerformance = Performances[0] + Performances[1] + Performances[2] + Performances[3];
              if (currentPerformance > Performance)
              {
                team[1].Count--;
                currentPerformance -= team[1].Performance;
                Performances[1] -= team[1].Performance;
                break;
              }
            }
            if (currentPerformance > Performance)
            {
              team[2].Count--;
              currentPerformance -= team[2].Performance;
              Performances[2] -= team[2].Performance;
              break;
            }
          }
          if (currentPerformance > Performance)
          {
            team[3].Count--;
            currentPerformance -= team[3].Performance;
            Performances[3] -= team[3].Performance;
            break;
          }
        }
        if (currentPerformance == Performance)
        {
          result = new Programmist[team.Length];
          for (int m = 0; m < team.Length; m++)
          {
            result[m] = team[m];
          }
          break;
        }
      }
      return result;
    }
    // this method is used for make sure the juniors
    // are on first place in team array, then
    // sort the members of team
    // according of their efficiency.
    public void Sort(Programmist[] team)
    {
      bool flag = true;
      if (team[0].Type != junior.Type)
      {
        for (int i = 1; i < team.Length; i++)
        {
          if (team[i].Type == junior.Type)
          {
            var buf = team[0];
            team[0] = team[i];
            team[i] = buf;
            break;
          }
        }
      }
      while (flag)
      {
        flag = false;
        for (int i = 1; i < team.Length - 1; i++)
        {
          if (team[i].Efficiency < team[i + 1].Efficiency) // a b c
          {
            var buf = team[i];
            team[i] = team[i + 1];
            team[i + 1] = buf;
            flag = true;
          }
        }
      }
    }
  }
}
