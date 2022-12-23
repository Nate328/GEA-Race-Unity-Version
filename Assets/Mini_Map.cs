using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Map : MonoBehaviour
{
    
    public enum UnitsIn {pixels,screen_percentage};
    public UnitsIn unit = UnitsIn.screen_percentage;
    public int width = 50;
    public int height = 50;
    public int xOffset = 0;
    public int yOffset = 0;
    public bool update = true;
    private int hsize, vsize, hloc, vloc;
    // Start is called before the first frame update
    void Start()
    {
        AdjustCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            AdjustCamera();
        }
    }

    void AdjustCamera()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;
        float xOffPercent = xOffset * swPercent;
        float yOffPercent = yOffset * shPercent;
        int xOff;
        int yOff;
        if (unit == UnitsIn.screen_percentage)
        {
            if (unit == UnitsIn.screen_percentage)
            {
                hsize = width * (int)swPercent;
                vsize = height * (int)shPercent;
                xOff = (int)xOffPercent;
                yOff = (int)yOffPercent;
            } else
            {
                hsize = width;
                vsize = height;
                xOff = xOffset;
                yOff = yOffset;
            }
            int justifiedTop = (sw - vsize);
            hloc = xOff;
            vloc = (justifiedTop - yOff);
            GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);
        }
    }
}
