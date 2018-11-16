using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS
{
	public class SpaceshipSystem : ComponentSystem
	{
		struct Group
		{
			// Unityのため必ず追加する
			public readonly int Length;
			
			// Componentの配列
			public ComponentDataArray<Position> Positions;
			public ComponentDataArray<Rotation> Rotations;
			public ComponentDataArray<Speed> Speeds;
		}

		// 依頼を決める
		[Inject]
		private Group _group;

		protected override void OnUpdate()
		{
			for (int i = 0; i < _group.Length; i++)
			{
				var position = _group.Positions[i];
				// 位置計算
				position.Value += _group.Speeds[i].Value * Time.deltaTime * math.forward(_group.Rotations[i].Value);

				if (position.Value.z < Const.BottomBound)
				{
					position.Value.z = Const.TopBound;
				}
				// 計算終了
				_group.Positions[i] = position;
			}
		}
	}
}

