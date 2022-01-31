using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmsAndDataStructures.Tree
{
    internal class Tree<T>
    {
        public Node<T> Root { get; private set; }

        public void AddNode(Node<T> node)
        {
            Trace.Assert(node != null);
            if (Root == null)
            {
                Root = node;
                return;
            }
            //TODO: куда добавлять?
            Node<T> nodeToAdd = GetLastNodeWithEmptyChildLink(Root);
            if (nodeToAdd.Left == null)
            {
                nodeToAdd.Left = node;
            }
            else
                nodeToAdd.Right = node;
            node.Parent = nodeToAdd;
        }

        public void PrintTree()
        {
            PrintTree(0, Root);
        }

        private void PrintTree(int level, Node<T> node)
        {
            Console.WriteLine($"{level} - {node.Data}");
            if (node.Left != null)
                PrintTree(level + 1, node.Left);
            if (node.Right != null)
                PrintTree(level + 1, node.Right);
        }

        private Node<T> GetLastNodeWithEmptyChildLink(Node<T> root)
        {
            // TODO: Переделать реализацию для создания сбалансированного дерева.
            if (root.Left == null || root.Right == null)
                return root;
            return GetLastNodeWithEmptyChildLink(root.Left);
        }
    }
}
