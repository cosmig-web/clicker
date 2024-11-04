using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : MonoBehaviour
{

    public float speed = 70;

    public bool randomRotaion = true;
    public Vector3 rotatrion;

    // Start is called before the first frame update
    void Start()
    {
        if (randomRotaion)
        {
            rotatrion = new Vector3();

            rotatrion.y = Random.Range(-1f, 1f);
            rotatrion.x = Random.Range(-1f, 1f);
            rotatrion.z = Random.Range(-1f, 1f);
        }
        
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotatrion* speed* Time.deltaTime);
    }
}
