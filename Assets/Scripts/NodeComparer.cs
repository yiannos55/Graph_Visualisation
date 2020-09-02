using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeComparer : MonoBehaviour
{
    public Graph graph;
    private Node nodeA;
    private Node nodeB;

    public List<Node> node1Neighbours;
    public List<Node> node2Neighbours;
    //private List<Node> copyNeighboursA;
    //private List<Node> copyNeighboursB;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CompareNodes(Node a, Node b)
    {
        
        nodeA = a;
        nodeB = b;
            
        nodeA = Instantiate(a, transform.Find("Node1Holder").position, Quaternion.identity, transform.Find("Node1Holder"));
        nodeB = Instantiate(b, transform.Find("Node2Holder").position, Quaternion.identity, transform.Find("Node2Holder"));

        foreach (Node neighbour in nodeA.Neighbours)
        {  
            if (nodeA == neighbour) { break; }
            //Instantiate(neighbour, nodeA.transform.position + Random.onUnitSphere, Quaternion.identity, nodeA.transform);
            node1Neighbours.Add(neighbour);
        }                              
        foreach (Node neighbour in nodeB.Neighbours)
        {       
            if (nodeB == neighbour) { break; }
            //Instantiate(neighbour, nodeB.transform.position + Random.onUnitSphere, Quaternion.identity, nodeB.transform);
            node2Neighbours.Add(neighbour);
        }

        foreach(Node node in node1Neighbours)
        {
            Instantiate(node, nodeA.transform.position + Random.onUnitSphere, Quaternion.identity, nodeA.transform);
        }
        foreach (Node node in node2Neighbours)
        {
            Instantiate(node, nodeB.transform.position + Random.onUnitSphere, Quaternion.identity, nodeB.transform);
        }

    }

    //public void CompareNode()
    //{
    //    if (nodeA==null || nodeB == null)
    //    {
    //        Debug.Log("Node empty or not found");
    //    }
    //    else
    //    {
    //        Instantiate(nodeA, transform.Find("Node1Holder").position, Quaternion.identity, transform.Find("Node1Holder"));
    //        Instantiate(nodeB, transform.Find("Node2Holder").position, Quaternion.identity, transform.Find("Node2Holder"));
    //        foreach (Node nodeA_neighbour in nodeA.Neighbours)
    //        {
    //            copyNeighboursA.Add(nodeA_neighbour);
    //        }
    //        foreach(Node nodeB_neighbour in nodeB.Neighbours)
    //        {
    //            copyNeighboursB.Add(nodeB_neighbour);
    //        }
    //    }
    //}
    public void SetNodeA(string a)
    {
        nodeA = graph.Nodes.Find(node => node.displayName.Contains(a));
    }
    public void SetNodeB(string b)
    {
       nodeB = graph.Nodes.Find(node => node.displayName.Contains(b));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
