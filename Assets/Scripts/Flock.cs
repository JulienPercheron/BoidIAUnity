using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behaviorFreeRoam;
    public FlockBehavior behaviorTargetObjective;

    public GameObject scoreCanvas;
    public GameObject scoreGO;
    private int score = 0;

    public GameObject endCanvas;
    public GameObject endScoreGO;

    [Range(1, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }


    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward*Random.Range(0f,360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }

        scoreGO.GetComponent<Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            setControlledByPlayer();

        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move;
            
            switch (agent.etat)
            {
                case FlockAgent.Etat.freeRoam:
                    Debug.Log("freeRoam");
                    move = behaviorFreeRoam.CalculateMove(agent, context, this);
                    move *= driveFactor;
                    if (move.sqrMagnitude > squareMaxSpeed)
                    {
                        move = move.normalized * maxSpeed;
                    }
                    agent.Move(move);
                    break;

                case FlockAgent.Etat.targetObjective:
                    Debug.Log("Objective");
                    move = behaviorTargetObjective.CalculateMove(agent, context, this);
                    move *= driveFactor;
                    if (move.sqrMagnitude > squareMaxSpeed)
                    {
                        move = move.normalized * maxSpeed;
                    }
                    agent.Move(move);
                    break;
                case FlockAgent.Etat.controlledByPlayer:
                    float horizontalInput = Input.GetAxis("Horizontal");
                    float verticalInput = Input.GetAxis("Vertical");
                    move = new Vector2(horizontalInput, verticalInput);
                    move = move * driveFactor;
                    agent.Move(move);
                    break;
            }
        }
    }

    public void setTargetObjective(Vector2 pos)
    {
        for (int i = 0; i < agents.Count; i++)
        {
            if(agents[i].etat != FlockAgent.Etat.controlledByPlayer)
            {
                agents[i].setTargetObjective(pos);
            }
        }
    }

    public void setFreeRoam()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            if (agents[i].etat != FlockAgent.Etat.controlledByPlayer)
            {
                agents[i].setFreeRoam();
            }
        }

        score++;
        if (score >= 5)
            endTheGame();
        scoreGO.GetComponent<Text>().text = score.ToString();
    }

    void setControlledByPlayer()
    {
        if(agents[0].etat == FlockAgent.Etat.controlledByPlayer)
        {
            agents[0].etat = agents[1].etat;
            agents[0].setSprite();
        }
        else
        {
            agents[0].setControlledByPlayer();
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach(Collider2D c in contextColliders)
        {
            if (c != agent.AgentCollider) 
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    void endTheGame()
    {
        agents.Clear();
        scoreCanvas.SetActive(false);
        endCanvas.SetActive(true);
        endScoreGO.GetComponent<Text>().text = Time.realtimeSinceStartup + "s";
    }
}
