using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public float maxRayDistance = 20f;

    public Transform playerBody;

    CharacterDialogueManager currentHoveredCharacter = null;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
        RaycastFromCamera();
    }
    void RaycastFromCamera()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction*maxRayDistance, Color.red, 1f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            Debug.Log("Hit");
            CharacterDialogueManager characterDisplay = hit.collider.GetComponent<CharacterDialogueManager>();

            // Check if the hit object has a CharacterNameDisplay component
            if (characterDisplay != null)
            {
                // If it's a different character than the currently hovered one, update UI
                if (characterDisplay != currentHoveredCharacter)
                {
                    // Notify the current hovered character to hide its name
                    if (currentHoveredCharacter != null)
                    {
                        currentHoveredCharacter.HideName();
                    }

                    // Update the current hovered character
                    currentHoveredCharacter = characterDisplay;

                    // Show the name of the new hovered character
                    currentHoveredCharacter.ShowName();
                }
            }
            else
            {
                Debug.Log("Character display null");               
                if (currentHoveredCharacter != null)
                {
                    currentHoveredCharacter.HideName();
                    currentHoveredCharacter = null;
                }
            }
        }
        else
        {
            Debug.Log("No hit");
            if (currentHoveredCharacter != null)
            {
                currentHoveredCharacter.HideName();
                currentHoveredCharacter = null;
            }
        }
    }
}
