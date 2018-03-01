using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SectionAttribute))]
public class SectionDrawer : PropertyDrawer {

	private const string Tag = "<b>Section Attribute</b> - ";

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		SectionAttribute section = attribute as SectionAttribute;

		Color fadedText = GUI.color;
		fadedText.a = 0.75f;

		GUIStyle headerStyle = new GUIStyle(EditorStyles.whiteLargeLabel) { richText = true };
		GUIStyle messageStyle = new GUIStyle(EditorStyles.whiteMiniLabel) {
			richText = true,
			normal = { textColor = fadedText }
		};

		// Calculate title Rect
		Rect titleRect = position;
		titleRect.x -= 2;
		titleRect.y += 13;
		titleRect.height = 18;

		// Check if an icon is included and draw it with the title
		if (!string.IsNullOrEmpty(section.IconPath)) {
			Texture icon = AssetDatabase.LoadAssetAtPath<Texture>(section.IconPath);
			if (icon == null) {
				Debug.LogWarning(Tag + "The icon for this section cannot be found. Check the path.");
				EditorGUI.LabelField(titleRect, section.Title, headerStyle);
			} else {
				EditorGUI.LabelField(titleRect, new GUIContent(section.Title, icon), headerStyle);
			}
		} else {
			EditorGUI.LabelField(titleRect, section.Title, headerStyle);
		}

		// Check if a description is included and draw it
		if (!string.IsNullOrEmpty(section.Description)) {
			Rect descRect = titleRect;
			descRect.y += 15;
			EditorGUI.LabelField(descRect, section.Description, messageStyle);
		}

		// Calculate separator Rect
		Rect separatorRect = position;
		separatorRect.y += string.IsNullOrEmpty(section.Description) ? 30 : 42;
		separatorRect.height = 1.5f;

		// Check if separator is enabled and draw it
		if (section.Separator) {
			GUI.Box(separatorRect, "");
		}

		// Calculate PropertyField Rect
		Rect propertyPos = separatorRect;
		propertyPos.y += 10;
		propertyPos.height = 16;

		// Draw property
		EditorGUI.PropertyField(propertyPos, property);

//		Use Handles instead of a GUI.Box (Keeps flashing on scroll as of 2017.3, don't use)
//		Handles.BeginGUI();
//		Handles.color = Color.grey;
//		Handles.DrawLine(new Vector2(posLine.x, posLine.y), new Vector2(EditorGUIUtility.currentViewWidth - 21, posLine.y));
//		Handles.EndGUI();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		SectionAttribute section = attribute as SectionAttribute;
		return string.IsNullOrEmpty(section.Description) ? 56 : 68;
	}
}