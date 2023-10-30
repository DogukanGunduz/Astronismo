using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstantAstronotAnimScript : MonoBehaviour
{
    Animator animator;
    private BoxCollider2D boxCollider2D;
    private PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            boxCollider2D.isTrigger = true;
            polygonCollider2D.enabled = false;
            setStartTrue();
            
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            setDanceTrue();
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            setSitTrue();
        }
    }


    public void setStartTrue()
    {
        animator.SetTrigger("start");
    }
    public void setSitTrue()
    {
        animator.SetTrigger("sit");
    }
    public void setElSallaTrue()
    {
        animator.SetTrigger("elsalla");
    }
    public void setDanceTrue()
    {
        animator.SetTrigger("dance");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("tepik");
        }
    }

}
