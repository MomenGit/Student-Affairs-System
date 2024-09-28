/*using System.Text.Json;
using Microsoft.AspNetCore.Components;
using StudentAffairsSystem.AdminWebApp.Services;
using Users.Entities;

namespace StudentAffairsSystem.AdminWebApp.Components.Pages;

public partial class Users
{
    private string? _searchString = "";

    private List<User> _user = new();
    [SupplyParameterFromForm] private User? Model { get; set; }
    [Inject] public IUserService? UserService { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new User();
    }

    protected override async Task OnInitializedAsync()
    {
        IEnumerable<User>? iStudents = await UserService!.GetAllUsersAsync();
        _user = iStudents!.ToList();
        await base.OnInitializedAsync();
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        //TODO:: using HttpClient call https://students.innopack.app/api/students to fill students
        // if (firstRender)
        // {
        //     IEnumerable<ApiStudent> iStudents = await StudentService!.GetAllAsync();
        //     _students = iStudents.ToList();
        //     StateHasChanged();
        // }

        if (firstRender && !_user.Any())
        {
            Model!.FirstName = "Wael";
            Model!.LastName = "Shehab Eldin";
            Model!.PhoneNumber = "01207888335";
            Model!.Email = "wael@innotech.com.eg";

            StateHasChanged();
        }
    }

    private void Submit()
    {
        Logger.LogInformation("Id = {Id}", Model?.Id);
        string studentSerialized = JsonSerializer.Serialize(Model);
        User? validStudent = JsonSerializer.Deserialize<User>(studentSerialized);
        if (validStudent is not null)
            _user.Add(validStudent);
        //Search With name if exits get it by index and edit it in list if not add it to list
        //TODO:: using HttpClient call https://students.innopack.app/api/students
    }

    private void EditStudent(User toBeEditedStudent)
    {
        Model = toBeEditedStudent;

        StateHasChanged();
    }

    private void SearchByName()
    {
        User? result = _user.Find(item => item.FirstName == _searchString);
        if (result is not null) _user = [result];
        StateHasChanged();
    }
}*/

