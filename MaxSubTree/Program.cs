using Algorithm_Multiple;
using Algorithm_Multiple.LinkedList;
using Algorithm_Multiple.Tushar;
using System;
using System.Collections.Generic;

namespace Algorithm_Multiple
{
    class Program
    {

        public static void Main(String[] args)
        {

            #region Min heap 
            MinHeap minHeap = new MinHeap();
            minHeap.Add(12);
            minHeap.Add(4);
            minHeap.Add(16);
            minHeap.Add(1);
            minHeap.Add(5);
            minHeap.Add(7);
            minHeap.Add(6);
            minHeap.PrintNodes();

            var minValue = minHeap.PopMin();
            minHeap.PrintNodes();

            #endregion
            #region Max of subarray of size K
            MaxOfAllSubArrayOfSizeK maxOfAllSubArrayOfSizeK = new MaxOfAllSubArrayOfSizeK();
            maxOfAllSubArrayOfSizeK.pirntKmax_Deque(new int[] { 3, 1, 2, 3 }, 4, 3);
            #endregion 

            #region Coin Minimul number
            CoinChangingMinimumCoin coinChangingMinimumCoin = new CoinChangingMinimumCoin();
            coinChangingMinimumCoin.minimumCoinBottomUp(11, new int[] { 1, 5, 6, 8 });
            #endregion

            #region stock span
            StockSpan stockSpan = new StockSpan();
            int[] S = new int[7];
            stockSpan.calculateSpan_InEfficient(new int[] { 100, 65, 60, 70, 68, 75, 85 }, 7, S);

            stockSpan.CalculateSpan_Stack(new int[] { 100, 65, 60, 70, 68, 75, 85 }, 7, S);
            #endregion

            #region Find binary min height
            PrintBinaryTreeMinDepth binaryTree1 = new PrintBinaryTreeMinDepth();
            TreeNode treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.right = new TreeNode(3);
            treeNode.left.left = new TreeNode(4);
            treeNode.left.right = new TreeNode(5);
            treeNode.right.right = new TreeNode(6);

            var level = binaryTree1.FindBinaryTreeMinDepth_Recursive(treeNode);
            level = binaryTree1.FindBinaryTreeMinDepth_LevelOrder(treeNode);
            Console.WriteLine(level);
            #endregion

            #region Graph - print all simple cycles
            Graph<int> graph = new Graph<int>(true);
            graph.addEdge(1, 2);
            graph.addEdge(2, 1);
            graph.addEdge(2, 3);
            graph.addEdge(3, 1);
            graph.addEdge(4, 5);

            AllCyclesInDirectedGraphTarjan allCyclesInDirectedGraphTarjan = new AllCyclesInDirectedGraphTarjan();
            List<List<Vertex<int>>> result = allCyclesInDirectedGraphTarjan.findAllSimpleCycles(graph);

            graph = new Graph<int>(true);
            graph.addEdge(1, 2);
            graph.addEdge(2, 1);
            graph.addEdge(4, 5);
            graph.addEdge(5, 1);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);
            result = allCyclesInDirectedGraphTarjan.findAllSimpleCycles(graph);
            #endregion

            #region Find binary path sum to target
            Algorithm_Multiple.Node root_pathSumToTarget = FindLargestSubTreeSum.newNode(50);
            root_pathSumToTarget.left = FindLargestSubTreeSum.newNode(17);
            root_pathSumToTarget.right = FindLargestSubTreeSum.newNode(76);
            root_pathSumToTarget.left.left = FindLargestSubTreeSum.newNode(9);
            root_pathSumToTarget.left.right = FindLargestSubTreeSum.newNode(23);
            root_pathSumToTarget.right.left = FindLargestSubTreeSum.newNode(54);
            root_pathSumToTarget.right.left.right = FindLargestSubTreeSum.newNode(72);
            root_pathSumToTarget.right.left.right.left = FindLargestSubTreeSum.newNode(67);
            root_pathSumToTarget.left.left.right = FindLargestSubTreeSum.newNode(14);
            root_pathSumToTarget.left.left.right.left = FindLargestSubTreeSum.newNode(12);
            root_pathSumToTarget.left.right.left = FindLargestSubTreeSum.newNode(19);

