using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fenderrio.ImageWarp;

public class AnchorController : MonoBehaviour {

    const float IMAGE_WIDTH2 = 9.6f * 0.5f;
    const float IMAGE_HEIGHT2 = 5.4f * 0.5f;

    NativeRenderTextureWarp _RenderTextureWarp;

    Transform TopLeft;
    Transform TopRight;
    Transform BottomRight;
    Transform BottomLeft;
    Transform TopBezierHandlA;
    Transform TopBezierHandlB;
    Transform LeftBezierHandlA;
    Transform LeftBezierHandlB;
    Transform RightBezierHandlA;
    Transform RightBezierHandlB;
    Transform BottomBezierHandlA;
    Transform BottomBezierHandlB;

    // Anchor base bosition
    private Vector3 BaseTopLeft;
    private Vector3 BaseTopRight;
    private Vector3 BaseBottomRight;
    private Vector3 BaseBottomLeft;
    private Vector3 BaseTopBezierHandlA;
    private Vector3 BaseTopBezierHandlB;
    private Vector3 BaseLeftBezierHandlA;
    private Vector3 BaseLeftBezierHandlB;
    private Vector3 BaseRightBezierHandlA;
    private Vector3 BaseRightBezierHandlB;
    private Vector3 BaseBottomBezierHandlA;
    private Vector3 BaseBottomBezierHandlB;
    
    // Use this for initialization
    void OnEnable () {
        _RenderTextureWarp = gameObject.GetComponent<NativeRenderTextureWarp>();
        //Debug.Log(_RenderTextureWarp.cornerOffsetTL);

        TopLeft = gameObject.transform.Find("TopLeft").gameObject.GetComponent<Transform>();
        TopRight = gameObject.transform.Find("TopRight").gameObject.GetComponent<Transform>();
        BottomRight = gameObject.transform.Find("BottomRight").gameObject.GetComponent<Transform>();
        BottomLeft = gameObject.transform.Find("BottomLeft").gameObject.GetComponent<Transform>();
        TopBezierHandlA = TopLeft.transform.Find("TopBezierHandlA").GetComponent<Transform>();
        TopBezierHandlB = TopRight.transform.Find("TopBezierHandlB").gameObject.GetComponent<Transform>();
        LeftBezierHandlA = BottomLeft.transform.Find("LeftBezierHandlA").gameObject.GetComponent<Transform>();
        LeftBezierHandlB = TopLeft.transform.Find("LeftBezierHandlB").gameObject.GetComponent<Transform>();
        RightBezierHandlA = TopRight.transform.Find("RightBezierHandlA").gameObject.GetComponent<Transform>();
        RightBezierHandlB = BottomRight.transform.Find("RightBezierHandlB").gameObject.GetComponent<Transform>();
        BottomBezierHandlA = BottomRight.transform.Find("BottomBezierHandlA").gameObject.GetComponent<Transform>();
        BottomBezierHandlB = BottomLeft.transform.Find("BottomBezierHandlB").gameObject.GetComponent<Transform>();
        
        // set base posotion
        BaseTopLeft = TopLeft.transform.position;
        BaseTopRight = TopRight.transform.position;
        BaseBottomRight = BottomRight.transform.position;
        BaseBottomLeft = BottomLeft.transform.position;
        BaseTopBezierHandlA = TopBezierHandlA.transform.position;
        BaseTopBezierHandlB = TopBezierHandlB.transform.position;
        BaseLeftBezierHandlA = LeftBezierHandlA.transform.position;
        BaseLeftBezierHandlB = LeftBezierHandlB.transform.position;
        BaseRightBezierHandlA = RightBezierHandlA.transform.position;
        BaseRightBezierHandlB = RightBezierHandlB.transform.position;
        BaseBottomBezierHandlA = BottomBezierHandlA.transform.position;
        BaseBottomBezierHandlB = BottomBezierHandlB.transform.position;

        //Debug.Log("base top: " + BaseTopLeft);
    }

    // Update is called once per frame
    void Update()
    {
        _RenderTextureWarp.cornerOffsetTL = TopLeft.transform.position - BaseTopLeft;
        _RenderTextureWarp.cornerOffsetTR = TopRight.transform.position - BaseTopRight;
        _RenderTextureWarp.cornerOffsetBR = BottomRight.transform.position - BaseBottomRight;
        _RenderTextureWarp.cornerOffsetBL = BottomLeft.transform.position - BaseBottomLeft;

        _RenderTextureWarp.topBezierHandleA = TopBezierHandlA.transform.position - TopLeft.transform.position;
        _RenderTextureWarp.topBezierHandleB = TopBezierHandlB.transform.position - TopRight.transform.position;
        _RenderTextureWarp.leftBezierHandleA = LeftBezierHandlA.transform.position - BottomLeft.transform.position;
        _RenderTextureWarp.leftBezierHandleB = LeftBezierHandlB.transform.position - TopLeft.transform.position;
        _RenderTextureWarp.rightBezierHandleA = RightBezierHandlA.transform.position - TopRight.transform.position;
        _RenderTextureWarp.rightBezierHandleB = RightBezierHandlB.transform.position - BottomRight.transform.position;
        _RenderTextureWarp.bottomBezierHandleA = BottomBezierHandlA.transform.position - BottomRight.transform.position;
        _RenderTextureWarp.bottomBezierHandleB = BottomBezierHandlB.transform.position - BottomLeft.transform.position;

        if (Input.GetKey(KeyCode.R))
        {
            TopLeft.transform.position = new Vector3(-IMAGE_WIDTH2, IMAGE_HEIGHT2, -0.01f);
            TopRight.transform.position = new Vector3(IMAGE_WIDTH2, IMAGE_HEIGHT2, -0.01f);
            BottomRight.transform.position = new Vector3(IMAGE_WIDTH2, -IMAGE_HEIGHT2, -0.01f);
            BottomLeft.transform.position = new Vector3(-IMAGE_WIDTH2, -IMAGE_HEIGHT2, -0.01f);

            TopBezierHandlA.transform.position = TopLeft.transform.position + new Vector3(IMAGE_WIDTH2 * 2.0f / 3.0f, 0, -0.01f);
            TopBezierHandlB.transform.position = TopRight.transform.position + new Vector3(-IMAGE_WIDTH2 * 2.0f / 3.0f, 0, -0.01f);
            LeftBezierHandlA.transform.position = BottomLeft.transform.position + new Vector3(0, IMAGE_HEIGHT2 * 2.0f / 3.0f, -0.01f);
            LeftBezierHandlB.transform.position = TopLeft.transform.position + new Vector3(0, -IMAGE_HEIGHT2 * 2.0f / 3.0f, -0.01f);
            RightBezierHandlA.transform.position = TopRight.transform.position + new Vector3(0, -IMAGE_HEIGHT2 * 2.0f / 3.0f, -0.01f);
            RightBezierHandlB.transform.position = BottomRight.transform.position + new Vector3(0, IMAGE_HEIGHT2 * 2.0f / 3.0f, -0.01f);
            BottomBezierHandlA.transform.position = BottomRight.transform.position + new Vector3(-IMAGE_WIDTH2 * 2.0f / 3.0f, 0, -0.01f);
            BottomBezierHandlB.transform.position = BottomLeft.transform.position + new Vector3(IMAGE_WIDTH2 * 2.0f / 3.0f, 0, -0.01f);

        }
    }
}
