using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	public float speed = 5;
	public float rotationSpeed = 8;
    public Transform _weaponPivot;
    public Animator pistolAnim;

    public static Vector3 playerPosition;

    private Transform _mainCamera;

	private Vector3 _moveDirection;
	private float _gravity = 20;
	private Transform _transfrom;
    private AudioSource pistolShootAuido;

    private Ray _ray;

	private CharacterController _characterController;

	// Use this for initialization
	void Start () {
		_mainCamera = Camera.main.transform;
		_transfrom = this.transform;
		_moveDirection = Vector3.zero;
		_characterController = this.GetComponent<CharacterController> ();
        pistolShootAuido = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        pistolAnim.SetBool("isFire", false);
        if (Input.GetMouseButtonDown(0)) {
            pistolAnim.SetBool("isFire", true);
            pistolShootAuido.Play();

            

            _ray = new Ray(_mainCamera.position, _mainCamera.forward);
            RaycastHit _rayHit = new RaycastHit();

            if (Physics.Raycast(_ray, out _rayHit)) {
                if(_rayHit.collider.tag == "Target") {
                    Destroy(_rayHit.collider.gameObject);
                    TargetSpawner.isTargetSpawned = false;
                    ScoreManager.instance.Score++;
                }
            }
        }

        playerPosition = this.transform.position;

    }

	void FixedUpdate(){
        Movement();
        FPSCamera();
        WeaponRotate();
        _moveDirection.y -= _gravity * Time.deltaTime;
		_characterController.Move (_moveDirection * Time.deltaTime);
		_mainCamera.position = new Vector3(_transfrom.position.x, _transfrom.position.y + 1, _transfrom.position.z);
    }

    private void FPSCamera() {
        _mainCamera.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Set Limitation of Camera Rotation;
        if(_mainCamera.localEulerAngles.x > 75 && _mainCamera.localEulerAngles.x < 180) {
            _mainCamera.localEulerAngles = new Vector3(75, _mainCamera.localEulerAngles.y, 0);
        }else if (_mainCamera.localEulerAngles.x > 180 && _mainCamera.localEulerAngles.x < 285) {
            _mainCamera.localEulerAngles = new Vector3(285, _mainCamera.localEulerAngles.y, 0);
        } else {
            _mainCamera.localEulerAngles = new Vector3(_mainCamera.localEulerAngles.x, _mainCamera.localEulerAngles.y, 0);
        }
    }

    private void WeaponRotate() {
        Quaternion _controllerTargetRotation = Quaternion.Euler(0, _mainCamera.eulerAngles.y, 0);
        Quaternion _pivotTargetRotation = Quaternion.Euler(_mainCamera.eulerAngles.x, _mainCamera.eulerAngles.y, 0);
        _transfrom.rotation = Quaternion.Slerp(_transfrom.rotation, _controllerTargetRotation, rotationSpeed * Time.deltaTime);
        _weaponPivot.rotation = Quaternion.Slerp(_weaponPivot.rotation, _pivotTargetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Movement() {
        if (_characterController.isGrounded) {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = _transfrom.TransformDirection(_moveDirection);
            _moveDirection *= speed;
        }
    }
}
