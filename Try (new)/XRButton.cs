using UnityEngine;
using UnityEngine.Events;

public class XRButton : MonoBehaviour
{
    public UnityEvent onPressed;

    public void Press()
    {
        onPressed.Invoke();
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
