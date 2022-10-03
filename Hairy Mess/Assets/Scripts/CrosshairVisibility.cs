using UnityEngine;
using UnityEngine.UI;

public class CrosshairVisibility : MonoBehaviour
{
    private Image ren;

    private void Start()
    {
        ren=GetComponent<Image>();
    }

    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            ren.enabled = false;
        }

        if (Input.GetMouseButton(1))
        {
            ren.enabled = true;
        }
    }
}