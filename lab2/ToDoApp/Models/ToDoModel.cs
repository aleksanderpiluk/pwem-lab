namespace ToDoApp.Models;

public class ToDoModel {
    public class ToDoItemModel {
        public string Task { get; set; }
        public bool Done { get; set; } = false;
    }

    public List<ToDoItemModel> Items { get; set; } = [];
}