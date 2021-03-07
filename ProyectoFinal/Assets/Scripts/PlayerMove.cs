using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticallInputName;
    [SerializeField] private float movementSpeed;
    private CharacterController charController;

    [SerializeField] private float jumpmultiplier;
    [SerializeField] private AnimationCurve jumpfalloff;
    [SerializeField] private KeyCode jumpKey;

    private bool isJumping;
    // Use this for initialization
    void Start () {
        charController = GetComponent < CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
	}

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticallInputName) * movementSpeed ;
        float horInput = Input.GetAxis(horizontalInputName) * movementSpeed ;

        Vector3 forwadMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horInput;

        charController.SimpleMove(forwadMovement + rightMovement);
        JumpInput();
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }

    }


    private IEnumerator JumpEvent()
    {

        float timeInAir = 0.0f;

        charController.slopeLimit = 90.0f;
        do
        {
            float jumpforce = jumpfalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpforce * jumpmultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        
        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
