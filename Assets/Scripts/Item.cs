using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject starBlast, diamondBlast;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,200f)*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Star")
            {
                GameManager.instance.GetStar();
                Instantiate(starBlast, transform.position, Quaternion.identity);
            }
            if(gameObject.tag == "Diamond")
            {
                GameManager.instance.GetDiamond();
                Instantiate(diamondBlast, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
