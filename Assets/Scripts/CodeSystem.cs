using System.Collections.Generic;
using UnityEngine;

public class SecretCodeManager : MonoBehaviour
{
    public List<int> secretCode = new List<int>() {5,1,5,3,5,4};

    List<int> buffer = new List<int>();

    public Transform otter;
    public float revealScale = 5f;

    public void FaceSeen(int faceID)
    {
        Debug.Log("FaceSeen called with ID: " + faceID);

        buffer.Add(faceID);

        if (buffer.Count > secretCode.Count)
        {
            buffer.RemoveAt(0);
        }

        Debug.Log("Current buffer: " + string.Join(",", buffer));

        CheckCode();
    }

    void CheckCode()
    {

        if (buffer.Count < secretCode.Count)
        {
            return;
        }

        for (int i = 0; i < secretCode.Count; i++)
        {
            if (buffer[i] != secretCode[i])
            {
                return;
            }
        }

        Debug.Log("SECRET CODE MATCHED!");
        RevealOtter();
    }

    void RevealOtter()
    {
        Debug.Log("Revealing Otter!");

        if (otter != null)
        {
            otter.localScale = Vector3.one * revealScale;
        }
        else
        {
            Debug.LogWarning("Otter transform not assigned!");
        }
    }
}