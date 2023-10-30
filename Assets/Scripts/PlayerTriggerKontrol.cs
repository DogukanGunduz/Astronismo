using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerKontrol : MonoBehaviour
{

    public PlayerPool playerPool;
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    [SerializeField] GameObject patlamaPrefab;
    [SerializeField] GameObject patlamaPrefabUzay;
    Vector3 x, z;
    public int nextSceneLoad;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPool = FindObjectOfType<PlayerPool>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;


    }
    private void Update()
    {
        x = transform.right * Input.GetAxisRaw("Horizontal");
        z = transform.forward * Input.GetAxisRaw("Vertical");
    }



    private  async void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (collision.gameObject.tag == "Trap")
        {
            if(gameObject.tag == "Enemy")
            {
                
                DieAlien();
  
            }
            if (gameObject.tag == "Player")
            {
                Die();
            }

           
        }

        if (collision.gameObject.tag == "Gate")
        {
            if (playerPool.AlienCount <= 0)
            {


                if (playerPool.PlayerCount >= 1)
                {
                    FindObjectOfType<SFXPlayer>().PlayDoorPass();
                    playerPool.PlayerCount--;
                    Destroy(gameObject);
                }
                if (playerPool.PlayerCount == 0)
                {
                    FindObjectOfType<SFXPlayer>().PlaySuccess();
                    await Task.Delay(1000);
                    SceneManager.LoadScene(nextSceneLoad);
                }


            }
        }
        if (collision.gameObject.tag == "ConstantAstronot")
        {
            gameObject.GetComponent<PlayerMovementButon>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            FindObjectOfType<SFXPlayer>().StopFootStepLoop();
            anim.SetTrigger("tepik");
            FindObjectOfType<SFXPlayer>().PlayKickSound();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();

        

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(scene.name);
        }

        

    }

    private void Die()
    {
        FindObjectOfType<SFXPlayer>().PlayDeath();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        boxCollider2D.isTrigger = true;
    }

    private async void DieAlien()
    {
        FindObjectOfType<SFXPlayer>().PlayAlienDeath();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        playerPool.AlienCount--;
        boxCollider2D.isTrigger = true;
        await Task.Delay(300);
        Destroy(gameObject);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void patlamaAnim()
    {
        Vector3 transformPatlama = gameObject.transform.position;
        transformPatlama.y = transformPatlama.y + 0.8f;
        Instantiate(patlamaPrefab, transformPatlama, Quaternion.identity);
        
    }

    private void patlamaAnimUzay()
    {
        Vector3 transformPatlama = gameObject.transform.position;
        transformPatlama.y = transformPatlama.y + 1f;
        transformPatlama.x = transformPatlama.x + 1f;
        Instantiate(patlamaPrefabUzay, transformPatlama, Quaternion.identity);

    }

    private void tekmelendinBolumu()
    {
        SceneManager.LoadScene("Uctun");
    }


}
