using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTNChangeM : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public GameObject 量體;
    // Start is called before the first frame update
    void Start()
    {
        rend = 量體.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        InvokeRepeating("btnChangeBack", 1f, 1000f);
    }
    public void btnChange()
    {
        rend.sharedMaterial = material[1];
        //InvokeRepeating("btnChangeBack", 1f, 1000f);
    }

    public void btnChangeBack()
    {
        rend.sharedMaterial = material[0];
    }
}