            BinaryTreePathSumToTarget binaryTreePathSumToTarget = new BinaryTreePathSumToTarget();
            binaryTreePathSumToTarget.FindPathSumEqualsTo(50, root_pathSumToTarget);
            #endregion

            #region Print Binary Tree in Vertial Order
            Algorithm_Multiple.BinaryTree_PrintVerticalOrder tree = new Algorithm_Multiple.BinaryTree_PrintVerticalOrder();

            /* Let us construct the tree 
            shown in above diagram */
            tree.root = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(1);
            tree.root.left = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(2);
            tree.root.right = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(3);
            tree.root.left.left = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(4);
            tree.root.left.right = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(5);
            tree.root.right.left = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(6);
            tree.root.right.right = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(7);
            tree.root.right.left.right = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(8);
            tree.root.right.right.right = new Algorithm_Multiple.PrintTreeInVerticalOrder_Node(9);

            Console.WriteLine("vertical order traversal is :");
            tree.VerticalTree(tree.root, 0);
            tree.printResult();
            #endregion

            #region Pythagorean Triplet
            PythagoreanTriplet pythagoreanTriplet = new PythagoreanTriplet();
            int[] arr_Pythagorean = { 3, 2, 4, 6, 5 };
            int n_arr_Pythagorean = arr_Pythagorean.Length;
            var result_pythagorean = pythagoreanTriplet.checkTriplet(arr_Pythagorean, n_arr_Pythagorean);
            #endregion
            #region Detect and Remove the cycle in linked list
            DetectRemoveLoopInLinkedList list = new DetectRemoveLoopInLinkedList();
            list.head = new Algorithm_Multiple.LinkedList.DetectRemoveLoopInLinkedList.Node(50);
            list.head.next = new Algorithm_Multiple.LinkedList.DetectRemoveLoopInLinkedList.Node(20);
            list.head.next.next = new Algorithm_Multiple.LinkedList.DetectRemoveLoopInLinkedList.Node(15);
            list.head.next.next.next = new Algorithm_Multiple.LinkedList.DetectRemoveLoopInLinkedList.Node(4);
            list.head.next.next.next.next = new Algorithm_Multiple.LinkedList.DetectRemoveLoopInLinkedList.Node(10);
            list.head.next.next.next.next.next = list.head.next.next;
            DetectRemoveLoopInLinkedList detectRemoveLinkedList = new DetectRemoveLoopInLinkedList();
            detectRemoveLinkedList.detectAndRemoveLoop(list.head);
            #endregion

            #region Linked List Reverse
            LinkedListReverseKNodes llist = new LinkedListReverseKNodes();
            /* Constructed Linked List is 1->2->3->4->5->6->  
        7->8->8->9->null */
            //llist.push(9);
            llist.push(8);
            llist.push(7);
            llist.push(6);
            llist.push(5);
            llist.push(4);
            llist.push(3);
            llist.push(2);
            llist.push(1);

            Console.WriteLine("Given Linked List");
            llist.printList();

            llist.head = llist.Reverse(llist.head, 3);

            Console.WriteLine("Reversed list");
            llist.printList();
            #endregion

            #region Build a binary tree
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
            PrintTreeInLevelOrder binaryTree = new PrintTreeInLevelOrder();
            BinaryTree binaryTree2 = new BinaryTree();
            var root = binaryTree2.CreateBinaryTreeFromArray(arr, 0);
            binaryTree2.PrintOut(root);

            Console.WriteLine("Print the tree level order");
            binaryTree.PrintOutTreeInLevelOrder(root);
            #endregion

            #region KClosestPoint To the OritinTest
            var kClosestPoint = new KClosePointsToOriginTest();
            kClosestPoint.GetKClosestPointsDistance();
            #endregion

            #region Left side view of binary tree - recursion
            var leftSideView_Recursion = new LeftSideViewOfBinaryTree_Recursion();
            leftSideView_Recursion.leftView();
            #endregion

