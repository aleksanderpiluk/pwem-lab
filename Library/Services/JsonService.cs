namespace Library.Services;

using System;
using Library.Models;
using Newtonsoft.Json;

public class JsonService
{
	private readonly IWebHostEnvironment _env;
	public string FilePath { get; set; }


	public JsonService(IWebHostEnvironment env)
	{
		_env = env;
		FilePath = "";
	}

	public void SetFilePath(string fileName)
	{
		FilePath = Path.Combine(_env.ContentRootPath, "Data", fileName);
	}


	public List<T> GetAll<T>() where T : JsonEntryModel
	{
		if (!File.Exists(FilePath))
		{
			return [];
		}

		var json = File.ReadAllText(FilePath);
		var list = JsonConvert.DeserializeObject<List<T>>(json);
		return list ?? [];
	}

	public void Add<T>(T item) where T : JsonEntryModel
	{
		List<T> list = GetAll<T>();
		list.Add(item);
		SaveToFile(list);
	}

	public void Edit<T>(T updatedItem) where T : JsonEntryModel
	{
		List<T> list = GetAll<T>();
		var bookIndex = list.FindIndex(b => b.id == updatedItem.id);
		if (bookIndex != -1)
		{
			list[bookIndex] = updatedItem;
			SaveToFile(list);
		}
	}
	public void Delete<T>(T item) where T : JsonEntryModel
	{
		List<T> list = GetAll<T>();
		list.Remove(item);
		SaveToFile(list);
	}

	private void SaveToFile<T>(List<T> list) where T : JsonEntryModel
	{
		var json = JsonConvert.SerializeObject(list, Formatting.None);
		File.WriteAllText(FilePath, json);
	}

}
