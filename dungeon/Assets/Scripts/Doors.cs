using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject LeftWall;
    public GameObject UpWall;
    public GameObject RightWall;
    public GameObject DownWall;

    private void OnStayEnter2D(Collider2D other)
    {
        Debug.Log("sdfdsf");
        if (other.gameObject.tag == "Wall")
        {
            if (transform.rotation.z == 0) {
                Instantiate(LeftWall, transform.position, Quaternion.identity);
            }
            else if (transform.rotation.z == 270)
            {
                Instantiate(UpWall, transform.position, Quaternion.identity);
            }
            else if (transform.rotation.z == 180)
            {
                Instantiate(RightWall, transform.position, Quaternion.identity);
            }
            else if (transform.rotation.z == 90)
            {
                Instantiate(DownWall, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
