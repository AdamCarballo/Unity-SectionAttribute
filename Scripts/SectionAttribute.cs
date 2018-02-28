using UnityEngine;

public class SectionAttribute : PropertyAttribute {

	public string Title { get; private set; }
	public string Description { get; private set; }
	public string IconPath { get; private set; }
	public bool Separator { get; private set; }


	public SectionAttribute(string title, string description = null, string iconPath = null, bool separator = true) {
		Title = title;
		Description = description;
		IconPath = iconPath;
		Separator = separator;
	}
}