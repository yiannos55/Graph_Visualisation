using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphLayout : MonoBehaviour
{

    public Node nodePrefab;
    public Edge edgePrefab;
    
    public Node root;


    // Start is called before the first frame update
    void Start()
    {
        importGraph();

    }

    private void importGraph()
    {
        //read GraphML document and parse it
        //store nodes in hashtable
        //store edges 

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
