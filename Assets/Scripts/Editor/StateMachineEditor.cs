using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Ebac.StateMachine;

[CustomEditor(typeof(FSMExample))]
public class StateMachineEditor : Editor
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FSMExample fsm = (FSMExample)target;

        EditorGUILayout.LabelField("State Machine");

        if (fsm.stateMachine == null) return;

        if (fsm.stateMachine.CurrentState != null)
            EditorGUILayout.LabelField("Current Sate: ", fsm.stateMachine.CurrentState.ToString());

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaible States");

        if (showFoldout)
        {
            if(fsm.stateMachine.dicionaryStates != null)
            {
                var keys = fsm.stateMachine.dicionaryStates.Keys.ToArray();
                var values = fsm.stateMachine.dicionaryStates.Values.ToArray();
                    
                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], values[i]));
                }
            }
        }
    }
}
