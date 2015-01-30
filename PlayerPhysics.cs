using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 size;
	private Vector3 center;

	private float skin = .005f;

	[HideInInspector]
	public bool grounded;

	Ray ray;
	RaycastHit hit;

	void Start()
	{
			collider = GetComponent<BoxCollider> ();
			size = collider.size;
			center = collider.center;
	}

	public void Move(Vector2 moveAmount)
	{
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position;

		for(int i = 0; i <= 3; i++)
		{
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + center.x - size.x/2) + size.x * i;	// left, center, & then rightmost point of the collider
			float y = p.y + center.y + size.y/2 * dir; 			// bottom of collider

			ray = new Ray(new Vector2(x,y), new Vector2(0, dir));

			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask))
			{
				float distance = Vector3.Distance (ray.origin, hit.point); // get distance between player & ground

				// Stop player's downwards movement after coming within skin width of a collider
				if(distance > skin){
					deltaY = distance * dir + skin;
				}
				else
				{
					deltaY = 0;
				}

				grounded = true;
				break;
			}
		}

		Vector2 finalTransform = new Vector2(deltaX, deltaY);

		transform.Translate (finalTransform);
	}
}
