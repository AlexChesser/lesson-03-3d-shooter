#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGround : MonoBehaviour
{

    [SerializeField] private LayerMask LayerMask;

    void Update()
    {
        if (LayerMask == 0) {
            LayerMask = LayerMask.GetMask("Default");
        }
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 2f, LayerMask)) {
            transform.position = new Vector3(transform.position.x, hitInfo.point.y, transform.position.z);
        }
    }
}
#endif
