using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

public class ToDoController : Controller {
    public IActionResult Index() {
        var model = getModelFromSession();
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(ToDoModel.ToDoItemModel itemModel) {
        var model = getModelFromSession();
        model.Items.Add(itemModel);
        HttpContext.Session.SetString("todo_list", JsonSerializer.Serialize(model));
        
        var url = Url.Action("Index");
        return new RedirectResult(url, false, true); 
    }

    [HttpPost]
    public IActionResult Remove(ToDoIndexModel indexModel) {
        var model = getModelFromSession();
        
        model.Items.RemoveAt(indexModel.Index);
        HttpContext.Session.SetString("todo_list", JsonSerializer.Serialize(model));
        
        var url = Url.Action("Index");
        return new RedirectResult(url, false, true); 
    }


    [HttpPost]
    public IActionResult Done(ToDoIndexModel indexModel) {
        var model = getModelFromSession();
        
        model.Items.ElementAt(indexModel.Index).Done = true;
        HttpContext.Session.SetString("todo_list", JsonSerializer.Serialize(model));
        
        var url = Url.Action("Index");
        return new RedirectResult(url, false, true); 
    }

    private ToDoModel getModelFromSession() {
        var session_content = HttpContext.Session.GetString("todo_list");
        if(session_content != null) {
            var model = JsonSerializer.Deserialize<ToDoModel>(session_content);
            return model!;
        } else {
            var model = new ToDoModel();
            return model;
        }
    }
}