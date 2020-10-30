using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunk : MonoBehaviour
{
    public Animator animator;
    public GameObject witcher;
    WitcherVisualisation witcherVisualisation;
    bool notSobber = true;
    float start;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        witcherVisualisation = witcher.GetComponent<WitcherVisualisation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float tmp = witcherVisualisation.BarX / 1000;
        animator.SetFloat("DrunkValue", tmp);

        if(animator.GetFloat("DrunkValue") > 1 && notSobber) 
        {
            start = Time.unscaledDeltaTime;
            notSobber = false;

        }
        if(animator.GetFloat("DrunkValue") > 1 && start - Time.unscaledDeltaTime == 10)
        {
            animator.SetBool("Lose", true);
        }
        if(animator.GetFloat("DrunkValue") < 1 && !notSobber) 
        {
            notSobber = true;
            start = 0;
        }
        if(tmp >= 1)
        {
            animator.SetBool("Win", true);
            witcher.SetActive(false);
        }
        if (tmp <= 0)
        {
            animator.SetBool("Lose", true);
        }



    }
}
