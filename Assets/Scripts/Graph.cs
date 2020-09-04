using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public int scale = 1;
    public bool again;

    public List<Node> Nodes;
    public List<Edge> Edges;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdatePositions_FBG()
    {
        //repulsion between nodes
        float totalEnergy = 0;
        foreach (Node a in Nodes)
        {
            foreach (Node b in Nodes)
            {
                Vector3 posA = a.transform.position;
                Vector3 posB = b.transform.position;
                Vector3 direction = posA - posB;
                float distance = direction.magnitude;

                if (distance > 0)
                {
                    float c = 3;
                    float f = 0.001f * c / distance;    //hooke's law
                    posA += direction / distance * f;
                    posB -= direction / distance * f;
                    a.transform.position = posA;
                    b.transform.position = posB;
                }
            }
        }

        //attraction between connected Nodes
        foreach (Edge edge in Edges)
        {
            Vector3 targetpos = edge.target.transform.position;
            Vector3 sourcepos = edge.source.transform.position;
            Vector3 direction = targetpos - sourcepos;
            float distance = direction.magnitude;
            totalEnergy += distance;
            if (distance > 0)
            {
                float c = 3;
                float f = -0.001f * c * distance;
                targetpos += direction / distance * f;
                sourcepos -= direction / distance * f;
                edge.target.transform.position = targetpos;
                edge.source.transform.position = sourcepos;
            }
        }
        if (totalEnergy > Edges.Count * 6)
        {
            again = true;
        }
        else
        {
            again = false;
        }
    }

    public void Draw_Circular()
    {
        // Nodes clustered by type, each type gets assigned its own height
        foreach (Node node in Nodes)
        {
            Vector3 randomPosition = Random.onUnitSphere * 10;
            switch (node.type)
            {
                case "RProtein":
                case "Protein":
                    randomPosition.y = 0;
                    node.transform.position = randomPosition;
                    break;
                case "RPathway":
                case "Pathway":
                    randomPosition.y = -5;
                    node.transform.position = randomPosition;
                    break;
                case "RGene":
                case "Gene":
                    randomPosition.y = 5;
                    node.transform.position = randomPosition;
                    break;
                case "Disorder":
                    randomPosition.y = 10;
                    node.transform.position = randomPosition;
                    break;
            }
        }
    }

    public void SortAndDraw()
    {
        foreach(Node node in Nodes)
        {
            node.isVisited = false;
        }
        List<Node> sortedNodes;
        sortedNodes = Nodes;
        sortedNodes.Sort((x, y) => x.Neighbours.Count.CompareTo(y.Neighbours.Count));
        sortedNodes.Reverse();
        //foreach (Node a in Nodes)
        //{
        //    Debug.Log(a.Neighbours.Count);
        //}
        RecureDraw(sortedNodes);

    }

    public void RecureDraw(List<Node> nodes)
    {
        foreach (Node a in nodes)
        {
            if (a.isVisited) { continue; }
            else
            {
                if (a == nodes[0])
                    a.transform.position = new Vector3(0, 0, 0);
                else
                    a.transform.position = Random.onUnitSphere * 10;
                
                foreach (Node b in a.Neighbours)
                {
                    if (b.isVisited) { continue; }
                    if (b.Neighbours.Count > a.Neighbours.Count / 3) { continue; }
                    else
                    {
                        b.transform.position = a.transform.position + Random.onUnitSphere * 2;
                        b.isVisited = true;
                        // recureDraw(b.Neighbours);
                    }
                }
                a.isVisited = true;
            }
        }
    }


    /// testing binary distance///
    public class Connection
    {
       public Node node1;
       public Node node2;
       public float similarity;

        public Connection(Node node1, Node node2, float similarity)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.similarity = similarity;
        }
       
    }

    public List<Connection> FindDistances()
    {
        List<Connection> connections = new List<Connection>();

        foreach (Node node1 in Nodes)
        {
            foreach (Node node2 in Nodes)
            {
                if (node1 == node2) { continue; }
                int sum = 0;
                if (node1.Neighbours.Count >= node2.Neighbours.Count)
                {
                    foreach (Node node1Bro in node1.Neighbours)
                    {
                        if (node2.Neighbours.Contains(node1Bro))
                        {
                            sum++;
                        }
                    }
                    connections.Add(new Connection(node1, node2, sum / Nodes.Count));
                }
                else if (node1.Neighbours.Count < node2.Neighbours.Count)
                {
                    foreach (Node node2Bro in node2.Neighbours)
                    {
                        if (node1.Neighbours.Contains(node2Bro))
                        {
                            sum++;
                        }
                    }
                    connections.Add(new Connection(node1, node2, sum / Nodes.Count));
                }
            }
        }
        foreach (Connection SMC in connections)
        {
            //System.Console.Write("  Node1:  ", SMC.node1.id);
            //System.Console.Write("  Node1:  ", SMC.node2.id);
            //System.Console.Write("  dist: ", SMC.similarity);
            //Debug.Log("Node1 :" + SMC.node1.id + "  Node 2 :" + SMC.node2.id + "dist  :" + SMC.similarity);
        }
        return connections;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void setScale(float newScale)
    {
        transform.localScale = new Vector3(1, 1, 1) * newScale;
    }
}