            #region Left side view of binary tree- queue
            var leftSideView = new LeftSideViewOfBinaryTree();
            TreeNode leftsideTree = new TreeNode(7);
            leftsideTree.left = new TreeNode(6);
            leftsideTree.right = new TreeNode(5);
            leftsideTree.left.left = new TreeNode(4);
            leftsideTree.left.right = new TreeNode(3);
            leftsideTree.right.left = new TreeNode(2);
            leftsideTree.right.right = new TreeNode(1);
            leftsideTree.right.right.right = new TreeNode(8);
            leftSideView.PrintLeftSideView(leftsideTree);
            #endregion

            #region  LONGEST STRING MADE UP OF ONLY VOWELS
            var longestVowel = new LongestVowels.LongestVowels();
            var countVowel = longestVowel.longestVowel("earthporoblem");

            countVowel = longestVowel.longestVowel("earthporoblemeao");
            #endregion

            #region Equal 3 subset
            Equal3Subset.Equal3Subset equal3Subset = new Equal3Subset.Equal3Subset();

            var array = new int[] { 2, 4, 3, 3, 2, 2, 2 };
            array = new int[] { 8, 3, 6, 2, 7, 1, 2, 1 };
            //array = new int[] { 4,3,2,3,5,2,1};

            Equal3Subset.PartitionEqualSubsetSum partitionEqualSubsetSum = new Equal3Subset.PartitionEqualSubsetSum();

            var found = partitionEqualSubsetSum.canPartition(array);

            Equal3Subset.Dynamicprogramming_Partition dynamicprogramming_Partition = new Equal3Subset.Dynamicprogramming_Partition();
            found = dynamicprogramming_Partition.partition(array);
            //var found = equal3Subset.CanThreePartsEqualSum_way2(array);
            //found = equal3Subset.CanThreePartsEqualSum(array);

            //found = equal3Subset.equiSum(array);

            #endregion

            #region Max value of score of a path - the minimum value in that path.
            int[][] matrix = new int[][] {
                new int[] {1,2,3},
                new int[] {4,8,2},
                new int[] {1,5,3},
                new int[] {6,2,9}
            };

            var minpathMax = new MinimumPathMaximum();
            minpathMax.minSumPath(matrix);
            #endregion

            #region Min cost Path
            int[][] cost = new int[][] {
                new int[] {1,2,3},
                new int[] {4,8,2},
                new int[] {1,5,3},
                new int[] {6,2,9}
            };
            MinCostPath.GetMinCostPath(cost, 3, 2);
            #endregion

            #region Two sum
            var twosum_result = TwoSum.twoSumCloset(new int[] { 10, 3, 7, 11, 2 }, 9);
            #endregion

            #region Critical Connection Bridge in Networkd

            List<IList<int>> input = new List<IList<int>>();
            input.Add(new List<int> { 1, 2 });
            input.Add(new List<int> { 1, 3 });
            input.Add(new List<int> { 3, 4 });
            input.Add(new List<int> { 1, 4 });
            input.Add(new List<int> { 4, 5 });


            CriticalConnectionsClass ccClass = new CriticalConnectionsClass();
            var res = ccClass.CriticalConnections(5, input);


            input.Clear();
            input.Add(new List<int> { 1, 2 });
            input.Add(new List<int> { 1, 3 });
            input.Add(new List<int> { 2, 3 });
            input.Add(new List<int> { 2, 4 });
            input.Add(new List<int> { 2, 5 });
            input.Add(new List<int> { 4, 6 });
            input.Add(new List<int> { 5, 6 });
            res = ccClass.CriticalConnections(6, input);

            input.Clear();
            input.Add(new List<int> { 1, 2 });
            input.Add(new List<int> { 1, 3 });
            input.Add(new List<int> { 2, 3 });
            input.Add(new List<int> { 3, 4 });
            input.Add(new List<int> { 3, 6 });
            input.Add(new List<int> { 4, 5 });
            input.Add(new List<int> { 6, 7 });
            input.Add(new List<int> { 6, 9 });
            input.Add(new List<int> { 7, 8 });
            input.Add(new List<int> { 8, 9 });
            res = ccClass.CriticalConnections(9, input);

            #endregion 
            #region Minimum Cost to connect rope
            MinumumCostConnectRope.Calculate();
            #endregion

            #region Product Suggestion
            var products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            var search = "mouse";

            var result_productSuggestion = ProductsSuggestion.suggestedProducts(products, search);
            //Console.WriteLine("suggest products:" + result_productSuggestion);

