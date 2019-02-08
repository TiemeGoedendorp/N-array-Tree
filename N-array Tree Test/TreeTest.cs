using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using N_array_Tree;

namespace N_array_Tree_Test
{
    [TestFixture]
    public class TreeTest
    {
        [TestCase]
        public void AddChildNodeTest()
        {
            //Arrange
            var TopParent = new TreeNode<int>(5, null);
            var TestTree = new Tree<int>(TopParent);

            //Act
            var Child1 = TestTree.AddChildNode(TopParent, 9);
            var Child2 = TestTree.AddChildNode(TopParent, 3);
            var Child2_1 = TestTree.AddChildNode(Child2, 5);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(TestTree.AllNodes.Count == 4);
                Assert.Contains(Child1,TestTree.AllNodes);
                Assert.Contains(Child2, TestTree.AllNodes);
                Assert.Contains(Child2_1, TestTree.AllNodes);

                Assert.AreEqual(Child2,Child2_1.ParentNode);
                Assert.AreEqual(TopParent,Child2.ParentNode);

                Assert.That(TestTree.LeafCount == 2);
            });
        }

        [TestCase]
        public void AddChildNodeTestStrings()
        {
            //Arrange
            var TopParent = new TreeNode<string>("Hallo", null);
            var TestTree = new Tree<string>(TopParent);

            //Act
            var Child1 = TestTree.AddChildNode(TopParent, "Bas");
            var Child2 = TestTree.AddChildNode(TopParent, "Doei");
            var Child2_1 = TestTree.AddChildNode(Child2, "Bas");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(TestTree.AllNodes.Count == 4);
                Assert.Contains(Child1, TestTree.AllNodes);
                Assert.Contains(Child2, TestTree.AllNodes);
                Assert.Contains(Child2_1, TestTree.AllNodes);

                Assert.AreEqual(Child2, Child2_1.ParentNode);
                Assert.AreEqual(TopParent, Child2.ParentNode);

                Assert.That(TestTree.LeafCount == 2);
            });
        }

        [TestCase]
        public void SumToLeafTestInt()
        {
            // Arrange 
            var TopParent = new TreeNode<int>(5,null);
            var TestTree = new Tree<int>(TopParent);
            var Child1 = TestTree.AddChildNode(TopParent, 4);
            var Child2 = TestTree.AddChildNode(TopParent, 3);
            var Child2_1 = TestTree.AddChildNode(Child2, 5);
            var Child2_1_1 = TestTree.AddChildNode(Child2_1, 1);
            var Child2_1_2 = TestTree.AddChildNode(Child2_1, 2);

            // Act
            List<int> sum = TestTree.SumToLeafs();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sum.Count,TestTree.LeafCount);
                Assert.Contains(9,sum);
                Assert.Contains(15, sum);
                Assert.Contains(14, sum);
            });
        }

        [TestCase]
        public void SumToLeafTestString()
        {
            // Arrange 
            //Arrange
            var TopParent = new TreeNode<string>("Hallo", null);
            var TestTree = new Tree<string>(TopParent);

            //Act
            var Child1 = TestTree.AddChildNode(TopParent, "Bas");
            var Child2 = TestTree.AddChildNode(TopParent, "Dag");
            var Child2_1 = TestTree.AddChildNode(Child2, "Bas");

            // Act
            List<string> sum = TestTree.SumToLeafs();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(sum.Count, TestTree.LeafCount);
                Assert.Contains("0BasHallo", sum);
                Assert.Contains("0BasDagHallo", sum);
            });
        }

        [TestCase]
        public void RemoveNodeTest()
        {
            // Arrange 
            var TopParent = new TreeNode<int>(5, null);
            var TestTree = new Tree<int>(TopParent);
            var Child1 = TestTree.AddChildNode(TopParent, 4);
            var Child2 = TestTree.AddChildNode(TopParent, 3);
            var Child2_1 = TestTree.AddChildNode(Child2, 5);
            var Child2_1_1 = TestTree.AddChildNode(Child2_1, 1);
            var Child2_1_2 = TestTree.AddChildNode(Child2_1, 2);

            // Act
            TestTree.RemoveNode(Child2_1);
            List<int> sum = TestTree.SumToLeafs();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, TestTree.LeafCount);
                Assert.AreEqual(3, TestTree.AllNodes.Count);
                Assert.Contains(9, sum);
                Assert.Contains(8, sum);
            });
        }

        [TestCase]
        public void TraverseNodesTest()
        {
            // Arrange
            var TopParent = new TreeNode<int>(5, null);
            var TestTree = new Tree<int>(TopParent);
            var Child1 = TestTree.AddChildNode(TopParent, 4);
            var Child2 = TestTree.AddChildNode(TopParent, 3);
            var Child2_1 = TestTree.AddChildNode(Child2, 5);
            var Child2_1_1 = TestTree.AddChildNode(Child2_1, 1);
            var Child2_1_2 = TestTree.AddChildNode(Child2_1, 2);

            // Act
            string Test = TestTree.TraverseNodes();

            // Assert
            string result = "5[4,3[5[1,2,]]]";
            Assert.That(Test, Is.EquivalentTo(result));
        }
    }
}
