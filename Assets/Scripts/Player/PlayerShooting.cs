using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


  


    void Awake ()
    {
        shootableMask = LayerMask.GetMask("Shootable");

        gunParticles = GetComponent<ParticleSystem>();
        gunAudio = GetComponent<AudioSource>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if(timer >= timeBetweenBullets* effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects ()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }


    void Shoot ()
    {
        timer = 0;
        gunAudio.Play();

        gunLine.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);


        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;


        if(Physics.Raycast(shootRay, out shootHit , range , shootableMask) )
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if(enemyHealth!=null )
            {
                enemyHealth.TakeDamage(damagePerShot,shootHit.point);
            }
        }

        if (Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
