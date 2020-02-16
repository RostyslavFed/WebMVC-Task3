using System;
using System.Collections.Generic;

namespace WebMVCBlog.Models
{
	public class Summary
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PlaceOfResidence { get; set; }
		public List<string> ProgramingLanguges { get; set; } = new List<string>();
		public string Comment { get; set; }

		public string GetHtmlResult()
		{
			string result = "Отправленые данные\n";
			result += $"Указаное имя: {Name}\n";
			result += $"E-mail: {Email}\n";
			result += $"Место проживания: {PlaceOfResidence}\n";
			result += $"Языки програмирования: {String.Join(",", ProgramingLanguges.ToArray())}.\n";
			result += $"Коментарий: {Comment}\n";

			return putInDivs(result);
		}

		private string putInDivs(string text)
		{
			string result = "";
			foreach (var str in text.Split('\n'))
				result += $"<div>{str}</div>";
			return result;
		}
	}
}