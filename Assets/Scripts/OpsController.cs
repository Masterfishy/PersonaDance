using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class OpsController : MonoBehaviour
{
    public DeathEvent DeathEvent;
    public SpawnEvent SpawnEvent;
    public GameObject SwanPrefab;

    private void OnEnable()
    {
        if (DeathEvent != null)
        {
            DeathEvent.OnEventRaised += OnTargetDeath;
        }
    }

    private void OnDisable()
    {
        if (DeathEvent != null)
        {
            DeathEvent.OnEventRaised -= OnTargetDeath;
        }
    }

    public void OnTargetDeath()
    {
        SpawnSwan();
    }

    public void SpawnSwan()
    {
        if (SwanPrefab == null)
            return;

        // Create a swan
        GameObject go = Instantiate(SwanPrefab, transform.position, Quaternion.identity, transform);

        Poser poser = go.GetComponent<Poser>();
        if (poser != null && SpawnEvent != null)
        {
            SpawnEvent.RaiseEvent(poser);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(OpsController))]
public class OpsControllerEditor : Editor
{
    public SerializedProperty DeathEventProp;
    public SerializedProperty SpawnEventProp;
    public SerializedProperty SwanPrefabProp;

    private void OnEnable()
    {
        DeathEventProp = serializedObject.FindProperty("DeathEvent");
        SpawnEventProp = serializedObject.FindProperty("SpawnEvent");
        SwanPrefabProp = serializedObject.FindProperty("SwanPrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(DeathEventProp);
        EditorGUILayout.PropertyField(SpawnEventProp);
        EditorGUILayout.PropertyField(SwanPrefabProp);

        serializedObject.ApplyModifiedProperties();

        OpsController targetEvent = target as OpsController;

        if (GUILayout.Button("Spawn Swan"))
        {
            targetEvent.SpawnSwan();
        }
    }
}
#endif
