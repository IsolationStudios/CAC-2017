using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Combo lock counter
 */

namespace GameUI {
	public class DigitCounter : MonoBehaviour {

		private Button upBtn;
		private Button downBtn;
		private Text digitText;
		private int val;
		public int Val {
			get{
				return val;
			}
		}

		void Start () {
			upBtn = transform.Find ("Up").GetComponent<Button> ();
			downBtn = transform.Find ("Down").GetComponent<Button> ();
			digitText = transform.Find ("Digit").GetComponent<Text> ();
			val = 0;

			upBtn.onClick.AddListener (Incr);
			downBtn.onClick.AddListener (Decr);
		}

		public void Incr(){
			val++;
			val = (val + 10) % 10;
			digitText.text = val.ToString();
		}
		public void Decr(){
			val--;
			val = (val + 10) % 10;
			digitText.text = val.ToString();
		}
		public void Revert(){
			val = 0;
			digitText.text = val.ToString();
		}
		

	}
}