using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    PlayerMovement1 player;
    Vector3 enemyPos, playerPos;
    Vector3 distanceVec;
    float distance;
    Rigidbody2D rb;
    float facingX;
    [SerializeField] Animator animator;
    SpriteRenderer sprite;
    //walk animations below
    const string raptorWalkUp = "raptor_walk_up";
    const string raptorWalkDown = "raptor_walk_down";
    const string raptorWalkLeft = "raptor_walk_left";
    const string raptorWalkRight = "raptor_walk_right";
    //idle animations below
    const string raptorIdleUp = "raptor_idle_up";
    const string raptorIdleDown = "raptor_idle_down";
    const string raptorIdleLeft = "raptor_idle_left";
    const string raptorIdleRight = "raptor_idle_right";
    
    //attack animations below
    const string raptorAttackUp = "raptor_attack_up";
    const string raptorAttackDown = "raptor_attack_down";
    const string raptorAttackLeft = "raptor_attack_left";
    const string raptorAttackRight = "raptor_attack_right";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement1>();
        enemyPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Facing();
        //VerticalFacing();
        Angle();
    }

    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        distanceVec = playerPos - transform.position;
        distance = distanceVec.magnitude;



        //Debug.Log("The distance is " + distance + " the angle is " + Angle()); ;

        if (distance > 4f)
        {
            //idle behavior is here
            
            if (Angle() < 45 && Angle() > -45 && (playerPos.x > transform.position.x))
            {
                animator.Play(raptorIdleRight);
                StopCharacter(distanceVec);
            }

            if ( Angle() < 45 &&  Angle() > -45 && (playerPos.x < transform.position.x))
            { 
                animator.Play(raptorIdleLeft);
                StopCharacter(distanceVec);
            }
            
            
            if (Angle() < -45 && Angle() > -90)
            {
                animator.Play(raptorIdleDown);
                StopCharacter(distanceVec);
            }
            if (Angle() > 45 && Angle() < 90)
            {
                animator.Play(raptorIdleUp);
                StopCharacter(distanceVec);
            }
        }
        if (distance < 4f && distance >= 1.6f)
        {
            //walking behavior is here
            //main code animator.Play(raptorWalkLeft);
            //maine code moveCharacter(distanceVec);

            if (Angle() < 45 && Angle() > -45 && (playerPos.x > transform.position.x))
            {
                animator.Play(raptorWalkRight);
                moveCharacter(distanceVec);
            }

            if (Angle() < 45 && Angle() > -45 && (playerPos.x < transform.position.x))
            {
                animator.Play(raptorWalkLeft);
                moveCharacter(distanceVec);
            }

             if (Angle() > 45 && Angle() < 90)
            {
                animator.Play(raptorWalkUp);
                moveCharacter(distanceVec);
            }
            if (Angle() < -45 && Angle() > -90)
            {
                
                animator.Play(raptorWalkDown);
                moveCharacter(distanceVec);
            }


        }
        else if  (distance < 1.6f)
        {
            //attacking behavior is here
            //animator.Play(raptorAttackLeft);
            //StopCharacter(distanceVec);
            if (Angle() < 45 && Angle() > -45 && (playerPos.x > transform.position.x))
            {
                animator.Play(raptorAttackRight);
                StopCharacter(distanceVec);
            }

            if (Angle() < 45 && Angle() > -45 && (playerPos.x < transform.position.x))
            {
                animator.Play(raptorAttackLeft);
                StopCharacter(distanceVec);
            }


            if (Angle() < -45 && Angle() > -90)
            {
                animator.Play(raptorAttackDown);
                StopCharacter(distanceVec);
            }
            if (Angle() > 45 && Angle() < 90)
            {
                animator.Play(raptorAttackUp);
                StopCharacter(distanceVec);
            }

        }

    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * .7f * Time.deltaTime));
    }

    void StopCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * 0 * Time.deltaTime));
    }



    void Facing()
    {
        //Debug.Log(playerPos.x + " " + transform.position.x);
        
        if (playerPos.x < transform.position.x)
        {
            //sprite.flipX = false;
        }
        if (playerPos.x > transform.position.x)
        {
            //sprite.flipX = true;
        }
        

    }
    

    float Angle()
    {
        
        float xDist = Mathf.Abs(playerPos.x - transform.position.x);
        float yDist = Mathf.Abs(playerPos.y - transform.position.y);

        float xDistTest = playerPos.x - transform.position.x;
        float yDistTest = playerPos.y - transform.position.y;

        float angle = Mathf.Atan(yDist / xDist) / .0174533f;
        
        if (yDistTest < 0)
        {
            angle = -1 * angle;
            
        }
        return angle;
        
    }






}








            
