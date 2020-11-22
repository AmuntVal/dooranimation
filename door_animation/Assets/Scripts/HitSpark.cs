using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitSpark : MonoBehaviour
{
    GameObject Sparks;
    private GameObject FPS;
    private GameObject sword;
    private int interv = 100; 
    //private int duration = 20;
    
    private Animator kPlayerAnimator;
    private int lasttime = 200;
    private int shakedelay;
    //shakedelay = interv;
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        FPS = GameObject.Find("FPSController");
        sword = GameObject.Find("Object01");

        shakedelay = interv;
        Sparks = GameObject.Find("Sparks");
        initPos = Sparks.transform.position;
        kPlayerAnimator = FPS.GetComponentInChildren<Animator>();
    }

    private bool isHit()
    {
        if (Mathf.Abs(this.transform.position.x - sword.transform.position.x) < 1 || Mathf.Abs(this.transform.position.y - sword.transform.position.y) < 1)
            return true;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (shakedelay == 0)
        {
            camShake();
            Sparks.transform.position = sword.transform.position;
            lasttime --;
            Debug.Log("shake");
            shakedelay = interv;
            //return;
        }
        
        if (shakedelay < interv)
        {
            shakedelay--;
            
        }
        if(lasttime == 0)
        {
            Sparks.transform.position = initPos;
            lasttime = 200;
        }

        if(lasttime < 200)
        {
            lasttime--;
        }
        if (Input.GetMouseButtonDown(0))
        {
            shakedelay --;

        }
    }
    

    private void camShake()
    {
        float t = 0.5f;

        while (t > 0)
        {
            t -= Time.deltaTime;
            Camera.main.transform.localPosition = Random.insideUnitSphere * 0.05f;
        }
    }
}
