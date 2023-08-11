using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;

    public Seeker seeker;

    Path path;
    Coroutine moveCoroutine;
    public bool updateContinuesPath;
    bool reachDestination = false;
    public float moveSpeed;
    public float nextWPDistance;

    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f); 
        reachDestination = true;
    }
    void CalculatePath()
    {
        Vector2 target = FindTarget();

        if (seeker.IsDone() && (reachDestination || updateContinuesPath));
            seeker.StartPath(transform.position, target,OnPathComplete);

    }
    void OnPathComplete( Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if(moveCoroutine != null)StopCoroutine(moveCoroutine); moveCoroutine = null;
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine() 
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP]-(Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if(distance<nextWPDistance)
            {
                currentWP++;

                yield return null;
            }
            reachDestination =true;
        }
    }
    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;

        if(roaming == true)
        {
            return  (Vector2)playerPos + (Random.Range(10f,50f)*new Vector2(Random.Range(-1,1),Random.Range(-1,1)).normalized);
        }
        else
        {
            return playerPos;
        }
    }
}
