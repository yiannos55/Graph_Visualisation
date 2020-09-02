using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSystem : MonoBehaviour
{
    const int FORCE_BASED = 1;
    const int RANDOM_CIRCULAR = 2;
    const int SORT_AND_DRAW = 3;
    const int BINARY_DISTANCE = 4;
    const int COMPARE = 5;

    private int MODE;
    private int LAST_MODE;

    //public InputField nodeA_input;
    //public InputField nodeB_input;

    public Graph Graph;
    public ForceBasedGraph Force_Based_Graph;
    public NodeComparer nodeComparer;

    public string a;
    public string b;


    public BinaryDistance binaryDistance;
    //public GraphReader Reader;

    // Start is called before the first frame update
    void Start()
    {
        a = "EMPTY";
        b = "EMPTY";
        // Reader = new GraphReader();
        MODE = 0;
        LAST_MODE = 0;
    }

    // Update is called once per frame
    void Update()
    {

        switch (MODE)
        {
            case FORCE_BASED:
                LAST_MODE = FORCE_BASED;
                Graph.UpdatePositions_FBG();
                break;
            case RANDOM_CIRCULAR:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = RANDOM_CIRCULAR;
                    Graph.Draw_Circular();
                }
                break;
            case SORT_AND_DRAW:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = SORT_AND_DRAW;
                    Graph.SortAndDraw();
                }
                break;
            case BINARY_DISTANCE:
                if (MODE != LAST_MODE)
                {
                    LAST_MODE = BINARY_DISTANCE;
                    Graph.FindDistances();
                }
                break;
            case COMPARE:
                if (MODE!=LAST_MODE)   
                {
                    LAST_MODE = COMPARE;
                    Node tempNodeA = Graph.Nodes.Find(node => node.displayName.Contains(a));
                    Node tempNodeB = Graph.Nodes.Find(node => node.displayName.Contains(b));
                    if (tempNodeA == null || tempNodeB == null)
                    {
                        Debug.Log("Node not found");
                        break;
                    }
                    nodeComparer.CompareNodes(tempNodeA, tempNodeB);

                    //nodeComparer.CompareNodes();
                }
                break;
            default:
                break;
        }

    }
    void OnGUI()
    {
        if (GUILayout.Button("Press Me"))
            Debug.Log("Hello!");
    }
    public void SetMode(int newMode)
    {
        MODE = newMode;
    }
    public void setStringA(string nodeA)
    {
        a = nodeA;
    }

    public void setStringB(string nodeB)
    {
        b = nodeB;
    }
}
