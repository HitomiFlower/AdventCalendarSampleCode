using System;
using Unity.Entities;

namespace ECS
{
	[Serializable]
	public struct Speed : IComponentData
	{
		public float Value;
	}

	[UnityEngine.DisallowMultipleComponent]
	public class SpeedComponent : ComponentDataWrapper<Speed>
	{
	}
}

