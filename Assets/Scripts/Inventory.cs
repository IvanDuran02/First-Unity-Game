using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHeight;

    public int slots;

    public int rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab; 

    private List<GameObject> allSlots; // contains all objects in inventory

    

    void Start()
    {
        CreateLayout();
    }


    void Update()
    {
        
    }

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;

        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = slots / rows;

    for (int y = 0; y < rows; y++)
    {
        for (int x = 0; x < columns; x++)
        {
            GameObject newSlot = (GameObject)Instantiate(slotPrefab);

            RectTransform slotRect = newSlot.GetComponent<RectTransform>();

            newSlot.name = "Slot"; // sets names for created slots

            newSlot.transform.SetParent(this.transform.parent);

            slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));

            slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
            slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

            allSlots.Add(newSlot);
        }
    } 
    }
}
