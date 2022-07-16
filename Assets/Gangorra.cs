using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangorra : MonoBehaviour
{
    GameObject gan, trigger1, trigger2;
    TMPro.TextMeshPro counter;
    public int countdown = 5;

    // Start is called before the first frame update
    void Start()
    {
        trigger1 = transform.GetChild(0).gameObject;
        trigger2 = transform.GetChild(1).gameObject;
        gan = transform.GetChild(2).gameObject;
        counter = transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshPro>();
        counter.text = countdown.ToString();
    }

    public void switchpoint (GameObject putselfhere)
    {
        GameObject whotosetactive = putselfhere == trigger1 ? trigger2 : trigger1;
        whotosetactive.SetActive(true);
        putselfhere.SetActive(false);
        countdown -= 1;
        if (countdown == 0)
        {
            //globalcontroller.spawndice()
            Destroy(gameObject);
        }
        counter.text = countdown.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
