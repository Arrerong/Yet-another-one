using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera gunCam;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(gunCam.transform.position, gunCam.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
            }
            
            if (hit.collider.tag == "Player")
            {           
                Destroy (hit.collider.gameObject);
            }
        }
    }
}