using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 1;
    private Animator anim;
    private int groundLayerIndex = -1;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void Update () {
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(h, 0, v) * speed*Time.deltaTime);
        rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex)) {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

       
        if (h != 0 || v != 0) {
            anim.SetBool("Move", true);
        } else {
            anim.SetBool("Move", false);
        }
	}
}
