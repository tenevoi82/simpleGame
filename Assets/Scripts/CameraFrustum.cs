using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraFrustum : MonoBehaviour
{
    public Vector3[] xy = new Vector3[4];
    [SerializeField]
    private float distance;
    private void OnDrawGizmos()
    {
        Camera cam = GetComponent<Camera>();
        xy[0] = cam.ScreenToWorldPoint(new Vector2(0f, 0f));
        xy[1] = cam.ScreenToWorldPoint(new Vector2(0f, cam.pixelHeight));
        xy[2] = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));
        xy[3] = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, 0f));
        Gizmos.DrawLine(xy[0], xy[1]);
        Gizmos.DrawLine(xy[1], xy[2]);
        Gizmos.DrawLine(xy[2], xy[3]);
        Gizmos.DrawLine(xy[3], xy[0]);
        
    }
}