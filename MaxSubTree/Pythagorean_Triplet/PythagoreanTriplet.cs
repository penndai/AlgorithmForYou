using System;

class PythagoreanTriplet
{
    public bool NaiveMethod_CubeNComplexity(int[] ar, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {

                    // Calculate square of array elements 
                    int x = ar[i] * ar[i], y = ar[j] * ar[j], z = ar[k] * ar[k];

                    if (x == y + z || y == x + z || z == x + y)
                        return true;
                }
            }
        }

        // If we reach here, 
        // no triplet found 
        return false;
    }

    public bool UsingSort_NSquare_Complexity(int[] arr, int n)
    {
        // Square array elements 
        for (int i = 0; i < n; i++)
            arr[i] = arr[i] * arr[i];

        // Sort array elements 
        Array.Sort(arr);

        // Now fix one element one by one 
        // and find the other two elements 
        //fix the last max value
        for (int i = n - 1; i >= 2; i--)
        {
            // To find the other two elements,  start two index variables from two corners of the array and 
            // move them toward each other 
            // index of the first element 
            // in arr[0..i-1] 
            int left = 0;

            // index of the last element 
            // in arr[0..i - 1] 
            int right = i - 1;
            while (left < right)
            {

                // A triplet found 
                if (arr[left] + arr[right] == arr[i])
                    return true;

                // Else either move 'l' or 'r' 
                if (arr[left] + arr[right] < arr[i])
                    left++;
                else
                    right--;
            }
        }

        // If we reach here, then 
        // no triplet found 
        return false;
    }


    //O(Max * Max)
    //step 1: create the <<Hash 数组>> 存放 从 1 到 Max 数字。因为array[i]表示 i这个数字在原数组
    //中出现的次数，所以array[0]一定为0；
    //create 《Hash数组》 whether the number is in the original array
    //the length of hashmap is max(array) + 1: because index start from 0
    //so last element in hashmap is the corresponding value for max(array)
    //
    //step 2: loop through the value from 1 to max ---note: not loop through array
    //step3: check whether hash数组 contains value "1 2 3 4 .... max"
    // only when hasp数组[z] value is 1 -- 原数组contains value z, z*z = x*x + y*y : 开平方 root square
    //step4: calculate  Math.sqr(square(a) + square(b)) exactly equal and hasp map of z is 1    
    public bool checkTriplet(int[] arr, int n)
    {
        int maximum = 0;

        // Find the maximum element 
        for (int i = 0; i < n; i++)
        {
            maximum = Math.Max(maximum, arr[i]);
        }

        //the struct of hash map:       
        //1 - 0 : number 1 not existing in array
        //2 -1 : number 2 in the array
        //3 -2: number 3 existing 2 times in array
        //4
        //5
        //...
        //max

        // Hashing array 
        int[] hash = new int[maximum + 1];

        // Increase the count of array elements 
        // in hash table 
        for (int i = 0; i < n; i++)
            hash[arr[i]]++;

        // Iterate for all possible a 
        for (int i = 1; i < maximum + 1; i++)
        {

            // If a is not there 
            if (hash[i] == 0)
                continue;

            // Iterate for all possible b 
            for (int j = 1; j < maximum + 1; j++)
            {

                // If a and b are same and there is only one a 
                // or if there is no b in original array 
                if ((i == j && hash[i] == 1) || hash[j] == 0)
                    continue;

                // Find c 
                int val = (int)Math.Sqrt(i * i + j * j);

                // If c^2 is not a perfect square 
                if ((val * val) != (i * i + j * j))
                    continue;

                // If c exceeds the maximum value 
                if (val > maximum)
                    continue;

                // If there exists c in the original array, 
                // we have the triplet 
                if (hash[val] == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }    
}

// This code is contributed by Rajput-Ji 
