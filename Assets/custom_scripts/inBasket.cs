using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inBasket : MonoBehaviour
{   
    public GameObject collidingFruit;

    void Start() {
        Debug.Log($"name object {gameObject.name}--------------------");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision! ---");
        if (collision.gameObject.name == collidingFruit.name)
        {
            Score();
            Destroy(collidingFruit);
        }
    }

    private void Score(){
        Debug.Log("score");
    }
}
