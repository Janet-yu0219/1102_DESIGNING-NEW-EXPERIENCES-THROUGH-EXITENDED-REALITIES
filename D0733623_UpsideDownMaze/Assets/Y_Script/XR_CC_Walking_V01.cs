using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XR_CC_Walking_V01 : MonoBehaviour
{
    public XRNode XRNode; //輸入機制選項列, 等下會選 Left Hand(需有using UnityEngine.XR;)
    public float WalkSpeed = 2.0f;// 移動速度 float 變數
    Vector2 XR_InputAxis; //注意這裡宣告vector2來對應把手的十字按鍵
    CharacterController XR_characterController;
    public GameObject XR_Camera_Object;//掛載VR Camera使用
    
    /// //////////////////////////////////////////////////////////////////////////////////////////////
    
    public float RotateSpeed = 20f;// 移動速度 float 變數
    InputDevice Target_device;
    // Start is called before the first frame update
    void Start()
    {
        XR_characterController = GetComponent<CharacterController>();//就是抓CC元件
        //////////////////////////////////////////////////////////////////////////////////////////////
        Target_device = InputDevices.GetDeviceAtXRNode(XRNode);
    }

    // Update is called once per frame
    private void FixedUpdate()//這裡建議CC程序用FixedUpdate (CC.SimpleMove不需要乘上 Time.FixedDeltime)
    {
        //比之前方式更快速抓到目標裝置的程序, 注意這邊是放在Update區域
        //直接使用指定XRNode方式來抓到目標裝置
        InputDevice W_device = InputDevices.GetDeviceAtXRNode(XRNode); //等下這邊會指定左手把手為目標(需有using UnityEngine.XR;)
        W_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out XR_InputAxis);

        //底下宣告Vector3特別注意z軸向的定義是以vector2的y軸定義
        Vector3 MoveDirection = new Vector3(XR_InputAxis.x, 0, XR_InputAxis.y);//把手XR_InputAxis.x就像是Input.GetAxis("Horizontal")

        //底下使用CC移動的觀念不太一樣: 有一個參照物的Transform角度作為CC移動的參照座標(有如自身坐標系)
        //這時就必須使用Quaternion變數來定義參照物的Transform角度, 再將此Quaternion變數"乘上"原先十字軸定義的移動向量, 成為有如自身坐標系地移動向量
        //此時CC.SimpleMove()或者CC.Move()就直接使用乘完Quaternion變數後的移動向量, 就不需要再使用transform.right切換自身坐標系的方法了
        Quaternion Head_Rotate = Quaternion.Euler(0, XR_Camera_Object.transform.eulerAngles.y, 0);//抓到攝影機的角度Quaternion變數
        MoveDirection = Head_Rotate * MoveDirection * WalkSpeed;
        XR_characterController.SimpleMove(MoveDirection);//不需要再使用transform.right切換自身坐標系的方法了

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        Target_device = InputDevices.GetDeviceAtXRNode(XRNode); //等下這邊會指定左手把手為目標(需有using UnityEngine.XR;)
        Target_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out XR_InputAxis);

        TurnMotion();

    }
    void TurnMotion()
    {
        float TurnMomentturn = XR_InputAxis.x;

        if (TurnMomentturn != 0)
        {
            float Y_Vector = TurnMomentturn;
            transform.Rotate(0, Y_Vector, 0);
        }

    }


}
