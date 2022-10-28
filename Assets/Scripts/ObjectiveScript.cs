using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    private void Start()
    {
        randomPos();
    }

    private void randomPos()
    {
        this.gameObject.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        randomPos();
    }

}
