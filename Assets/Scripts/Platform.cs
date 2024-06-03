using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformBlast;
    public GameObject diamond, star;
    // Start is called before the first frame update
    void Start()
    {
        int randNumber = Random.Range(1,21);
        Vector3 tempPos = transform.position;
        tempPos.y += 1.2f;
        if(randNumber<4)
        {
            Instantiate(star, tempPos, star.transform.rotation);
        }

        if(randNumber == 7)
        {
            Instantiate(diamond, tempPos, diamond.transform.rotation);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("FallDown", 0.2f);
        }
    }

    void FallDown()
    {
        Instantiate(platformBlast, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject,0.5f);
    }
}
