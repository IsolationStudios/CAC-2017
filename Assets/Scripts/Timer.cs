using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Queues and executes functions in fixed time
 */

public class Timer : MonoBehaviour {
	public int fixedUpdateVal = 0;

	public delegate void Command();
	public Command fixedCmd;
	public List<Command> cmdList = new List<Command> ();
	public List<int> cmdTimes = new List<int> ();

	void FixedUpdate(){
		// Set cmd
		fixedCmd = cmdList [0];

		// Move onto next cmd
		if (fixedUpdateVal == cmdTimes [0]) {
			// Do nothing if at end
			if (cmdList.Count == 1) {
				fixedCmd = DoNothing;
				return;
			}

			cmdList.RemoveAt (0);
			cmdTimes.RemoveAt (0);
			Reset ();
		}

		fixedCmd ();
		fixedUpdateVal++;
	}

	void DoNothing(){
		return;
	}

	public void Reset(){
		fixedUpdateVal = 0;
	}

	public void SetTask(Command task, int time){
		cmdList.Add (task);
		cmdTimes.Add (time);
	}
	public void SetWait(int time){
		cmdList.Add (DoNothing);
		cmdTimes.Add (time);
	}
}
