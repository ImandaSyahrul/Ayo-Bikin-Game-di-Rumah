using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBar : MonoBehaviour
{
    #region Unity Properties
    public GameObject gValueScrollBar;
    public double value = 0.5;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var scrollRectTransform = this.GetComponent<RectTransform>();
        var gValueRectTransform = gValueScrollBar.GetComponent<RectTransform>();
        gValueRectTransform.sizeDelta = new Vector2(Convert.ToInt32(scrollRectTransform.rect.width * value), scrollRectTransform.rect.height);        
    }
}
