using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp2;

namespace FittingTester
{
    public struct Data : 
        IEquatable<Data>
    {
         public int generation;
         public int order;

        bool IEquatable<Data>.Equals(Data other)
        {
            return other.generation == generation &&
                other.order == order;
        }
    }

    [TestClass]
    public class UnitTest2
    {
        HierarchyTreeNode<Data> __root00;
        HierarchyTreeNode<Data> __branch10 ;
        HierarchyTreeNode<Data> __branch11 ;
        HierarchyTreeNode<Data> __branch20;
        HierarchyTreeNode<Data> __leaf21 ;
        HierarchyTreeNode<Data> __leaf22 ;
        HierarchyTreeNode<Data> __leaf23 ;
        HierarchyTreeNode<Data> __leaf24 ;
        HierarchyTreeNode<Data> __leaf30 ;


        [TestInitialize]
        public void TestInitialize()
        {
           __root00 = new HierarchyTreeNode<Data>(new Data() { generation = 0, order = 0 }, null);
           __branch10 = new HierarchyTreeNode<Data>(new Data() { generation = 1, order = 0 }, __root00);
           __branch11 = new HierarchyTreeNode<Data>(new Data() { generation = 1, order = 1 }, __root00);
           __branch20 = new HierarchyTreeNode<Data>(new Data() { generation = 2, order = 0 }, __branch10);
           __leaf21 = new HierarchyTreeNode<Data>(new Data() { generation = 2, order = 1 }, __branch10);
           __leaf22 = new HierarchyTreeNode<Data>(new Data() { generation = 2, order = 2 }, __branch10);
           __leaf23 = new HierarchyTreeNode<Data>(new Data() { generation = 2, order = 3 }, __branch11);
           __leaf24 = new HierarchyTreeNode<Data>(new Data() { generation = 2, order = 4 }, __branch11);
           __leaf30 = new HierarchyTreeNode<Data>(new Data() { generation = 3, order = 0 }, __branch20);
        }

        [TestMethod]
        public void TestMethodHierarchyNode1()
        {
            // Root(0,0)
            // |
            // |-------Branch10------Branch20-------------------Leaf30
            // |                 |---Leaf21
            // |                 |---Leaf22
            // L-------Branch11------Leaf23
            //                   |--Leaf24

           var __list = HierarchyTreeNode<Data>.Path(__leaf30, __leaf24);

            Assert.Equals(__list.Count, 6);
        }
    }
}
