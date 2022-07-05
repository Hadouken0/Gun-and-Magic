using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{

	[Header("Hands")]
    [SerializeField] private Hand _rightHand;
    [SerializeField] private Hand _leftHand;

	[Header("Interact ray distance")]
    [SerializeField] private float _interactRayDistance;

	[Header("Scarecrow")]
    [SerializeField] private Damageable _scarcrow;

	private void Update()
    {
		HandInteractInput();
	}
	
	private void HandInteractInput()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			_rightHand.DropItem();
			_rightHand.TakeItem(InteractItem());
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			_leftHand.DropItem();
			_leftHand.TakeItem(InteractItem());
		}
		if (Input.GetKey(KeyCode.Mouse0))
        {
			_leftHand.UseItem();
        }
		if (Input.GetKey(KeyCode.Mouse1))
		{
			_rightHand.UseItem();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			_scarcrow.Restore();
		}
	}

	private Wearable InteractItem()
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, _interactRayDistance))
		{
			if (hit.collider.gameObject.TryGetComponent(out Wearable wearable))
				return (wearable);
		}
		return null;
	}

}
