using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    int moedas;
    public float velocidade;
    public float impulso;

    public static bool finishLevel = false;

    public Transform chaoVerificador;
    bool estaoNoChao;

    SpriteRenderer spriteRender;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        moedas = 0;
        // Interface para os componentes
        spriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Mover
        float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0.0f, 0.0f);

        // Verificar colisao com o piso
        estaoNoChao = Physics2D.Linecast(transform.position,
            chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));

        // Pulo
        if (Input.GetButtonDown("Jump") && estaoNoChao)
        {
            rb.velocity = new Vector2(0.0f, impulso);
        }

        // Orientacao
        if (mover_x > 0)
        {
            spriteRender.flipX = false;
        }
        else if (mover_x < 0)
        {
            spriteRender.flipX = true;
        }

        animator.SetFloat("pMover", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetBool("pJump", !estaoNoChao);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9) {
            print("pegou a moeda");
            moedas += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 10)
        {
            SceneManager.LoadScene("Menu");
        }

        if (collision.gameObject.layer == 11 && moedas == 3)
        {
            
            SceneManager.LoadScene("Menu"); 
        }
    }

}
