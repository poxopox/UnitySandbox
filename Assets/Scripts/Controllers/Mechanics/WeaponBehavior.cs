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
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("Fire") || animation.GetCurrentAnimatorStateInfo(0).IsName("AimFire")) { } else
        {
            
            var init = projectile;
            var position = weapon.transform.position + (weapon.transform.forward * offsetx) + (weapon.transform.right * offsety) + (weapon.transform.up * offsetz);
            var clone = Instantiate(init, position, weapon.transform.rotation) as Rigidbody;
            clone.AddForce(clone.transform.right * force);
            if (animation.GetCurrentAnimatorStateInfo(0).IsName("Aim"))
            {
                animation.Play("AimFire");
            }
            else {
                animation.Play("Fire");
            }
        }

    }

    void Aim() {
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("Aim")){}
        else {animation.Play("Aim");}
    }
    void UnAim() {
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("idle")) { }
        else { animation.Play("idle"); }
    }

    void AimFire() {
        LaunchProjectile();
        if (animation.GetCurrentAnimatorStateInfo(0).IsName("AimFire")) { }
        else { animation.Play("AimFire"); }

    }
    public void Fire() {
        LaunchProjectile();
    }

    void LateUpdate() {

        if (Input.GetButtonDown("Fire1")) {
            if (Input.GetButtonDown("Fire2")) {
                AimFire();
            }
            else {
                Fire();
            };

        }
        if (Input.GetButtonDown("Fire2"))
        {
            Aim();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            UnAim();
        }
    }
}
