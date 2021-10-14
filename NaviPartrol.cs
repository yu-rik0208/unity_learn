using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviPartrol : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject[] targets;
    private int point=0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[0].transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.5f)
        {
            //目的地の切り替え
            Setposition(ref point,targets);
            
            

        }

     

        //止めるか止めないか
        agentSwitch(ref agent);

        agent.SetDestination(targets[point].transform.position);
    }



//地点の切り替え
void Setposition(ref int point,GameObject[] targets)
{

    if(point==(targets.Length-1))
    //if (point==0)
    {
         point=0;
    }
    else
    {
        point++;
    }

}

void agentSwitch(ref NavMeshAgent agent)
{
    if(Input.GetKey(KeyCode.A))
    {
        //agentを止めるかどうか(trueでとまる)
        agent.isStopped = !agent.isStopped;
        if(agent.isStopped==true)
        {
            Debug.Log("agent stop");
        }
        else
        {
            Debug.Log("agent start");
        }
    }
}


}
