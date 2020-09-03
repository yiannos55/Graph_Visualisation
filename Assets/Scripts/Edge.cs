using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public string sourceID;
    public string targetID;
    public Node source;
    public Node target;
    public LineRenderer edge;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            edge.enabled = false;
        }
        if (isActive)
        {
            edge.enabled = true;
            if (source && target)
            {          
                setStart();
                setEnd();
            }
        }
    }

    private void setStart()
    {
        edge.SetPosition(0, source.GetPosition());
    }
    private void setEnd()
    {
        edge.SetPosition(1, target.GetPosition());
    }
}
