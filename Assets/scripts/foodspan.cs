using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodspan : MonoBehaviour
{
    public Transform l_wall, r_wall, t_wall, b_wall;
    float l_wall_position, r_wall_position, t_wall_position, b_wall_position;
    public GameObject food;
    void Start()
    {
        float offset = 0.5f;
        l_wall_position = l_wall.position.x + offset;
        r_wall_position = r_wall.position.x - offset;
        t_wall_position = t_wall.position.y - offset;
        b_wall_position = b_wall.position.y + offset;
    }

    public void producefood()
    {
            Vector2 pos = new Vector2(Random.Range(l_wall_position, r_wall_position), Random.Range(t_wall_position, b_wall_position));
            Debug.Log(pos);
            GameObject instance = (GameObject)Instantiate(food, pos, Quaternion.identity);
    }
}
