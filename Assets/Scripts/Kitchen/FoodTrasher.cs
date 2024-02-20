using System.Collections;
using UnityEngine;
using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
        
        bool _isDoubleClick = false;
        float _doubleClickThreshold = 0.3f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if ( _place.CurFood == null ) return;
			OnClick();
		}

		void OnClick() {
			if (!_isDoubleClick) {
				_isDoubleClick = true;
				StartCoroutine(ResetDoubleClick());
			}
			else {
				_isDoubleClick = false;
				if (_place.CurFood.CurStatus != Food.FoodStatus.Overcooked) return;
				_place.FreePlace();
			}
		}

		IEnumerator ResetDoubleClick() {
			yield return new WaitForSeconds(_doubleClickThreshold);
			_isDoubleClick = false;
		}
	}
}
