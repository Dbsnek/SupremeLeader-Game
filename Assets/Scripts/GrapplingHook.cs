//using System.Numerics;
using UnityEngine;


public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public float grappleDistance = 1f;
    public LayerMask mask;
    public float step;

    private CharacterController2D _characterController2D;
    private PlayerInput_KE _input;
    private Player _player;
    private DistanceJoint2D _joint;

    private RaycastHit2D hit;
    private Vector3 targetDir;
    private Vector2 hitPos;
    private Transform targetTransform;


    private void Awake()
    {
        _player = GetComponent<Player>();
        _joint = GetComponent<DistanceJoint2D>();
        _input = _player.input;
        _characterController2D = _player.characterController2D;
    }
    void Start()
    {
        _joint.enabled = false;
        line.enabled = false;
        _input.OnButtonPressed += Input_OnButtonPressed;
    }

    private void Input_OnButtonPressed(string button)
    {
        if (!_player.hasGrappling)
            return;
        
        if (button == "BbuttonDown")
        {
            _player.isGrappling = true;
            if (_characterController2D.m_FacingRight == true)
            {
                targetDir = new Vector3(10, 10, 0);
            }
            else if (_characterController2D.m_FacingRight == false)
            {
                targetDir = new Vector3(-10, 10, 0);
            }
            targetDir.z = 0;

            hit = Physics2D.Raycast(transform.position, targetDir, grappleDistance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                _joint.enabled = true;
                _joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                _joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                _joint.distance = Vector2.Distance(base.transform.position, hit.point);

                
                hitPos = hit.point;

                targetTransform = new GameObject().transform;
                targetTransform.SetParent(hit.collider.transform);
                targetTransform.position = hitPos;

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                line.GetComponent<RopeRatio>().grabPos = hit.point;
            }
        }

        

        if (button == "BbuttonUp")
        {
            
            _joint.enabled = false;
            _player.isGrappling = false;
            line.enabled = false;
        }

    }

    void Update()
    {

        if (_player.isGrappling && _joint != null)
        {

            line.SetPosition(0, transform.position);
            line.SetPosition(1, targetTransform.position);
            
            if(_input.movementInput.y > 0)
            {
                Debug.Log("stepping down" + _joint.distance);
                _joint.distance -= step * Time.deltaTime;
            }
            
            else if(_input.movementInput.y < 0)
            {
                _joint.distance += step * Time.deltaTime;
            }

            
            if (_joint.distance < .5f)
            {
                line.enabled = false;
                _joint.enabled = false;
                _joint.connectedBody = null;
                _player.isGrappling = false;
            }


        }

    }

}
