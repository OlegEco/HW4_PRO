var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}");

app.Run();



//Использование контроллеров в архитектуре MVC для обработки GET-запросов Задание
//1. Создать проект ASP.Net Core, предусмотрев в нем поддержку механизмов реализации
//шаблона MVC (например, добавить поддержку MVC в пустой проект).
//2. Используя контроллеры, реализовать обработку GET-запросов, обеспечив следующую
//функциональность приложения:
//-Приложение должно обрабатывать GET-запросы с указанным значением параметра name.
//А именно, для нескольких (минимум трех!) фиксированных значений этого параметра
//должна отображаться информация про пользователя с соответствующими именем. Необходимо
//также предусмотреть обработку ситуации, когда параметр name в запросе не передан или
//если значение этого параметра не определено.
//- Если в запросе передается параметр color с корректно указанным названием цвета, то
//цвет должен применяться для отображения информации на странице, которая является ответом на запрос.