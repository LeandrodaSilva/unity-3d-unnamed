using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject pc;
    public GameObject[] wp = new GameObject[4];
    private int Index = 0;
    public float maxDist = 2;
    private bool Persecution = false;
    public float maxDistTarget = 20;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Next();
    }

    private void Next()
    {
        agent.SetDestination(wp[Index++].transform.position);

        if (Index >= wp.Length)
            Index = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Persecution || Vector3.Distance(transform.position, pc.transform.position) <= maxDistTarget)
        {
            Persecution = true;
            agent.SetDestination(pc.transform.position);
        } else if (Vector3.Distance(transform.position, agent.destination) < maxDist)
        {
            Next();
        }
    }
}
