using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public float shootRate = 2;
    public float attack = 30;
    private float timer = 0;
    private ParticleSystem particleSystem;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.renderer as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
        timer+=Time.deltaTime;
        if (timer > 1 / shootRate) {
            timer -= 1 / shootRate;
            Shoot();
        }
	}
    void Shoot() {
        light.enabled = true;
        particleSystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            lineRenderer.SetPosition(1, hitInfo.point);
            //判断当前的射击有没有碰撞到敌人
            if (hitInfo.collider.tag == Tags.enemy) {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);
            }

        } else {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        audio.Play();

        Invoke("ClearEffect", 0.05f);
    }

    void ClearEffect() {
        light.enabled = false;
        lineRenderer.enabled = false;
    }
}
