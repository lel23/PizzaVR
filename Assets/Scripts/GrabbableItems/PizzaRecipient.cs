using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaRecipient : MonoBehaviour
{
    public Material startMaterial;
    public Material endMaterial;

    private MeshRenderer myMatRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myMatRenderer = GetComponent<MeshRenderer>();
        myMatRenderer.material = startMaterial;
    }

    public void changeColor()
    {
        Debug.Log("changed color");
        myMatRenderer.material = endMaterial;
    }
    

}
