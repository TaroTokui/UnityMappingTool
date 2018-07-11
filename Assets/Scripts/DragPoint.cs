using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPoint : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    //private Vector3 pos;
    private string MyName;
    private GameObject _parent;

    private void OnEnable()
    {
        // get parent object
        _parent = gameObject.transform.parent.gameObject;

        Vector3 pos;
        //name = transform.name;
        //Debug.Log(name);

        // load data
        pos.x = PlayerPrefs.GetFloat(name + "x");
        pos.y = PlayerPrefs.GetFloat(name + "y");
        pos.z = -0.1f;
        //PlayerPrefs.SetInt("x", )

        transform.position = pos + _parent.transform.position;
    }

    //private void OnDestroy()
    //{
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // save data
            PlayerPrefs.SetFloat(name + "x", transform.position.x - _parent.transform.position.x);
            PlayerPrefs.SetFloat(name + "y", transform.position.y - _parent.transform.position.y);
            //PlayerPrefs.SetFloat(name + "z", pos.z);
            PlayerPrefs.Save();
        }
    }

    void OnMouseDown()
    {
        if (!Input.GetKey(KeyCode.C)) return;

        // マウスカーソルは、スクリーン座標なので、
        // 対象のオブジェクトもスクリーン座標に変換してから計算する。

        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (!Input.GetKey(KeyCode.C)) return;
        //Debug.Log("kita");
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        //transform.GetComponent<Transform>().position = Input.mousePosition;
        currentPosition.z = -0.1f;
        transform.position = currentPosition;

        // for save
        //pos = currentPosition;
    }

    private void OnMouseUp()
    {
        //if (!Input.GetKey(KeyCode.C)) return;
        //// save data
        //PlayerPrefs.SetFloat(name + "x", pos.x);
        //PlayerPrefs.SetFloat(name + "y", pos.y);
        ////PlayerPrefs.SetFloat(name + "z", pos.z);
        //PlayerPrefs.Save();
    }
}
