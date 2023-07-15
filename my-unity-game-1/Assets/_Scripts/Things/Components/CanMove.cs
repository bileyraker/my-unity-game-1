using System.Collections;
using UnityEngine;

namespace Birdy.Things.Components
{
	public class CanMove : MonoBehaviour
	{
		[SerializeField]
		private float _baseSpeed;

		// TODO: Implement speed modifiers
		[SerializeField]
		private float _speed;

		public float MoveSpeed { get { return _speed; } set { _speed = value; } }
		public Vector3 PositionTarget { get; set; }

		// Use this for initialization
		void Start()
		{
			PositionTarget = transform.position;
		}

		// Update is called once per frame
		void Update()
		{
			UpdatePosition();
		}

		// TODO: Move all of this to a pathfinder once the map is more defined.
		private void UpdatePosition()
		{
			if (PositionTarget == transform.position) { return; }

			Vector3 deltaPos = (PositionTarget - transform.position);

			if (deltaPos.magnitude > _speed * Time.deltaTime)
			{
				Vector3 toMove = deltaPos.normalized * _speed * Time.deltaTime;
				transform.position = transform.position + toMove;
			}
			else
			{
				transform.position = PositionTarget;
			}
		}
	}
}