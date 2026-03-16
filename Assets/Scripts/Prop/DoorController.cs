using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float openDuration;

    private bool _isOpen;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    IEnumerator OpenDoor(bool isOpen)
    {
        float duration = openDuration;
        float distance = 3f;
        Vector3 startPos = door.position;
        Vector3 endPos = startPos + Vector3.up * distance;
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            if (isOpen)
            {
                door.position = Vector3.Lerp(startPos, endPos, t);
            }
        
            yield return null;
        }

        door.transform.position = endPos;
    }
}
