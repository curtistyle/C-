Tree<int> tree = new Tree<int>();
tree.root = new TreeNode<int>() { Data = 100 };
tree.root.Children = new List<TreeNode<int>>
{
    new TreeNode<int>() {Data=50, Parent=tree.root},
    new TreeNode<int>() {Data=1, Parent=tree.root},
    new TreeNode<int>() {Data=150, Parent=tree.root}
};

tree.root.Children[2].Children = new List<TreeNode<int>>()
{
    new TreeNode<int>(){Data=30, Parent= tree.root.Children[2]}
};

public class Tree<T>
{
    public TreeNode<T> root { get; set; }
}

public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; }
    public int GetHeight()
    {
        int heigth = 1;
        TreeNode<T> current = this;
        while(current.Parent != null)
        {
            heigth++;
            current = current.Parent;
        }
        return heigth;
    }
}

