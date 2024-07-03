using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 Offset;


    void Update()
    {
        transform.position = target.transform.position + Offset;
    }
}
