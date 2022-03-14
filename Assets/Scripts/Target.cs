using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Target : MonoBehaviour
{
    private ScoreManager sm;
    public float hp, lifetime, speed;
    public Vector3 targetPos, startPos, endPos;
    

    private void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        Destroy(gameObject, lifetime);
        startPos = transform.position;
        targetPos = endPos;
    }

    public void TakeDamage(float amount)
    {
        //minus health when hit
        hp -= amount;
        

        if (hp <= 0f)
        {
            //call die function when health is 0, adding a point and destroying target
            Die();
        }
    }
    void Update()
    {
        //creating a customisable function for the movement of targets, floats left public to be able to create targets that move in different ways
        if (transform.position == endPos)
        {
            targetPos = startPos;
        }
        else if (transform.position == startPos)
        {
            targetPos = endPos;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    void Die()
    {
        //add point to target score, destroy target
        sm.score++;
        Destroy(gameObject);
    }

  

}
