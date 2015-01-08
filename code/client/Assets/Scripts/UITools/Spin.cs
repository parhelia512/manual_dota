using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    public Transform Target;

    public bool isRightRotate = true;
    public bool ignoreTimeScale = false;

    public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

    private Transform mTrans;
    private Rigidbody mRb;

    void Start () 
    {
       Init();
	}
	
	void Update () 
    {
        ApplyDelta(ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
	}

    private void Init()
    {
        mTrans = transform;
        mRb = rigidbody;

        if (Target != null)
            mTrans = Target;
        else
        {
            mTrans = this.transform;         
        }
    }

    

    public void ApplyDelta(float delta)
    {
        //表示方向，向右转还是向左转
        float dir = isRightRotate ? -1f : 1f;

        delta *= Mathf.Rad2Deg * Mathf.PI * 2f * dir;       

        Quaternion offset = Quaternion.Euler(rotationsPerSecond * delta);

        if (mRb == null)
        {
            mTrans.rotation = mTrans.rotation * offset;
        }
        else
        {
            mRb.MoveRotation(mRb.rotation * offset);
        }
    }

}
