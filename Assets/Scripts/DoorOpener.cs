using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour 
{
    private Animator anim;
    private DistanceCalculator mesafe;
    private float uzaklik;
    [SerializeField] GameObject player;
    DistanceCalculator discon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        discon = player.GetComponent<DistanceCalculator>();
    }

    void Update()
    {
        if ((discon.distance < 3.5f && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) )
        {
            anim.SetBool("open", false);
            
        }
        if (((discon.distance >= 3.5f) || GameObject.FindGameObjectsWithTag("Player").Length == 0) && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            anim.SetBool("open", true);
            FindObjectOfType<SFXPlayer>().PlayDoorOpen();
        }
    }

}
