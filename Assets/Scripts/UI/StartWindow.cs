using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// For saving project structure was made same as WinWindow and LoseWindow
public class StartWindow : MonoBehaviour {
	[SerializeField] TMP_Text goalText = null;
	[SerializeField] Button startButton = null;

	bool _isInit = false;

	void Init() {
		var gc = GameplayController.Instance;

		startButton.onClick.AddListener(gc.GameStart);
	}

	public void Show() {
		if ( !_isInit ) {
			Init();
		}

		var gc = GameplayController.Instance;
		goalText.text = $"Блюда: {gc.OrdersTarget}";

		gameObject.SetActive(true);
	}

	public void Hide() {
		gameObject.SetActive(false);
	}
}