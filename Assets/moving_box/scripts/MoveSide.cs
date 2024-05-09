using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveSide : MonoBehaviour
{   
    public float speed_m_s; // In units per second
    public float x_min, x_max, y, z;
    private Vector3 target_pos;
    

    
    void Start()
    {
        target_pos = makeNewTarget();
    }

   
    void Update()
    {
        if (target_pos != gameObject.transform.position)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target_pos, speed_m_s *  Time.deltaTime);
                    
            }
        else 
            {
                target_pos = makeNewTarget();
            }
    }

    private float newX()
    {
        float new_x = UnityEngine.Random.Range(x_min, x_max);
        return new_x;
    }

    private Vector3 makeNewTarget()
    {
        Vector3 target = new Vector3(newX(), y, z);
        return target;
    }


}
