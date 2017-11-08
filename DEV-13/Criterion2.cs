using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  // This class is used for implementation of the second criterion
  // using the Strategy pattern.
  class Criterion2 : IStrategy
  {
    public int Performance{get;set;}
    Programmist junior = new Programmist(90, 120, "junior");
    Programmist middle = new Programmist(380, 420, "middle");
    Programmist senior = new Programmist(900, 900, "senior");
    Programmist lead = new Programmist(2250, 2000, "lead");
    public Criterion2(int performance)
    {
      this.Performance = performance;
    }

    public Programmist[] Algorithm()
    {
      int currentPerformance = 0;
      Programmist[] team = { junior, middle, senior, lead };
      Programmist[] result = null;
      Sort(team);
      int[] Performances = new int[team.Length];
      bool isResultFound = false;
      int maxJuinorsCount = Performance / team[3].Performance;
      for (int i = 0; i <= maxJuinorsCount; i++)
      {
        team[3].Count = i;
        Performances[3] = team[3].Count * team[3].Performance;
        currentPerformance = Performances[3];
        for (int j = 0; currentPerformance <= Performance; j++)
        {
          team[2].Count = j;
          Performances[2] = team[2].Count * team[2].Performance;
          currentPerformance = Performances[2] + Performances[3];
          for (int k = 0; currentPerformance <= Performance; k++)
          {
            team[1].Count = k;
            Performances[1] = team[1].Count * team[1].Performance;
            currentPerformance = Performances[1] + Performances[2] + Performances[3];
            for (int l = 0; currentPerformance <= Performance; l++)
            {
              team[0].Count = l;
              Performances[0] = team[0].Count * team[0].Performance;
              currentPerformance = Performances[0] + Performances[1] + Performances[2] + Performances[3];
              if (currentPerformance == Performance)
              {
                result = new Programmist[team.Length];
                for (int m = 0; m < team.Length; m++)
                {
                  result[m] = team[m];
                }
                isResultFound = true;
              }
              if (currentPerformance > Performance)
              {
                team[0].Count--;
                currentPerformance -= team[0].Performance;
                Performances[0] -= team[0].Performance;
                break;
              }
            }
            if (isResultFound)
            {
              break;
            }
            if (currentPerformance == Performance)
            {
              result = new Programmist[team.Length];
              for (int m = 0; m < team.Length; m++)
              {
                result[m] = team[m];
              }
              isResultFound = true;
            }
            if (currentPerformance > Performance)
            {
              team[1].Count--;
              currentPerformance -= team[1].Performance;
              Performances[1] -= team[1].Performance;
              break;
            }
          }
          if (isResultFound)
          {
            break;
          }
          if (currentPerformance == Performance)
          {
            result = new Programmist[team.Length];
            for (int m = 0; m < team.Length; m++)
            {
              result[m] = team[m];
            }
            isResultFound = true;
          }
          if (currentPerformance > Performance)
          {
            team[2].Count--;
            currentPerformance -= team[2].Performance;
            Performances[2] -= team[2].Performance;
            break;
          }
        }
        if (isResultFound)
        {
          break;
        }
        if (currentPerformance == Performance)
        {
          result = new Programmist[team.Length];
          for (int m = 0; m < team.Length; m++)
          {
            result[m] = team[m];
          }
          isResultFound = true;
        }
        if (currentPerformance > Performance)
        {
          team[3].Count--;
          currentPerformance -= team[3].Performance;
          Performances[3] -= team[3].Performance;
          break;
        }
      }
        return result;
    }
    // this method is used for sort the members of team
    // according of their efficiency.
    public void Sort(Programmist[] team)
    {
      bool flag = true;
      while (flag)
      {
        flag = false;
        for (int i = 0; i < team.Length - 1; i++)
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

