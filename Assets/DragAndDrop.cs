using UnityEngine;
using UnityEngine.UI;

// TODO: This code is just a sample and should be improved.
public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    public GameObject targetArea;
    public Text feedbackMessage;

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (IsObjectWithinTargetArea())
        {
            Debug.Log("Box dropped within the target area!");
            feedbackMessage.text = "Success!";
        }
        else
        {
            Debug.Log("Box dropped outside the target area.");
            // reset position
            transform.position = new Vector3(5, -1, 0);
            feedbackMessage.text = "Try Again!";
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Keep original z
        }
    }

    bool IsObjectWithinTargetArea()
    {
        Collider2D objectCollider = GetComponent<Collider2D>();
        Collider2D targetCollider = targetArea.GetComponent<Collider2D>();
        return objectCollider.IsTouching(targetCollider); 
    }
}
