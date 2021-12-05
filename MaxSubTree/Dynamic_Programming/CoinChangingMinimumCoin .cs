using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    public class CoinChangingMinimumCoin
    {
        public int minimumCoinBottomUp(int total, int[] coins)
        {
            //T保存了对应所有1 ，2 ，3， 4， 5， 。。。。 total
            //达到这些total所需要的最小的coins数量
            int[] minimumCoinsNumber = new int[total + 1];

            //R保存了对应所有1 2 3 4 5 。。。。 Total
            //对应每一个Total时候所 用的coin ---》 coin在 coin数组的位置
            int[] coinsIndex_for_eachTotalNumber = new int[total + 1];

            //initialize to some invalid values
            minimumCoinsNumber[0] = 0;
            for (int i = 1; i <= total; i++)
            {
                minimumCoinsNumber[i] = int.MaxValue - 1;
                coinsIndex_for_eachTotalNumber[i] = -1;
            }

            //iterate each coin --> row
            for (int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
            {
                //iterate each total from 1, 2,3, 4,..... total
                for (int totalNumberIndex = 1; totalNumberIndex <= total; totalNumberIndex++)
                {
                    //compare the total with the coin
                    if (totalNumberIndex >= coins[coinIndex])
                    {
                        // current total i > coin, e.g. total 6 > coin 5
                        //compare current coin T row, T[coin-index][(total-index) - coin面值]
                        // T[i - coins[j]] = T[coin->index][total->index - coin面值]
                        if (minimumCoinsNumber[totalNumberIndex - coins[coinIndex]] + 1 < minimumCoinsNumber[totalNumberIndex])
                        {
                            //选中当前这个coin,条件是 当前coin往前回溯 coin面值个index + 1 小于前一个coin的 对应total的值
                            //即： T[i - coins[j]] + 1 < T[i]
                            //如果当前这个coin 面值 
                            //T[i] is the value of last coin, e.g. coin 3
                            minimumCoinsNumber[totalNumberIndex] = minimumCoinsNumber[totalNumberIndex - coins[coinIndex]] + 1; 

                            //记录下当前这个coin,因为选中了这个coin,而不是前一个coin
                            coinsIndex_for_eachTotalNumber[totalNumberIndex] = coinIndex;
                        }
                    }
                }
            }
            printCoinCombination(coinsIndex_for_eachTotalNumber, coins);
            return minimumCoinsNumber[total];
        }

        private void printCoinCombination(int[] R, int[] coins)
        {
            if (R[R.Length - 1] == -1)
            {
                Console.WriteLine("No solution is possible");
                return;
            }
            int start = R.Length - 1;
            Console.WriteLine("Coins used to form total ");
            while (start != 0)
            {
                int j = R[start];
                Console.WriteLine(coins[j] + " ");
                start = start - coins[j];
            }
            Console.WriteLine("\n");
        }
    }
}
