using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;

    void Awake() {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }
    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, player.position) < 1.5f) {
            agent.Stop();
            anim.SetBool("Move", false);
        } else {
            agent.SetDestination(player.position);
            anim.SetBool("Move", true);
        }
	}
}
