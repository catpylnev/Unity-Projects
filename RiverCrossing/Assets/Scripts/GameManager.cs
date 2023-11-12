using UnityEngine;

public class RiverCrossingGame : MonoBehaviour
{
    private GameObject boat;
    private bool boatOnNegativeShore; // true if boat is on the negative shore, false otherwise
    private GameObject[] passengersOnBoat;

    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat");
        boatOnNegativeShore = true;
        passengersOnBoat = new GameObject[1];
    }

    void Update()
    {
        // Check for player input
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Boat"))
                {
                    // Toggle boat position only if the boat is empty
                    if (passengersOnBoat[0] == null)
                    {
                        ToggleBoatPosition();
                    }
                }
                else if (passengersOnBoat[0] != null)
                {
                    if (boatOnNegativeShore && hit.point.x > 0 && clickedObject.CompareTag("Boat"))
                    {
                        // Move item from boat to positive shore
                        MoveFromBoat(clickedObject);
                    }
                    else if (!boatOnNegativeShore && hit.point.x < 0 && clickedObject.CompareTag("Boat"))
                    {
                        // Move item from boat to negative shore
                        MoveFromBoat(clickedObject);
                    }
                }
                else if (boatOnNegativeShore && hit.point.x < 0 && clickedObject.CompareTag("Chicken"))
                {
                    // Move chicken to boat
                    MoveToBoat(clickedObject);
                }
                else if (!boatOnNegativeShore && hit.point.x > 0 && clickedObject.CompareTag("Seeds"))
                {
                    // Move seeds to boat
                    MoveToBoat(clickedObject);
                }
            }
        }
    }

    void MoveToBoat(GameObject item)
    {
        if (passengersOnBoat[0] == null)
        {
            passengersOnBoat[0] = item;
            item.transform.SetParent(boat.transform);
            item.transform.localPosition = Vector3.zero;
        }
    }

    void MoveFromBoat(GameObject boatObject)
    {
        if (passengersOnBoat[0] != null)
        {
            GameObject item = passengersOnBoat[0];
            passengersOnBoat[0] = null;
            item.transform.SetParent(null);

            // Implement logic to check if move is valid
            // For example, check if leaving wolf with chicken or chicken with seeds
            if (IsValidMove())
            {
                // Move item to shore
                float xPos = boatOnNegativeShore ? -5f : 5f;
                item.transform.position = new Vector3(xPos, item.transform.position.y, item.transform.position.z);
            }
            else
            {
                // Invalid move, move the item back to the boat
                MoveToBoat(item);
            }
        }
    }

    void ToggleBoatPosition()
    {
        if (passengersOnBoat[0] != null)
        {
            // Boat can't leave the shore empty
            MoveFromBoat(boat);
        }
        else
        {
            boatOnNegativeShore = !boatOnNegativeShore;
            float xPos = boatOnNegativeShore ? -5f : 5f;

            // Move the boat to the new position
            boat.transform.position = new Vector3(xPos, boat.transform.position.y, boat.transform.position.z);
        }
    }

    bool IsValidMove()
    {
        // If the boat is on the negative shore, check conditions for items on the boat
        if (boatOnNegativeShore)
        {
            // Check if the wolf is left with the chicken
            if (passengersOnBoat[0].CompareTag("Wolf") && passengersOnBoat[1].CompareTag("Chicken"))
            {
                return false;
            }
            // Check if the chicken is left with the seeds
            else if (passengersOnBoat[0].CompareTag("Chicken") && passengersOnBoat[1].CompareTag("Seeds"))
            {
                return false;
            }
        }
        else // If the boat is on the positive shore, check conditions for items on the boat
        {
            // Check if the wolf is left with the chicken
            if (passengersOnBoat[0].CompareTag("Chicken") && passengersOnBoat[1].CompareTag("Wolf"))
            {
                return false;
            }
            // Check if the chicken is left with the seeds
            else if (passengersOnBoat[0].CompareTag("Seeds") && passengersOnBoat[1].CompareTag("Chicken"))
            {
                return false;
            }
        }

        // If none of the invalid conditions are met, the move is valid
        return true;
    }

}
