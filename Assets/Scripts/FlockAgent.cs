using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public enum Etat { controlledByPlayer, freeRoam, targetObjective };

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    public Sprite roamSprite;

    public Sprite objectiveSprite;

    public Sprite playerSprite;

    public Etat etat { get; set; }

    public Vector2 objective;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
        setFreeRoam();
        objective = Vector2.zero;
    }

    public void setFreeRoam()
    {
        etat = Etat.freeRoam;
        setSprite();
    }

    public void setControlledByPlayer()
    {
        etat = Etat.controlledByPlayer;
        setSprite();
    }

    public void setTargetObjective(Vector2 pos)
    {
        objective = pos;
        etat = Etat.targetObjective;
        setSprite();
    }

    public void setSprite()
    {
        if(etat == Etat.controlledByPlayer)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
        else if (etat == Etat.freeRoam)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = roamSprite;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = objectiveSprite;
        }

    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;            
    }
}
