using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 0f;		//攝影機與玩家距離多遠時開始跟隨
	public float xSmooth = 8f;		//攝影機跟隨的流暢度
	public float maxX;				//攝影機左邊界
	public float minX;				//攝影機右邊界
	public Transform player;		// 跟隨的物件

	void Update ()
	{
		//Camera的座標
		float targetX = transform.position.x;
				
		//檢查攝影機和玩家是否超出預設開始跟隨的距離
		if(Mathf.Abs(transform.position.x - player.position.x) > xMargin){
		
			//從攝影機X座標和玩家X座標內插中間值
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}
				
		//限制攝影機X座標只能在設定之最大與最小的範圍
		targetX = Mathf.Clamp(targetX, minX, maxX);
				
		//更新攝影機的位置
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}

}
