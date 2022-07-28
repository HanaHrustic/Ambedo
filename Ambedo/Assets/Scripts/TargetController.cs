using UnityEngine;

public class TargetController : MonoBehaviour
{
	[Header("Components")]
	public Transform target;            // The target object we picked up for scaling

	[Header("Parameters")]
	public LayerMask targetMask;        // The layer mask used to hit only potential targets with a raycast
	public LayerMask ignoreTargetMask;  // The layer mask used to ignore the player and target objects while raycasting
	public float offsetFactor;          // The offset amount for positioning the object so it doesn't clip into walls

	float originalDistance;             // The original distance between the player camera and the target
	float originalScale;                // The original scale of the target objects prior to being resized
	Vector3 targetScale;                // The scale we want our object to be set to each frame

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		HandleInput();
		ResizeTarget();
	}

	void HandleInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (target == null)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetMask))
				{
					if(hit.transform.gameObject.tag == "Resizable")
                    {
						target = hit.transform;
						target.GetComponent<Rigidbody>().isKinematic = true;
						originalDistance = Vector3.Distance(transform.position, target.position);
						originalScale = target.localScale.x;
						targetScale = target.localScale;
					}
				}
			}
			else
			{
				target.GetComponent<Rigidbody>().isKinematic = false;
				target = null;
			}
		}
	}

	void ResizeTarget()
	{
		if (target == null)
		{
			return;
		}
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
		{
			target.position = hit.point - transform.forward * offsetFactor * 2 * targetScale.x;
			float currentDistance = Vector3.Distance(transform.position, target.position);
			float s = currentDistance / originalDistance;
			targetScale.x = targetScale.y = targetScale.z = s;
			target.localScale = targetScale * originalScale;
			
		}
	}
}