using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;

    AudioManager audioManager;

    public TrailRenderer tr;

    PlayerControllerStateMachine _sm;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        _sm = GameObject.FindObjectOfType<PlayerControllerStateMachine>();

        _distanceJoint.enabled = false;

        tr.sortingLayerName = "Player";
        _lineRenderer.sortingLayerName = "Player";
        _lineRenderer.sortingOrder = 10;
        _lineRenderer.positionCount = 2;
    }

    // Update is called aonce per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _sm.isGrappleAcquired && TempClick.isClicked)
        {
            AudioManager.instance.Play("Grapple");
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
       
        else if (Input.GetKeyUp(KeyCode.Mouse0) && _sm.isGrappleAcquired && TempClick.isClicked)
        {
            TempClick.isClicked = false;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }

        //Testing out to change web length at real time
        if (Input.GetKeyDown(KeyCode.Mouse1) && _sm.isGrappleAcquired)
        {
            AudioManager.instance.Play("GrappleRelease");
            _lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z));
        }
    }
}
