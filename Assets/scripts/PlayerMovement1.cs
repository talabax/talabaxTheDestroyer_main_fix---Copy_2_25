using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    SpriteRenderer mySprite;
    Rigidbody2D RB;
    float moveSpeed = 3.5f;
    [SerializeField] Animator animator;
    bool canAttack = true;
    int attackChildColl = 2;
    float attackTime = .3f;
    float lastX;
    float lastY;
    bool isAttacking = false;

    const string moveLeft = "walk_left";
    const string moveRight = "walk_right";
    const string moveUp = "walk_up";
    const string moveDown = "walk_down";
    const string idleUp = "idle_up";
    const string idleLeft = "idle_left";
    const string idleRight = "idle_right";
    const string idleDown = "idle_down";
    

    void Start()
    {
        
        lastX = 1;
        lastY = 0;
        RB = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //Debug.Log("lastX: " + lastX);
        //Debug.Log("lastY: " + lastY);
        //Debug.Log("isAttacking " + isAttacking);
        if (isAttacking == false)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {

                HandleAttack(lastX, lastY);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {        ////movement handled here
        if (RB.velocity.x == 0 && RB.velocity.y == 0 && isAttacking == false)
        {
            SetIdleState(lastX, lastY);
        }
        else
        {   
            //Debug.Log("its moving");
        }

        if (isAttacking == false)
        { 
            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                return;
            }
            else 
            {
                SetLastPos();
                MoveMent(lastX, lastY);
            }
        }
        else if (isAttacking == true)
        {

            RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * 0;
           
        }

       
        
    }





    void HandleAttack(float x , float y)
    {
        if (x == 0 && y == 0)
        {
            return;

        }
        if (x == 1 && y == 1)
        {
            isAttacking = true;
            attackChildColl = 1;
            animator.Play("attack_right");
            StartCoroutine(AttackCollider(attackChildColl));

        }
        if (x == 1 && y == -1)
        {
            isAttacking = true;
            attackChildColl = 1;
            animator.Play("attack_right");
            StartCoroutine(AttackCollider(attackChildColl));

        }

        if (x == -1 && y == 1)
        {
            isAttacking = true;
            attackChildColl = 3;
            animator.Play("attack_left");
            StartCoroutine(AttackCollider(attackChildColl));
        }
        if (x == -1 && y == -1)
        {
            isAttacking = true;
            attackChildColl = 3;
            animator.Play("attack_left");
            StartCoroutine(AttackCollider(attackChildColl));
        }

        if (x == 0 && y == -1)
        {
            isAttacking = true;
            attackChildColl = 2;
            animator.Play("attack_down");
            StartCoroutine(AttackCollider(attackChildColl));
            
        }
        if (x == 0 && y == 1)
        {
            isAttacking = true;
            attackChildColl = 0;
            animator.Play("attack_up");
            StartCoroutine(AttackCollider(attackChildColl));
            

        }
        if (x == 1 && y == 0)
        {
            isAttacking = true;
            attackChildColl = 1;
            animator.Play("attack_right");
            StartCoroutine(AttackCollider(attackChildColl));
            

        }
        if (x == -1 && y == 0)
        {
            isAttacking = true;
            attackChildColl = 3;
            animator.Play("attack_left");
            StartCoroutine(AttackCollider(attackChildColl));
            


        }

    }


    IEnumerator AttackCollider(int num)
    {
        
        transform.GetChild(num).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
         transform.GetChild(num).gameObject.SetActive(false);

        
        isAttacking = false;
      


        // transform.GetChild(num).gameObject.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // transform.GetChild(num).gameObject.SetActive(false);

        // Debug.Log(canAttack + "1" + " initial can attack");
        //isAttacking = false;
        //Debug.Log(canAttack + "2" + " last can attack");
    }

    void SetLastPos()
    {
        lastX = Input.GetAxisRaw("Horizontal");
        lastY = Input.GetAxisRaw("Vertical");
    }

    void MoveMent(float x , float y)
    {
        if ((x == 1 && y == 0) || (x == 1 && y == 1) || (x == 1 && y == -1))
        {
            animator.Play(moveRight);

        }
        if ((x == -1 && y == 0) || (x == -1 && y == 1) || (x == -1 && y == -1))
        {
            animator.Play(moveLeft);

        }
        if (x == 0 && y == 1)
        {
            animator.Play(moveUp);

        }
        if (x == 0 && y == -1)
        {
            animator.Play(moveDown);

        }

    }
   
    void SetIdleState(float x, float y)
    {
        if ((x == 1 && y == 0) || (x == 1 && y == 1) || (x == 1 && y == -1))
        {
            animator.Play(idleRight);

        }
        if ((x == -1 && y == 0) || (x == -1 && y == 1) || (x == -1 && y == -1))
        {
            animator.Play(idleLeft);

        }
        if (x == 0 && y == 1)
        {
            animator.Play(idleUp);

        }
        if (x == 0 && y == -1)
        {
            animator.Play(idleDown);

        }

    }

}
