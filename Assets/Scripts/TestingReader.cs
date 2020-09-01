using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class TestingReader : MonoBehaviour
{
    public int maxNodes = 0;

    public Vertex vertex;
    public DirectedGraph graph;
    public class Vertex
    {
        public string name;
        public Vertex(string name)
        {
            this.name = name;
        }
    }

    
    public class Relations
    {
        public Vertex node1;
        public Vertex node2;
        public int similarity=0;
        public Relations(Vertex node1,Vertex node2, int similarity)
        {
            this.node1=node1;
            this.node2=node2;
            this.similarity+=similarity;
        }

    }
    public class DirectedGraph
    {
        public int MAX_NODES = 2001;
        int nodes;
        int edges;
        bool[,] adjMatrix;
        Vertex[] vertexList;
        string[] test;
        List<List<bool>> allNodesArr;

        public List<Relations> relations;
        public DirectedGraph()
        {
            adjMatrix = new bool[MAX_NODES, MAX_NODES];
            vertexList = new Vertex[MAX_NODES];
        }

        public int Vertices()
        {
            return nodes;
        }

        public int Edges()
        {
            return edges;
        }

        public void InsertNode(string name)
        {
            vertexList[nodes++] = new Vertex(name);
        }

        public void InsertEdge(string s1, string s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s1);

            if (adjMatrix[u, v])
                Debug.Log("already there");
            else
            {
                adjMatrix[u, v] = true;
                edges++;
            }
        }
        private int GetIndex(string s)
        {
            for (int i = 0; i < nodes; i++)
                if (s.Equals(vertexList[i].name))
                    return i;
            throw new System.InvalidOperationException("inv vertex");
        }

        public bool EdgeExists(string s1, string s2)
        {
            return IsAdjacent(GetIndex(s1), GetIndex(s2));
        }

        private bool IsAdjacent(int u, int v)
        {
           // Similarity(adjMatrix);
            return adjMatrix[u, v];
        }

        //private void Similarity(bool[,] matr)
        //{
        //    for (int i = 0; i < nodes; ++i)
        //    {
        //        int sum = 0;
        //        for (int j = 0; j<nodes; ++j)
        //        {
        //            if (matr[i, j] == matr[i + 1, j])
        //            {
        //                sum++;                       
        //            }
        //        }
        //     relations.Add(new Relations(vertexList[i], vertexList[i + 1], sum));
        //    }                     
        //}

        //void compare(bool[,] matr)
        //{
        //    for(int i = 0; i < nodes; ++i)
        //    {
        //        List<bool> vert = new List<bool>();
        //        for (int j = 0; j < nodes; ++j)
        //        { 
        //            vert.Add(matr[i,j]);
        //        }
        //        allNodesArr.Add(vert);
        //    }

        //    foreach(List<bool> ve1 in allNodesArr)
        //    {
        //        foreach (List<bool> ve2 in allNodesArr)
        //        {
        //            for (int i = 0; i < nodes; ++i)
        //            {
        //                if (ve1[i] == ve2[i])
        //                {
                         
        //                }
        //            }
        //        }
        //    }
        //}


        //public void Display()
        //{
        //    for(int i =0; i<nodes; ++i)
        //    {
        //        for (int j = 0; j < nodes; ++j)
        //            if (adjMatrix[i, j])
        //                Debug.Log("1");
        //            else
        //                Debug.Log("0");
        //        //new line
        //    }
        //}
    }




    // Start is called before the first frame update
    void Start()
    {
        graph = new DirectedGraph();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
