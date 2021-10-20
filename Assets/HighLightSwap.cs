using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightSwap : MonoBehaviour
{
    public Shader standard;
    public Shader Highlight;
    public Material tableMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swapToStandard()
    {
        tableMat.shader = standard;
    }

    public void swapToHighLight()
    {
        tableMat.shader = Highlight;
    }
}
