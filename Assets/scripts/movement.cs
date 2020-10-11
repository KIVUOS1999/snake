using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 0.3f;
    public float spread = 0.1f;
    bool food_taken = false;
    public GameObject tailgo;
    Vector2 dir;
    List<Transform> tail = new List<Transform>();
    public GameObject food;

    void Start()
    {
        InvokeRepeating("move",0.01f,speed);
        FindObjectOfType<foodspan>().producefood();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
            dir = new Vector2(1*spread, 0);
        else if (Input.GetAxis("Horizontal") < 0)
            dir = new Vector2(-1*spread, 0);
        else if (Input.GetAxis("Vertical") > 0)
            dir = new Vector2(0, 1*spread);
        else if (Input.GetAxis("Vertical") < 0)
            dir = new Vector2(0, -1*spread);
    }

    void move()
    {
        Vector2 buff = transform.position;
        transform.Translate(dir);

        if(tail.Count > 0)
        {
            tail[tail.Count - 1].position = buff;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }

        if(food_taken)
        {
            
            GameObject tailo = (GameObject)Instantiate(tailgo, buff, Quaternion.identity);
            tail.Insert(0, tailo.transform);
            food_taken = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "food")
        {
            food_taken = true;
            Destroy(collision.gameObject);
            FindObjectOfType<foodspan>().producefood();
        }    
        
        else if(collision.collider.tag == "wall")
        {
            died();
        }

        /*else if(collision.collider.tag == "body" && collision.transform != tail[0])
        {
            died();
        }*/

        
    }

    void died()
    {
        GameObject b = gameObject;
        Destroy(b);
        for (int i = 0; i < tail.Count; i++)
        {
            Destroy(tail[i].gameObject);
        }
    }
}
