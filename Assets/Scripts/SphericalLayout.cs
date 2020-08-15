using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphericalLayout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<5000; ++i)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = Random.onUnitSphere*10;
           // Color color = new Color(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);
           // var renderer = sphere.GetComponent<MeshRenderer>();
            sphere.GetComponent<Renderer>().material.color= new Color(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z,1);
            
        }
    }

 public void create()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