            //products = new string[] { "havana" };
            //search = "havana";
            //result_productSuggestion = ProductsSuggestion.suggestedProducts(products, search);
            //Console.WriteLine("suggest products:" + result_productSuggestion);

            //products = new string[] { "bags", "baggage", "banner", "box", "cloths" };
            //search = "bags";
            //result_productSuggestion = ProductsSuggestion.suggestedProducts(products, search);
            //Console.WriteLine("suggest products:" + result_productSuggestion);
            #endregion

            #region common lowest ancestor
            var root_ancestor = LowestCommonAncestor.BuildBTree();
            var common_ancestor = LowestCommonAncestor.CommonAncestor(root_ancestor, root_ancestor.right, root_ancestor.left.right);
            #endregion

            #region Recorder Log file
            string[] logs = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let4 not zero", "let2 own kit dig", "let3 art zero", "dig3 4 7" };
            RecorderLogFiles.ReorderLogFiles(logs);
            #endregion

            #region Number of Islands
            char[,] grid_island = new char[,] {
                   { '1','1','0','1','0'},
                   { '1','1','0','1','0'},
                   { '1','1','0','0','0'},
                   { '0','0','0','0','1'}
            };
            var islands = NumberOfIslands.IslandsNumber(grid_island);

            char[,] grid_island_1 = new char[,] {
                   { '1','1','0','1','0'},
                   { '1','1','0','1','0'},
                   { '1','1','0','0','0'},
                   { '0','0','0','0','1'}
            };
            NumberOfIslands numberOfIslands = new NumberOfIslands();
            islands = numberOfIslands.Review_IslandNumber(grid_island_1);

            #endregion

            #region Delete BST node
            var deleteRoot = BinarySearchTree.InitializeAnExampleTree();
            DeleteNodeInBinarySearchTree deleteNodeInBinarySearchTree = new DeleteNodeInBinarySearchTree();
            var afterDeleteRoot = deleteNodeInBinarySearchTree.DeleteTreeNode(deleteRoot, 15);
            #endregion

            #region Validate BST
            var treeRoot = BinarySearchTree.InitializeAnExampleTree();
            ValidateBinaryTreeIsBinarySearchTree validateBinaryTreeIsBinary = new ValidateBinaryTreeIsBinarySearchTree();
            var val = validateBinaryTreeIsBinary.isBSTUtil(treeRoot, Int32.MinValue, Int32.MaxValue);
            Console.WriteLine(val);
            #endregion

            #region rotting Orange
            int[,] grid = new int[,] { { 0, 1, 1, 0, 1 }, { 0, 1, 0, 1, 0 }, { 0, 0, 0, 0, 1 }, { 0, 1, 0, 0, 0 } };
            Console.WriteLine(RottingOrange.OrangesRotting(grid));
            #endregion

            #region Key frequency
            int k1 = 2;
            String[] keywords1 = { "anacell", "cetracular", "betacellular" };
            String[] reviews1 = { "Anacell provides the best services in the city", "betacellular has awesome services",
            "Best services provided by anacell, everyone should use anacell", };

            var str1 = TopKWordsFrequency.GetTopKeywords_simple(k1, keywords1, reviews1);
            Console.WriteLine(string.Join(" ", str1));


            int k2 = 2;
            String[] keywords2 = { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
            String[] reviews2 = { "I love anacell Best services; Best services provided by anacell",
            "betacellular has great services", "deltacellular provides much better services than betacellular",
            "cetracular is worse than anacell", "Betacellular is better than deltacellular.", };
            var str2 = TopKWordsFrequency.GetTopKeywords_simple(k2, keywords2, reviews2);
            Console.WriteLine(string.Join(" ", str2));
            #endregion

            #region expression evaluation
            Console.WriteLine(EvaluateString.evaluate("1+2*3"));
            Console.WriteLine(EvaluateString.evaluate("4-2+6*3"));
            Console.WriteLine(EvaluateString.evaluate("1++2"));
            Console.WriteLine(EvaluateString.evaluate("9+2*6"));
            Console.WriteLine(EvaluateString.evaluate("10 + 2 * 6".Replace(" ", "")));
            Console.WriteLine(EvaluateString.evaluate("100 * 2 + 12".Replace(" ", "")));
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 )".Replace(" ", "")));
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 ) / 14".Replace(" ", "")));
            #endregion

