using System;
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

[CustomEditor(typeof(TerrainElementsScriptableObject))]
public class ScriptableObject_PropertyDrawer : Editor {

  TerrainElementsScriptableObject comp;

  public void OnEnable() {
    comp = (TerrainElementsScriptableObject) target;
  }

  public override void OnInspectorGUI() {
    if (GUILayout.Button("Parse Key From Name")) ParseEnumFromName();
    base.OnInspectorGUI();
  }


  private void ParseEnumFromName() {
    for (var i = 0; i < comp.Elements.Length; i++) {
      var n = comp.Elements[i].Prefab.name;
      TileEnvironment mask = TileEnvironment.Self;

      for (var c = 1; c < n.Length; c++) {
        mask |= n[c] switch {
            'S' => TileEnvironment.Self,
            'T' => TileEnvironment.Top,
            'R' => TileEnvironment.Right,
            'D' => TileEnvironment.Down,
            'L' => TileEnvironment.Left,
            't' => TileEnvironment.TopRight,
            'r' => TileEnvironment.RightDown,
            'd' => TileEnvironment.DownLeft,
            'l' => TileEnvironment.LeftTop,
            _ => throw new Exception(comp.Elements[i].Prefab.name)
        };
      }
      comp.Elements[i].Elements = mask;
    }
  }
}
