using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

/*
 * Forwards game inputs into PlatformCharacter2D
 */

[RequireComponent(typeof (PlatformerCharacter2D))]
public class PlayerController : MonoBehaviour {

	private PlatformerCharacter2D m_Character;
	private bool m_Jump;

	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			//m_Jump = gM.upDown;
		}
	}


	private void FixedUpdate()
	{

		if (GameState.playerState == GameState.State.Moving) {
			// Read the inputs.
			//bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = GameState.GetAxis ("Horizontal");
			// Pass all parameters to the character control script.
			m_Character.Move (h, false, m_Jump);
			m_Jump = false;
		}
	}
}
