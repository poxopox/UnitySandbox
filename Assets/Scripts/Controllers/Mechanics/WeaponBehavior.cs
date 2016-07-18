using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour {
    public Rigidbody projectile;
    public GameObject weapon;
    public float offsetx, offsety, offsetz;
    public float force;
    public Animator animation;


    void Start() {
        animation = GetComponent<Animator>();
    }


    void LaunchProjectile()
    {
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("Fire")) {}else
        {
            var init = projectile;
            var position = weapon.transform.position + (weapon.transform.forward * offsetx) + (weapon.transform.right * offsety) + (weapon.transform.up * offsetz);

            var clone = Instantiate(init, position, weapon.transform.rotation) as Rigidbody;
            clone.AddForce(clone.transform.right * force);
            animation.Play("Fire");
        }
        
    }




    public void Fire() {
       // PlayAnimation();
        LaunchProjectile();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
}
