using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    const int FORCE_BASED = 1;
    const int RANDOM_CIRCULAR = 2;
    private int MODE;
    private int LAST_MODE;

    public Graph Graph;
    public ForceBasedGraph Force_Based_Graph;
    //public GraphReader Reader;

    // Start is called before the first frame update
    void Start()
    {
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
            default:
                break;
        }

    }

    public void SetMode(int newMode)
    {
        MODE = newMode;
    }
}
