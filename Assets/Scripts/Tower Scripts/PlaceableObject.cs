using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public string objectName = "Placeable Object";
    public Vector3 gridLocation = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        UpdateGridLocation();
    }


    public void UpdateGridLocation()
    {
        gridLocation = Grid.GetGridPosition(transform.position);
    }

}
