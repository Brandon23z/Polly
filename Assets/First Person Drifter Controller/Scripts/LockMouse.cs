// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{	
	void Start()
	{
		LockCursor(true);
	}

    void Update()
    {
    	// lock when mouse is clicked
    	if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
    	{
    		LockCursor(true);
    	}
    
    	// unlock when P is hit
        if  ( Input.GetKeyDown(KeyCode.P) )
        {
        	LockCursor(!Screen.lockCursor);
        }
    }
    
    public void LockCursor(bool lockCursor)
    {
    	Screen.lockCursor = lockCursor;
    }
}