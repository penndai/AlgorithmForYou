using System;

// C# program to find largest BST subtree in given Binary Tree 

public class Node
{

    public int data;
    public Node left, right;

    public Node(int d)
    {
        data = d;
        left = right = null;
    }
}

public class Value
{

    public int max_size = 0; // for size of largest BST 
    public bool is_bst = false;
    public int right_min = int.MaxValue; // For minimum value in right subtree 
    public int left_max = int.MinValue; // For maximum value in left subtree 

}

public class FindLargestBinarySearchTreeInBinaryTree
{

    public static Node root;
    public Value val = new Value();

    /* largestBSTUtil() updates max_size for the size of the largest BST 
   subtree. Also, if the tree rooted with node is non-empty and a BST, 
   then returns size of the tree. Otherwise returns 0.*/
    public virtual int largestBST(Node node)
    {        
        largestBSTUtil_simple(node, val);
        return val.max_size;
    }

    public virtual int largestBSTUtil_simple(Node node, Value value)
    {

        /* Base Case */
        if (node == null)
        {
            value.is_bst = true; // An empty tree is BST 
            return 0; // Size of the BST is 0 
        }

        /* A flag variable for left subtree property 
		i.e., max(root->left) < root->data */
        bool left_flag = false;

        /* A flag variable for right subtree property 
		i.e., min(root->right) > root->data */
        bool right_flag = false;

        int left_Size, right_Size; // To store sizes of left and right subtrees 

        /* Following tasks are done by recursive call for left subtree 
		a) Get the maximum value in left subtree (Stored in *max_ref) 
		b) Check whether Left Subtree is BST or not (Stored in *is_bst_ref) 
		c) Get the size of maximum size BST in left subtree (updates *max_size) */
        value.left_max = int.MinValue;
        left_Size = largestBSTUtil_simple(node.left, value);
        if (value.is_bst == true && node.data > value.left_max)
        {
            left_flag = true;
        }

        /* Before updating *min_ref, store the min value in left subtree. So that we 
have the correct minimum value for this subtree */
        int min = value.right_min;

        /* The following recursive call does similar (similar to left subtree) 
		task for right subtree */
        value.right_min = int.MaxValue;
        right_Size = largestBSTUtil_simple(node.right, value);
        if (value.is_bst == true && node.data < value.right_min)
        {
            right_flag = true;
        }

        // Update min and max values for the parent recursive calls 
        if (min < value.right_min)
        {
            value.right_min = min;
        }
        if (node.data < value.right_min) // For leaf nodes 
        {
            value.right_min = node.data;
        }
        if (node.data > value.left_max)
        {
            value.left_max = node.data;
        }

        /* If both left and right subtrees are BST. And left and right 
		subtree properties hold for this node, then this tree is BST. 
		So return the size of this tree */
        if (left_flag && right_flag)
        {
            if (left_Size + right_Size + 1 > value.max_size)
            {
                value.max_size = left_Size + right_Size + 1;
            }
            return left_Size + right_Size + 1;
        }
        else
        {
            //Since this subtree is not BST, set is_bst flag for parent calls 
            value.is_bst = false;
            return 0;
        }
    }

    //prepare for program calling
    public static void MaxSizeofBSTInBT()
    {
        /* Let us construct the following Tree 
				50 
			    /	 \ 
			    10	 60 
		        / \	 / \ 
		        5 20 55 70 
		            /	 / \ 
		            45 65 80 
		*/

        FindLargestBinarySearchTreeInBinaryTree tree = new FindLargestBinarySearchTreeInBinaryTree();
        FindLargestBinarySearchTreeInBinaryTree.root = new Node(50);
        FindLargestBinarySearchTreeInBinaryTree.root.left = new Node(10);
        FindLargestBinarySearchTreeInBinaryTree.root.right = new Node(60);
        FindLargestBinarySearchTreeInBinaryTree.root.left.left = new Node(5);
        FindLargestBinarySearchTreeInBinaryTree.root.left.right = new Node(20);
        FindLargestBinarySearchTreeInBinaryTree.root.right.left = new Node(55);
        FindLargestBinarySearchTreeInBinaryTree.root.right.left.left = new Node(45);
        FindLargestBinarySearchTreeInBinaryTree.root.right.right = new Node(70);
        FindLargestBinarySearchTreeInBinaryTree.root.right.right.left = new Node(65);
        FindLargestBinarySearchTreeInBinaryTree.root.right.right.right = new Node(80);
        Console.WriteLine("Size of largest BST is " + tree.largestBST(root));
        /* The complete tree is not BST as 45 is in right subtree of 50. 
		The following subtree is the largest BST 
			60 
			/ \ 
		   55 70 
		   /  / \ 
		  45 65 80 
		*/
        FindLargestBinarySearchTreeInBinaryTree secondTree = new FindLargestBinarySearchTreeInBinaryTree();
        FindLargestBinarySearchTreeInBinaryTree.root = new Node(60);
        FindLargestBinarySearchTreeInBinaryTree.root.left = new Node(55);
        FindLargestBinarySearchTreeInBinaryTree.root.right = new Node(70);
        FindLargestBinarySearchTreeInBinaryTree.root.left.left = new Node(45);
        FindLargestBinarySearchTreeInBinaryTree.root.right.left = new Node(65);
        FindLargestBinarySearchTreeInBinaryTree.root.right.right = new Node(80);

        Console.WriteLine("Size of largest BST is " + secondTree.largestBST(root));
    }
}
