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
            float angle = transform.localEulerAngles.z;
            if (angle == 0) {
                Instantiate(LeftWall, transform.position, Quaternion.identity);
            }
            else if (angle == 270)
            {
                Instantiate(UpWall, transform.position, Quaternion.identity);
            }
            else if (angle == 180)
            {
                Instantiate(RightWall, transform.position, Quaternion.identity);
            }
            else if (angle == 90)
            {
                Instantiate(DownWall, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
