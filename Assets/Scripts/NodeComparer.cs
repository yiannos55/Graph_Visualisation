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
        foreach(Transform child in transform.GetChild(0))
        {
            DestroyImmediate(child.gameObject);
            //Destroy(child.gameObject);
        }
        foreach (Transform child in transform.GetChild(1))
        {
            DestroyImmediate(child.gameObject);
        }
        //Destroy(transform.Find("Node1Holder").transform.GetChild(0));
        nodeA = a;
        nodeB = b;         
        
        nodeA = Instantiate(nodeA, transform.Find("Node1Holder").position, Quaternion.identity, transform.Find("Node1Holder"));
        nodeB = Instantiate(nodeB, transform.Find("Node2Holder").position, Quaternion.identity, transform.Find("Node2Holder"));

        foreach (Node neighbour in nodeA.Neighbours)
        {  
            if (nodeA == neighbour) { continue; }
            node1Neighbours.Add(neighbour);
        }                              
        foreach (Node neighbour in nodeB.Neighbours)
        {       
            if (nodeB == neighbour) { continue; }
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


        //foreach (Node nodea in node1Neighbours)
        //{
        //    foreach (Node nodeb in node2Neighbours)
        //    {
        //        if (nodea == nodeb)
        //        {
        //            nodea.rend.material.color = Color.cyan;
        //            nodeb.rend.material.color = Color.cyan;
        //        }
        //    }
        //}
    }

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
