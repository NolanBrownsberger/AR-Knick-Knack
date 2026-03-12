using System.Collections.Generic;
using UnityEngine;

public class CubeFaceTracker : MonoBehaviour
{
    public List<CubeFace> faces;
    public SecretCodeManager manager;

    int currentFace = -1;

    void Start()
    {
        Debug.Log("CubeFaceTracker started. Faces list count: " + faces.Count);
        if (manager == null)
        {
            Debug.LogWarning("SecretCodeManager reference not set!");
        }
    }

    void Update()
    {
        if (faces == null || faces.Count == 0)
        {
            Debug.LogWarning("No faces assigned!");
            return;
        }

        Camera cam = Camera.main;

        float bestDot = -1f;
        int visibleFace = -1;

        foreach (CubeFace face in faces)
        {
            Vector3 faceForward = face.transform.up; // use the red axis instead of blue
            Vector3 toCamera = (cam.transform.position - face.transform.position).normalized;

            float dot = Vector3.Dot(faceForward, toCamera);

            if (dot > bestDot)
            {
                bestDot = dot;
                visibleFace = face.faceID;
            }
        }

        if (visibleFace != currentFace)
        {
            Debug.Log("Visible face changed to: " + visibleFace);
            currentFace = visibleFace;

            if (manager != null)
            {
                manager.FaceSeen(currentFace);
            }
        }
    }
}