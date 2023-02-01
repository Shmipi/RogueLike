using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Transform spriteChild;

    [SerializeField] private GameController gc;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePointL;
    [SerializeField] private Transform firePointR;

    [SerializeField] private GameObject shotgunProj;
    [SerializeField] private GameObject akProj;
    [SerializeField] private GameObject pistolProj;

    [SerializeField] private GameObject meeleSlash;
    public bool isSlashing;

    [SerializeField] private Transform reloadPoint;
    [SerializeField] private GameObject reloadObj;

    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private float canFire = 0f;

    public GameObject gunSprite;

    public Sprite pistol;
    public Sprite ak;
    public Sprite shotgun;

    public int magSize;
    public int ammo;

    public string gunType;

    private Vector2 moveDirection;

    private bool movingDown;
    private bool movingUp;
    private bool movingRight;
    private bool movingLeft;

    private float moveX;
    private float moveY;


    private void Start()
    {
        isSlashing = false;
        transform.position = spawnPoint.transform.position;
        gunType = "Unarmed";
        //gc = gc.GetComponent<GameController>();
    }

    void Update()
    {

        spriteChild.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);

        if (gc.isPaused == false)
        {
            Inputs();

            if(moveDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && gunType != "AK")
            {
                FireBullet();
            }

            if(Input.GetKey(KeyCode.Space) && gunType == "AK" && Time.time > canFire)
            {
                FireAK();
                canFire = Time.time + cooldown;
            }

            if(Input.GetKeyDown(KeyCode.R) && ammo <= 0)
            {
                Reload();
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void FireBullet()
    {
        if (gunType == "Shotgun")
        {
            if(ammo > 0)
            {
                GameObject firedBullet1 = Instantiate(shotgunProj, firePoint.position, firePoint.rotation);

                GameObject firedBullet2 = Instantiate(shotgunProj, firePointL.position, firePointL.rotation);

                GameObject firedBullet3 = Instantiate(shotgunProj, firePointR.position, firePointR.rotation);

                ammo -= 1;
            }
        }
        else if (gunType == "Pistol")
        {
            if(ammo > 0)
            {
                GameObject firedBullet = Instantiate(pistolProj, firePoint.position, firePoint.rotation);

                ammo -= 1;
            }
        } else
        {
            GameObject slash = Instantiate(meeleSlash, firePoint.position, firePoint.rotation);
        }
    }

    private void FireAK()
    {if (ammo > 0)
        {
            GameObject firedBullet = Instantiate(akProj, firePoint.position, firePoint.rotation);

            ammo -= 1;
        }
     }

    private void Reload()
    {
        GameObject reload = Instantiate(reloadObj, reloadPoint.position, reloadPoint.rotation);
        if(gunType == "Pistol")
        {
            reload.GetComponent<Animator>().SetInteger("gunId", 1);
        } else if(gunType == "AK") {
            reload.GetComponent<Animator>().SetInteger("gunId", 2);
        } else if(gunType == "Shotgun") {
            reload.GetComponent<Animator>().SetInteger("gunId", 3);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.tag == "TurretProjectile")
    //    {
    //        gc.TakeDamage();
    //    }

    //    if (gc.orangeWall != null && gc.blueWall != null)
    //    {
    //        if (collision.gameObject == gc.orangeWall.gameObject)
    //        {
    //            //move to blue
    //            gameObject.transform.position = gc.blueWall.transform.GetChild(0).position;
    //            isTeleported = true;
    //        }

    //        if (collision.gameObject == gc.blueWall.gameObject)
    //        {
    //            //move to orange
    //            gameObject.transform.position = gc.orangeWall.transform.GetChild(0).position;
    //            isTeleported = true;
    //        }
    //    }
    //}
}
