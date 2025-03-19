using UnityEngine;
using UnityEngine.InputSystem; // Use Unity's new Input System

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject objectA; // Assign the first GameObject in Inspector
    public GameObject objectB; // Assign the second GameObject in Inspector

    void Start()
    {
        // Ensure only one object is active at the beginning
        if (objectA != null && objectB != null)
        {
            objectA.SetActive(true);
            objectB.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the left mouse button is clicked using the new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ToggleObjects();
        }
    }

    void ToggleObjects()
    {
        // Toggle the active states of the two GameObjects
        if (objectA != null && objectB != null)
        {
            bool isObjectAActive = objectA.activeSelf;

            objectA.SetActive(!isObjectAActive); // Toggle Object A
            objectB.SetActive(isObjectAActive); // Toggle Object B
        }
    }
}
