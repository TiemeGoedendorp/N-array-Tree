using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_array_Tree
{
    public class Tree<T>:IEnumerable<T>
    {
        //aantal nodes in de tree
        public int Count = 0;

        //aantal leaves in de tree
        public int LeafCount = 1;

        //Opper parent intialiseren als je een tree aanmaakt
        public TreeNode<T> TopParent { get; set; }

        //List met alle nodes aanmaken
        public List<TreeNode<T>> AllNodes = new List<TreeNode<T>>();

        //Stringbuilder voor traverse functie
        public StringBuilder TraverseString = new StringBuilder();

        public Tree(TreeNode<T> Parent)
        {
            this.TopParent = Parent;
            AllNodes.Add(TopParent);
        }

        public TreeNode<T> AddChildNode(TreeNode<T> ParentNode, T value)
        {
            Count++;
            LeafCount++;
            if (ParentNode.ChildsNodes.Count == 0)
                LeafCount--;

            TreeNode<T> newTreeNode = new TreeNode<T>(value, ParentNode);
            newTreeNode.ParentNode = ParentNode;
            newTreeNode.ParentNode.ChildsNodes.Add(newTreeNode);
            AllNodes.Add(newTreeNode);
            return newTreeNode;
        }

        public void RemoveNode(TreeNode<T> TempNode)
        {
            TempNode.ParentNode.ChildsNodes.Remove(TempNode);
            AllNodes.Remove(TempNode);
            if (TempNode.ChildsNodes.Count != 0)
            {
                foreach (TreeNode<T> TempChild in TempNode.ChildsNodes.ToList())
                {
                    RemoveNode(TempChild);
                    LeafCount--;
                }

                LeafCount++;
            }
        }

        public string TraverseNodes()
        {
            TraverseString.Clear();
            return TraverseNodes(TopParent);
        }

        private string TraverseNodes(TreeNode<T> ParentNode)
        {
            TraverseString.AppendFormat("{0}[",ParentNode.Value);
            foreach (TreeNode<T> Tempchild in ParentNode.ChildsNodes)
            {
                if (Tempchild.ChildsNodes.Count != 0)
                    TraverseNodes(Tempchild);

                if (Tempchild.ChildsNodes.Count == 0)
                TraverseString.AppendFormat("{0},", Tempchild.Value);
            }
            TraverseString.Append("]");
            return TraverseString.ToString();
        }

        public List<T> SumToLeafs()
        {
            List<T> SumList = new List<T>();
            foreach (TreeNode<T> TempNode in AllNodes)
            {
                if (TempNode.ChildsNodes.Count == 0)
                {
                    dynamic Counter = 0;
                    Boolean end = true;
                    TreeNode<T> CountNode = TempNode;
                    while (end)
                    {
                        Counter += CountNode.Value;
                        if (CountNode.ParentNode != null)
                        CountNode = CountNode.ParentNode;
                        else
                        end = false;
                    }
                    SumList.Add(Counter);
                }
            }
            return SumList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (TreeNode<T> node in AllNodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (TreeNode<T> node in AllNodes)
                yield return node.Value;
        }
    }
}
