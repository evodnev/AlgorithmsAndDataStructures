using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Tree
{
	public class Node<T>
	{
        public Node(T data)
        {
			Data = data;
        }
		public T Data { get; set; }
		public Node<T> Left { get; set; }
		public Node<T> Right { get; set; }
		public Node<T> Parent { get; set; }
	}

}
