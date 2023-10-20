using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    public bool open;
    public GameObject leftDoor;
    public GameObject rightDoor;
	public GameObject Player;
	public float moveDistance = 1.447f;
	// Start is called before the first frame update
	void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Player)
		{
			float dist = Vector3.Distance(Player.transform.position, transform.position);
			if (dist < 25)
			{
				if (open == false)
				{
					if (Input.GetMouseButtonDown(0))
					{
						// Calculate the new position based on the moveDistance
						Vector3 newPosition = rightDoor.transform.position + rightDoor.transform.TransformDirection(0,0,-5f);

						// Move the object to the new position
						rightDoor.transform.position = newPosition;

						newPosition = leftDoor.transform.position + leftDoor.transform.TransformDirection(0, 0, 5f);
						leftDoor.transform.position = newPosition;
						open = true;
					}
				}
				else
				{
					if (open == true)
					{
						if (Input.GetMouseButtonDown(0))
						{
							Vector3 newPosition = rightDoor.transform.position + rightDoor.transform.TransformDirection(0, 0, 5f);

							// Move the object to the new position
							rightDoor.transform.position = newPosition;

							newPosition = leftDoor.transform.position + leftDoor.transform.TransformDirection(0, 0, -5f);
							leftDoor.transform.position = newPosition;
							open = false;

						}
					}

				}

			}
		}

	}

}
