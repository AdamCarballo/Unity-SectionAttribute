using UnityEngine;

public class SectionAttributeTutorial : MonoBehaviour {

	private const string Path = "Assets/Unity-SectionAttribute/Scripts/Demo/";

	[Section("How to use Section Attributes", "Add a [Section] attribute on top of any field and it will be drawn like a header")]
	public int PublicIntField;
	public int AntoherUnreleatedField;

	[Section("What fields work with it?", "Should work with any field, but keep in mind that will use PropertyField to draw it")]
	public string PublicStringField;
	public GameObject AGameObjectField;

	[Section("What data can be passed?", "A title is mandatory. Optional is description, an icon path and separator toggle")]
	public AudioClip RandomAudioClipField;

	[Section("Section with only a title")]
	public string LookAtThatTitle;

	[Section(" Section with an icon", iconPath: Path + "GitHub-Mark-Light-64px.png")]
	public string LookAtThatIcon;

	[Section(" Section with an icon", "And also a description", Path + "GitHub-Mark-Light-64px.png")]
	public string LookAtThatDescIcon;

	[Section("Section without separator", separator: false)]
	public string GetRidOfSeparators;

	[Section("Section without separator", "But with a nice description to go along", separator: false)]
	public string NiceDescription;

	[Section(" Section with all parameters", "A title, a description, an icon and without a separator", Path + "GitHub-Mark-Light-64px.png", false)]
	public string LookAtThatCombination;

	[Section("What about <b>Markup</b>?", "<color=lime>You can use <b><color=red>any</color></b> tags that <color=yellow>Unity</color> supports with rich text!</color> <i>Don't use size though</i>")]
	public GameObject MarkupGalore;

	[Section("What about Serialized Fields?", "Sure. This is just a normal attribute like any other")]
	[SerializeField]
	private int ThisFieldIsPrivate;

	[Section("What about multiple attributes?", "This field is using Section and Tootlip. Hover your mouse over the field!")]
	[Tooltip("It's a secret")]
	public float RandomFloatField;

	[Section("That's it!", "Edit this script to see all the code examples. Code time!")]
	public bool YouAreDone;
}