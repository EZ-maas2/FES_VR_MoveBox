using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class make_fruit : MonoBehaviour
{
   // public Vector3 pos;
    public GameObject fruit1;
    public GameObject fruit2;
    public GameObject fruit3;
    public int amount_of_fruits;
    public int max_fruits = 10;
    private int fruitcount = 0;
    private float time_passed = 0;


    public void make_new_fruit()
    {
        int type = Random.Range(0, 3);
        float size_x = 0.15F; //transform.scale.x;
        float size_z = 0.15F; //transform.scale.z;
        float pos_x = transform.position.x;
        float pos_z = transform.position.z;
        float pos_y = transform.position.y;
        Vector3 pos =  new Vector3(Random.Range(pos_x - size_x, pos_x + size_x), pos_y + 0.01F, Random.Range(pos_z - size_z, pos_z + size_z));

        if (type == 0)
        {
            Instantiate(fruit1, pos, transform.rotation);
            Debug.Log($"0, position is {pos}");
        }
        else if (type == 1)
        {
            Instantiate(fruit2, pos, transform.rotation);
            Debug.Log($"1, position is {pos}");
        }
        else if (type == 2)
        {
            Instantiate(fruit3, pos, transform.rotation);
            Debug.Log($"2, position is {pos}");

        }
        fruitcount +=1;
    }

    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0; i < amount_of_fruits; i++)
        {
            make_new_fruit();
            fruitcount += 1;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (time_passed > 1) 
        {
            if (fruitcount < max_fruits)
                {
                make_new_fruit();
                }
            time_passed = 0;
        }
        time_passed += Time.deltaTime;

    
}
}