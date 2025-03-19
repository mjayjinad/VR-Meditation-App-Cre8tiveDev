using UnityEngine;
using UnityEngine.UI;

public class CurvedUI : MonoBehaviour
{
    public int buttonCount = 5;  // Number of buttons
    public float radius = 2f;    // Radius of curvature
    public float arcAngle = 180f; // Arc angle in degrees

    void Start()
    {
        ArrangeButtons();
    }

    void ArrangeButtons()
    {
        int index = 0;
        foreach (Transform button in transform)
        {
            float angle = Mathf.Lerp(-arcAngle / 2, arcAngle / 2, (float)index / (buttonCount - 1));
            float radian = Mathf.Deg2Rad * angle;

            // Position the button in an arc
            button.localPosition = new Vector3(Mathf.Sin(radian) * radius, 0, Mathf.Cos(radian) * radius);
            button.LookAt(transform.position); // Make the buttons face inward
            index++;
        }
    }
}