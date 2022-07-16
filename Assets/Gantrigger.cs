using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gantrigger : MonoBehaviour
{
    Gangorra Father;
    // Start is called before the first frame update
    void Start()
    {
        Father = transform.parent.GetComponent<Gangorra>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Father.transform.GetChild(2).gameObject)
            Father.switchpoint(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
