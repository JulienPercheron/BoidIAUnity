using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public GameObject flockGO;
    private Flock flock;

    private void Start()
    {
        flock = flockGO.GetComponent<Flock>();
        StartCoroutine(reappear());
    }

    private void randomPos()
    {
        this.gameObject.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        flock.setTargetObjective(this.gameObject.transform.position);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        this.gameObject.transform.position = new Vector3(100,100,0);
        flock.setFreeRoam();
        StartCoroutine(reappear());
    }
    
    IEnumerator reappear()
    {
        yield return new WaitForSeconds(5);
        
        randomPos();
    }
}