            #region Find the max size BST in BT

            FindLargestBinarySearchTreeInBinaryTree.MaxSizeofBSTInBT();


            #endregion

            #region Find largest sum of subtree
            /* 
                    1                    
                  /	 \ 
                -2	 3                
                / \ / \ 
                4 5 -6 2 
            */

            Algorithm_Multiple.Node root1 = FindLargestSubTreeSum.newNode(-1);
            root1.left = FindLargestSubTreeSum.newNode(-2);
            root1.right = FindLargestSubTreeSum.newNode(-3);
            root1.left.left = FindLargestSubTreeSum.newNode(-4);
            root1.left.right = FindLargestSubTreeSum.newNode(-5);
            root1.right.left = FindLargestSubTreeSum.newNode(-6);
            root1.right.right = FindLargestSubTreeSum.newNode(2);

            Console.WriteLine(FindLargestSubTreeSum.findLargestSubtreeSum(root1));
            #endregion

            #region Duplicate numbers in 2 sorted array
            int[] arr1 = { 1, 2, 4, 5, 6 };
            int[] arr2 = { 2, 3, 5, 7 };
            int m = arr1.Length;
            int n = arr2.Length;


            DuplicateNumbersInSortedArray.printIntersection(arr1, arr2, m, n);
            #endregion

            #region word break
            //store the words in the dictionary as below
            //l
            //  -e
            //      -e
            //          -t end

            var dictionary = new List<string>();
            dictionary.Add("leet");
            dictionary.Add("code");
            var wordindictionary = WordInTheDictionary.DoWordBreak("coder", dictionary);
            Console.WriteLine(wordindictionary);
            #endregion

            #region 90 rotate matrix 
            int N = 4;

            // Test Case 1 
            int[,] mat = {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 },
            { 13, 14, 15, 16 }
            };

            // Tese Case 2 
            /* int mat[][] = 
            { 
                {1, 2, 3}, 
                {4, 5, 6}, 
                {7, 8, 9} 
            }; 
            */

            // Tese Case 3 
            /*int mat[][] = 
            { 
                {1, 2}, 
                {4, 5} 
            };*/

            // displayMatrix(mat); 

            RotateMatrix.rotateMatrix(N, mat);

            // Print rotated matrix 
            RotateMatrix.displayMatrix(N, mat);
            #endregion

            #region Int to roma
            Console.WriteLine(IntToRom.IntToRoman(5678));
            #endregion


            #region max int from the string
            Console.WriteLine(StringToInt.MyAtoi("3243l4  23"));
            #endregion

            #region Test BinaryMinHeap
            BinaryMinHeap<string> heap = new BinaryMinHeap<string>();

            heap.add(3, "Tushar");
            heap.add(4, "Ani");
            heap.add(8, "Vijay");
            heap.add(10, "Pramila");
            heap.add(5, "Roy");
            heap.add(6, "NTF");
            heap.add(2, "AFR");
            heap.printHeap();
            heap.decrease("Pramila", 1);
            heap.printHeap();
            #endregion

            #region Test PrimMST
            LeetPlayround.MinCosttoConnectAllNodes.PrintoutMinCostConnectAllCodes();
            //Graph graph = new Graph(false);
            //graph.addEdge(1, 2, 3);
            //graph.addEdge(2, 3, 1);
            //graph.addEdge(3, 1, 1);
            //graph.addEdge(1, 4, 1);
            //graph.addEdge(2, 4, 3);
            //graph.addEdge(4, 5, 6);
            //graph.addEdge(5, 6, 2);
            //graph.addEdge(3, 5, 5);
            //graph.addEdge(3, 6, 4);

            //PrimMST prims = new PrimMST();
            //List<Edge> edges = prims.primMST(graph);
            //foreach (Edge edge in edges)
            //{
            //    Console.WriteLine(edge);
            //}
            #endregion

            #region Graph DFS
            GraphDFS g = new GraphDFS(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal " +
                              "(starting from vertex 2)");

            g.DFS(2);
            Console.ReadKey();
            #endregion
        }

    }
}