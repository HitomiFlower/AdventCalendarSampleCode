using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private bool _isInit = false;
	
	private float _speed;

	public float Speed
	{
		get { return _speed; }
		set
		{
			_speed = value;
			_isInit = true;
		}
	}

	private void Update()
	{
		if (!_isInit)
		{
			return;
		}

		var pos = transform.position;
		pos += transform.forward * Speed * Time.deltaTime;

		if (pos.z < Const.BottomBound)
		{
			pos.z = Const.TopBound;
		}

		transform.position = pos;
	}
}
