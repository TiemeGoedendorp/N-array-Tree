using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_array_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode<int> ParentNode = new TreeNode<int>(5,null); 
            Tree<int> UpperParent = new Tree<int>(ParentNode);
            var Child1 = UpperParent.AddChildNode(UpperParent.TopParent,4);
            var Child2 = UpperParent.AddChildNode(UpperParent.TopParent, 3);

            var Child2_1 = UpperParent.AddChildNode(Child2, 5);

            var Child2_1_1 = UpperParent.AddChildNode(Child2_1, 1);
            var Child2_1_2 = UpperParent.AddChildNode(Child2_1, 2);


            string newTree = UpperParent.TraverseNodes();
            Console.Write(newTree);
            Console.WriteLine();
            List<int> LeafSums = UpperParent.SumToLeafs();
            foreach(int tempInt in LeafSums)
            Console.WriteLine(tempInt.ToString());
            //delete an child and show again
            UpperParent.RemoveNode(Child2_1);
            string newTree2 = UpperParent.TraverseNodes();
            Console.Write(newTree2);

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
