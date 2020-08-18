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
                // if (edge.target == root || edge.source == root) c *= 5000;
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
        foreach (Node node in Nodes)
        {
            
            switch (node.type)
            {
                case "RProtein":
                case "Protein":
                    Vector3 random_protein_position = Random.onUnitSphere * 10;
                    random_protein_position.y = 0;
                    node.transform.position = random_protein_position;
                    break;
                case "RPathway":
                case "Pathway":
                    Vector3 random_pathway_position = Random.onUnitSphere * 10;
                    random_pathway_position.y = -5;
                    node.transform.position = random_pathway_position;
                    break;
                case "RGene":
                case "Gene":
                    Vector3 random_gene_position = Random.onUnitSphere * 10;
                    random_gene_position.y = 5;
                    node.transform.position = random_gene_position;
                    break;
                case "Disorder":
                    Vector3 random_disorder_position = Random.onUnitSphere * 10;
                    random_disorder_position.y = 10;
                    node.transform.position = random_disorder_position;
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void setScale(float newScale)
    {
        transform.localScale=new Vector3(1,1,1)*newScale;
    }
    public void Init()
    {

    }
}
