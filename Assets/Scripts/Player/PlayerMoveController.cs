using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
	[Header("Move")]
	[SerializeField] private float moveSpeed;



	[Header("References")]
    [SerializeField] private CharacterController characterController;
	




    private void Update()
    {
		Move();
    }


    private void Move()
    {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * horizontal + transform.forward * vertical) * moveSpeed;
		characterController.Move(move * Time.deltaTime); 
	}




}
