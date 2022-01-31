using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Tree
{
    public class GraphNode<T> //Вершина
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; } //исходящие связи

        public GraphNode()
        {
            Edges = new List<Edge<T>>();
        }
    }

    public class Edge<T> //Ребро
    {
        public int Weight { get; set; } //вес связи
        public GraphNode<T> Node { get; set; } // узел, на который связь ссылается
        //public GraphNode<T> Left { get; set; } // узел, на который связь ссылается
        //public GraphNode<T> Right { get; set; } // узел, на который связь ссылается
    }

}
