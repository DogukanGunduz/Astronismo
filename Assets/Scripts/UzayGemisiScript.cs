using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject slalomPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("start", true);
    }
    private void Sallan()
    {
        Vector3 transformSlalom = gameObject.transform.position;
        Instantiate(slalomPrefab, transformSlalom, Quaternion.identity);
    }

    
}
