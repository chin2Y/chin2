//------------------------------------------------------------------------------------------------------------------
//Ben is one of the best gamers in India. He also happens to be an excellent programmer. 
//So, he likes to play games which require use of both gaming skills as well as programming skills. 
//One such game is SpaceWar.
//
//In this game there are N levels and M types of available weapons. 
//The levels are numbered from 0 to N-1 and the weapons are numbered from 0 to M-1 . 
//Ben can clear these levels in any order. 
//In each level, some subset of these M weapons is required to clear this level. 
//If in a particular level, Ben needs to buy x new weapons, he will pay x^2 coins for it. 
//Also note that Ben can carry all the weapons he has currently to the next level . Initially, Ben has no weapons. 
//Can you tell the minimum coins required such that Ben can clear all the levels. 
//------------------------------------------------------------------------------------------------------------------
//Input Format
//------------
//The first line of input contains 2 space separated integers;
//N - the number of levels in the game and M - the number of types of weapons.
//N lines follows. The ith of these lines contains a binary string of length M. If the jth character of 
//this string is 1 , it means we need a weapon of type j to clear the ith level.
//Constraints
//1 <= N,M <=20
//-------------------------------------------------------------------------------------------------------
//Output Format
//-------------
//Print a single integer which is the answer to the problem.
//=================================================================================================================================

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
