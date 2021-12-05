using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Multiple
{
    /// <summary>
    /// using points, create the distance of each point to the origion -- O(n)
    /// using K points to create a max heap - name it maxHeap -- O(k)
    /// for p[K+1] in points  --O(n-k)
    ///     if p.distance < maxHeap.getMax()
    ///         replace maxHeap top node with this p
    ///         heapify the maxHeap make sure the heap properly -- O(logK)
    ///         
    /// above time complexity ---> O((n-k)*logK)
    /// print all points in the maxHeap --> O(k)
    /// so total complexity is O(n + (n-k)*logk)
    /// 
    /// </summary>
    public class KClosePointsToOriginTest
    {
        public void GetKClosestPointsDistance()
        {
            var points = new[]
                {
                (X: -2, Y: 4),
                (X: 0, Y: -2),
                (X: -1, Y: 0),
                (X: 3, Y: 5),
                (X: -2, Y: -3),
                (X: 3, Y: 2),
            };
            var expected = new[]
            {
                (X: -2, Y: -3),
                (X: -1, Y: 0),
                (X: 0, Y: -2),
            };
            const int k = 3;
            var actual = GetKClosestPointsToOrigin(k, points).ToList();
        }

        private IEnumerable<(int, int)> GetKClosestPointsToOrigin(int k, (int X, int Y)[] points)
        {
            var pointToDistanceMap = BuildPointToDistanceMap(points);
            var maxHeap = BuildMaxHeapMap(k, points);

            for (int i = k; i < points.Length; i++)
            {
                // Replace the biggest with the current smallest
                if (pointToDistanceMap[points[i]] < maxHeap.Peek().Distance)
                {
                    maxHeap.Poll();
                    maxHeap.Add((points[i].X, points[i].Y, pointToDistanceMap[points[i]]));
                }
            }

            while (maxHeap.HasItem())
            {
                var (x, y, _) = maxHeap.Poll();
                yield return (x, y);
            }
        }

        private Dictionary<(int, int), double> BuildPointToDistanceMap((int x, int y)[] points)
        {
            return points.ToDictionary(point => point, CalculateDistance);
        }

        private double CalculateDistance((int X, int Y) point) => Math.Sqrt(point.X * point.X + point.Y * point.Y);

        private BinaryHeap_Generic<(int X, int Y, double Distance)> BuildMaxHeapMap(int k, (int X, int Y)[] points)
        {
            return points
                .Take(k)
                .Aggregate(new BinaryHeap_Generic<(int X, int Y, double Distance)>(new GenericMaxHeapComparer()),
                    (heap, point) =>
                    {
                        heap.Add((point.X, point.Y, CalculateDistance(point)));
                        return heap;
                    });
        }
    }

    class GenericMaxHeapComparer : IComparer<(int X, int Y, double Distance)>
    {
        public int Compare((int X, int Y, double Distance) x, (int X, int Y, double Distance) y)
        {
            return (int)(x.Distance - y.Distance);
        }
    }
}
