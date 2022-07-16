using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject ObjectToAttach;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private GameObject CurrentObjectAttach;
    public float levitationvalue;
    public float levitationspeed;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray TryHit = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit TheHit;
            if (Physics.Raycast(TryHit, out TheHit))
            {
                if (TheHit.transform.CompareTag("Player"))
                {
                    CurrentObjectAttach = Instantiate(ObjectToAttach, TheHit.point, Quaternion.identity);
                    CurrentObjectAttach.GetComponent<ConfigurableJoint>().connectedBody = TheHit.rigidbody;
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(CurrentObjectAttach);
        }

        if (CurrentObjectAttach != null)
        {
            Vector3 GrabPosition = CurrentObjectAttach.transform.position;
            CurrentObjectAttach.transform.position = new Vector3(GrabPosition.x + Input.GetAxis("Mouse X") * sensitivity, Mathf.Lerp(GrabPosition.y, levitationvalue, levitationspeed * Time.deltaTime), GrabPosition.z + Input.GetAxis("Mouse Y") * sensitivity);
        }
    }
}
