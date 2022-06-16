using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightON : MonoBehaviour
{
    public GameObject lanternlight;
    // Start is called before the first frame update
    void Start()
    {
        lanternlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "lantern")
        {
            lanternlight.SetActive(true);
        }
    }
}
