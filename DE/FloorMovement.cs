using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotSpeed;
    void Start()
    {
         rotSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3( 0,rotSpeed*Time.deltaTime,0)); //회전값,
    }
}
