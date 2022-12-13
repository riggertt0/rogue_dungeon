using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject LeftWall;
    public GameObject UpWall;
    public GameObject RightWall;
    public GameObject DownWall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("door touch wall");
            Debug.Log(name);
            Debug.Log(transform.localEulerAngles.z);
            float angle = transform.localEulerAngles.z;
            if (angle == 0) {
                Debug.Log("Spawn Left Wall");
                Instantiate(LeftWall, transform.position, Quaternion.identity);
            }
            else if (angle == 270)
            {
                Debug.Log("Spawn Top Wall");
                Instantiate(UpWall, transform.position, Quaternion.identity);
            }
            else if (angle == 180)
            {
                Debug.Log("Spawn Right Wall");
                Instantiate(RightWall, transform.position, Quaternion.identity);
            }
            else if (angle == 90)
            {
                Debug.Log("Spawn Bottom Wall");
                Instantiate(DownWall, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
