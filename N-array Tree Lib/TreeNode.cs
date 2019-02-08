using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_array_Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> ParentNode { get; set; }
        public List<TreeNode<T>> ChildsNodes {get; set; }

        public TreeNode(T value,TreeNode<T> parent)
        {
            this.Value = value;
            this.ParentNode = parent;
            this.ChildsNodes = new List<TreeNode<T>>();
        }
    }
}
