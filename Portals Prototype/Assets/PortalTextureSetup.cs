using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    [SerializeField] private string _camType;
    //public Camera _mainCamera;
    public Camera _cameraB;
    public Material _cameraMatB;

    public Vector4 _clipPlane;
    [SerializeField] private float _nearClipLimit;

    void Start()
    {
        if (_cameraB == null)
        {
            _cameraB = GameObject.FindGameObjectWithTag(_camType).GetComponent<Camera>();
        }

        if (_cameraB.targetTexture != null)
        {
            _cameraB.targetTexture.Release();
        }
        _cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatB.mainTexture = _cameraB.targetTexture;
    }

    private void Update()
    {
        //Transform clip_plane = transform;
        //int dot = System.Math.Sign(Vector3.Dot(clip_plane.forward, transform.position - _cameraB.transform.position));

        //Vector3 cam_space_pos = _cameraB.worldToCameraMatrix.MultiplyPoint(clip_plane.position);
        //Vector3 cam_space_normal = _cameraB.worldToCameraMatrix.MultiplyVector(clip_plane.forward) * dot;
        //float swap_var = cam_space_normal.z;
        //cam_space_normal.z = cam_space_normal.y;
        //cam_space_normal.y = swap_var;
        //float cam_space_distance = -Vector3.Dot(cam_space_pos, cam_space_normal);

        //if (Vector3.Distance(transform.position,_cameraB.transform.position) > _nearClipLimit)
        //{
        //    Vector4 clip_plane_cam_space = new Vector4(cam_space_normal.x, cam_space_normal.y, cam_space_normal.z, cam_space_distance);
        //    _cameraB.projectionMatrix = Camera.main.CalculateObliqueMatrix(clip_plane_cam_space);
        //}
        //else
        //{
        //    Debug.Log("near");
        //}
    }
}
