using Shooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter {
	public class Durability : MonoBehaviour {

		[SerializeField] private float _totalValue;
		[SerializeField] private float _value;
		[SerializeField] private AbstractDestructable _destructable;

		public void Damage(float damage) {
			_value = Mathf.Clamp(_value - damage, 0f, _totalValue);
			if (_value <= 0f) {
				if (_destructable != null) {
				}
			}
		}
	}
}