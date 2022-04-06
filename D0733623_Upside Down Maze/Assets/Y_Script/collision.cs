using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    Renderer rend;
    Rigidbody rigi;
    public float speed = 2f;
    int collisions = 0;
    int colorPicker = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 90, 0);

        GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);

        leftWall.transform.position = new Vector3(-5, 0, 0);
        rightWall.transform.position = new Vector3(5, 0, 0);

        leftWall.transform.localScale = new Vector3(1, 1, 2);
        rightWall.transform.localScale = new Vector3(1, 1, 2);

        leftWall.AddComponent<Rigidbody>();
        rightWall.AddComponent<Rigidbody>();

        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        print(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        speed = speed * -1;
        collisions++;
        print("collisions" + collisions);
        colorPicker = Random.Range(0, 5);

    }

    private void OnTriggerExit(Collider other)
    {
        switch (colorPicker)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.blue; break;
            case 2: rend.material.color = Color.green; break;
            case 3: rend.material.color = Color.red; break;
            case 4: rend.material.color = Color.gray; break;
            case 5: rend.material.color = Color.yellow; break;
        }

    }
}
