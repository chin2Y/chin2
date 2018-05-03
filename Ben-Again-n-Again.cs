using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenTheGamer
{
    class Ben_Again_n_Again
    {
        static void Main(string[] args)
        {
            string[] NM = Console.ReadLine().Split();
            int N = int.Parse(NM[0]);
            int M = int.Parse(NM[1]);
            
            Int64[] cost = new Int64[(int)(Math.Pow(2, M))];
            List<int> levels = new List<int>();
            List<int> oredList = new List<int>();

            for (int n = 0; n < N; n++)
            {
                int countWeapons = 0;
                string binary = Console.ReadLine();
                int dec = Convert.ToInt32(binary, 2);
                levels.Add(dec);
                oredList.Add(dec);
                for (int m = 0; m < M; m++)
                {
                    if (binary[m] == '1')
                    {
                        countWeapons++;
                    }
                }
                cost[dec] = countWeapons * countWeapons;
            }
            int comparer = 0;
            foreach(var v in oredList)
            {
                foreach (var c in levels)
                {
                    int result = v | c;
                    if (!oredList.Contains(result))
                    {
                        oredList.Add(result);
                    }
                }
                string ini = Convert.ToString(oredList[comparer], 2);
                foreach(var value in oredList)
                {
                    int diff = 0;
                    string com = Convert.ToString(value, 2);
                    for (int m = 0; m < M; m++)
                    {
                        if (ini[m] != com[m])
                        {
                            diff++;
                        }
                    }
                    long totalCost = cost[oredList[comparer]] + diff * diff;
                    if (totalCost < cost[value])
                    {
                        cost[value] = totalCost;
                    }
                }
                comparer++;
            }
            Console.WriteLine(cost[N-1]);
            Console.ReadKey();
        }
    }

}
//int iterator = comparer + 1;
//while (iterator < oredList.Count)
//{
//    int diff = 0;
//    string dec = Convert.ToString(oredList[comparer], 2);
//    string com = Convert.ToString(oredList[iterator], 2);
//    for (int m = 0; m < M; m++)
//    {
//        if (dec[m] != com[m])
//        {
//            diff++;
//        }
//    }
//    long totalCost = cost[oredList[comparer]] + diff * diff; 
//    if(totalCost< cost[oredList[iterator]])
//    {
//        cost[oredList[iterator]] = totalCost;
//    }
//    iterator++;
//}
//comparer++;