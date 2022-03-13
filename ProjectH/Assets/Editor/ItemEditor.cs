using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]

public class ItemEditor : Editor
{
	Item subject;

	SerializedProperty regenerationHunger;

    private void OnEnable()
    {
		subject = target as Item;

		regenerationHunger = serializedObject.FindProperty("regnHug");

	}

    public override void OnInspectorGUI()
    {
		serializedObject.Update();
		DrawDefaultInspector();
		if (subject.Type == Item.typeItem.Food)
		{
			//Вывод в редактор слайдера
			EditorGUILayout.PropertyField(regenerationHunger);

		}
		serializedObject.ApplyModifiedProperties();
	}
}
