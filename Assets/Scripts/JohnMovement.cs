using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float JumpForce;
    public float Speed;
    private bool Grounded;
    private Animator Animator;
    public GameObject BulletPrefab;
    public int Health = 6;
    public Image barraDeVida;
    public int vidaMaxima = 6;
    public GameObject Reset;
   
    


    void Start()

    {
        Health = vidaMaxima;
       
        Reset.gameObject.SetActive(false);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        barraDeVida.fillAmount = (float)Health / (float)vidaMaxima;

        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Jumping",  Grounded == false);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            Jump();
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
   
    public void Hit()
    {
        Health -= 1;
        if (Health == 0)
        {
            Animator.SetBool("dying", Health == 0);
        }
    }

    public void die()
    {
        Destroy(gameObject);
        Reset.gameObject.SetActive(true);
       
    }

    public void ChangeHealth(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, vidaMaxima);

    }
}



