using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBehaviour : MonoBehaviour
{
    public GameObject mapImage;

    /// <summary>
    /// Load images in the map.
    /// </summary>
    /// <param name="matrix">Matrix with the items</param>
    public void LoadImagesByMatrix(Matrix matrix)
    {
        matrix.ForEach(LoadImage);
    }

    private void LoadImage(DungeonItem item, int row, int column)
    {
        // Instantiate new Image to show on the map
        GameObject imageGameObject = Instantiate(mapImage, transform);
        Image image = imageGameObject.GetComponent<Image>();
        RectTransform rectTransform = imageGameObject.GetComponent<RectTransform>();
        
        // Set item Sprite
        image.sprite = item.itemIcon;
        
        // Calculate the position in the map using anchors
        float percentage = 1f / Matrix.SIZE;
        float maxY = 1 - percentage * row;
        float minY = maxY - percentage;
        float minX = 0.2f * column;
        float maxX = minX + 0.2f;
        rectTransform.anchorMax = new(maxX, maxY);
        rectTransform.anchorMin = new(minX, minY);
    }
}
