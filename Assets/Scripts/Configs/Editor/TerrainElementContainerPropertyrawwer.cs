using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TerrainElementContainer))]
public class TerrainElementContainerPropertyDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    var indent = EditorGUI.indentLevel;
    var half = position.width / 2.0f;
    var nameRect = new Rect(position.x, position.y, half, position.height);
    var pointRect = new Rect(position.x + 5 + half, position.y, position.width / 2.0f, position.height);

    EditorGUI.BeginProperty(position, label, property);

    EditorGUI.indentLevel = 0;
    EditorGUI.PropertyField(pointRect, property.FindPropertyRelative("Prefab"), GUIContent.none);
    EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("Elements"), GUIContent.none);
    EditorGUI.indentLevel = indent;

    EditorGUI.EndProperty();
  }
}

[CustomPropertyDrawer(typeof(KVContainer<,>))]
public class KVContainerPropertyDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

    var indent = EditorGUI.indentLevel;
    var half = position.width / 2.0f;
    var KeyRect = new Rect(position.x, position.y, half, position.height);
    var ValueRect = new Rect(position.x + 5 + half, position.y, position.width / 2.0f, position.height);

    EditorGUI.BeginProperty(position, label, property);

    EditorGUI.indentLevel = 0;

    EditorGUI.PropertyField(KeyRect, property.FindPropertyRelative("Key"), GUIContent.none);
    EditorGUI.PropertyField(ValueRect, property.FindPropertyRelative("Value"), GUIContent.none);

    EditorGUI.indentLevel = indent;

    EditorGUI.EndProperty();
  }
}
