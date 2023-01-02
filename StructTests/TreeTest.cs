using Microsoft.VisualStudio.TestTools.UnitTesting;
using Struct.Tree;

namespace StructTests
{
    [TestClass()]
    public class TreeTest
    {
        [TestMethod()]
        public void AddTest()
        {
            Tree<int> tree = new Tree<int>(1);
            tree.Add(new Node<int>(2));
            tree.Add(new Node<int>(3));
            tree.Add(new Node<int>(4));
            tree.Add(new Node<int>(5));
            tree.Add(new Node<int>(6));


            Assert.AreEqual("1 2 3 4 5 6 ", tree.ToString());
            


        }

        [TestMethod()]
        public void RemoveTest()
        {
            Tree<int> tree = new Tree<int>(1);
            tree.Add(new Node<int>(2));
            tree.Add(new Node<int>(3));
            tree.Add(new Node<int>(4));
            tree.Add(new Node<int>(5));
            tree.Add(new Node<int>(6));

            tree.Remove(3);

            Assert.AreEqual("1 2 4 5 6 ", tree.ToString());
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Tree<int> tree = new Tree<int>(1);
            tree.Add(new Node<int>(2));
            tree.Add(new Node<int>(3));
            tree.Add(new Node<int>(4));
            tree.Add(new Node<int>(5));
            tree.Add(new Node<int>(6));

            Assert.AreEqual(true, tree.Contains(3));
        }

        [TestMethod()]
        public void FindNodeTest()
        {
            Tree<int> tree = new Tree<int>(1);
            tree.Add(new Node<int>(2));
            Node<int> node = new Node<int>(3);
            tree.Add(node);
            tree.Add(new Node<int>(4));
            tree.Add(new Node<int>(5));
            tree.Add(new Node<int>(6));

            Assert.AreEqual(node, tree.FindNode(3));
        }

        [TestMethod()]
        public void IteratorTest()
        {
            Tree<int> tree = new Tree<int>(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);

            int count = 0;

            foreach (var item in tree)
            {
                count++;
            }

            Assert.AreEqual(4, count);
        }

    }
}
