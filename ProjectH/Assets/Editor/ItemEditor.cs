using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]

public class ItemEditor : Editor
{
	Item subject;

	SerializedProperty regenerationHunger;
	SerializedProperty damage;

	private void OnEnable()
    {
		subject = target as Item;

		regenerationHunger = serializedObject.FindProperty("regnHug");
		damage = serializedObject.FindProperty("damage");

	}

    public override void OnInspectorGUI()
    {
		serializedObject.Update();
		DrawDefaultInspector();
		if (subject.Type == Item.typeItem.Food)
		{
			//����� � �������� ��������
			EditorGUILayout.PropertyField(regenerationHunger);

		}
		if (subject.Type == Item.typeItem.Weapon)
		{
			//����� � �������� ��������
			EditorGUILayout.PropertyField(damage);

		}
		serializedObject.ApplyModifiedProperties();
	}
}
