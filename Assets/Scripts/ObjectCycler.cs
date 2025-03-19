using UnityEngine;
using UnityEngine.Events;

public class ObjectCycler : MonoBehaviour
{
    public GameObject[] objects; // List of objects to cycle through
    public float[] delays; // Delay time for each object in seconds
    public int currentIndex = 0;
    public UnityEvent OnBreatingComplete = new UnityEvent();

    void Start()
    {
        if (objects.Length > 0 && delays.Length == objects.Length)
        {
            Invoke("CycleToNextObject", delays[currentIndex]);
        }
        else
        {
            Debug.LogError("Ensure objects and delays arrays are properly set and of the same length.");
        }
    }

    void CycleToNextObject()
    {
        if (currentIndex >= objects.Length) return; // Stop if all are activated

        // Activate the next object in line
        objects[currentIndex].SetActive(true);

        Debug.Log("Call");
        // Move to the next index
        currentIndex++;

        // Schedule the next activation if there are more objects
        if (currentIndex < objects.Length)
        {
            Debug.Log("Called");
            Invoke("CycleToNextObject", delays[currentIndex]);
        }
        else
        {
            OnBreatingComplete.Invoke();
        }
    }
}
