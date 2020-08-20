using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Node : MonoBehaviour
{
    public TextMeshPro Name;
    public string id;
    public string displayName; 
    public string type;

    public Material[] material;
    //public string SUID;
    //public string shared_name;
    //public string primaryDataset;

    //public string domainID;

    //public string uid;
    //public string refSeqId;
    //public string unitprotEntryName; 

    public List<Node> Neighbours;
    public List<Edge> Connections;

    public bool isVisited = false;

    //public bool isActive = true;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Name.text = displayName;
        rend = GetComponent<Renderer>();

        rend.enabled = true;
        Vector3 random_position = Random.onUnitSphere * 5;
        //GetComponent<Renderer>().material.color = Color.red;
        switch (type)
        {
            case "RProtein": case "Protein":

                //Vector3 pos = new Vector3(Random.Range(1, 40), 1, Random.Range(1, 40));
                //transform.position = pos;
                //  GetComponent<Renderer>().material.color = Color.red;
                rend.sharedMaterial = material[0];
                break;
            case "RPathway":  case "Pathway":
                //Vector3 pos1 = new Vector3(Random.Range(1, 40), 10, Random.Range(1, 40));
                //transform.position = pos1;
                rend.sharedMaterial = material[1];
                //GetComponent<Renderer>().material.color = Color.green;
                break;
            case "RGene":     case "Gene":
                //Vector3 pos2 = new Vector3(Random.Range(1, 40), 20, Random.Range(1, 40));
                //transform.position = pos2;
                rend.sharedMaterial = material[2];
                // GetComponent<Renderer>().material.color = Color.blue;
                break;
            case "Disorder":
                rend.sharedMaterial = material[3];
                break;
        }
        //Instantiate(Node);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //if (isActive)
        //{
        //    rend.enabled = true;
        //}
        //else if (!isActive)
        //{
        //    rend.enabled = false;
        //}
        //GetComponent<Renderer>().material.color = new Color(transform.position.normalized.x, transform.position.normalized.y, transform.position.normalized.z, 1);

    }

    private void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = Color.red;

        foreach (Edge edge in Connections)
        {

            edge.edge.material.color = Color.red;
            edge.edge.SetWidth(0.3f, 0.3f);
            //edge.edge.SetPosition(0, transform.position);
            //edge.edge.SetPosition(1, edge.target.transform.position);

            edge.isActive = true;
        }
    }
    private void OnMouseExit()
    {
       // GetComponent<Renderer>().material.color = new Color(transform.position.normalized.x, transform.position.normalized.y, transform.position.normalized.z, 1);
        foreach (Edge edge in Connections)
        {

            edge.edge.material.color = Color.gray;
            edge.edge.SetWidth(0.02f, 0.02f);
            edge.isActive = false;
        }
    }
}
