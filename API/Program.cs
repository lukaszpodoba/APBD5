using API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IAnimalDb, AnimalDb>();
builder.Services.AddSingleton<IVisitDb, VisitDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IAnimalDb animalDb) =>
{
    return Results.Ok(animalDb.PrintAllAnimals());
});

app.MapGet("/animals/{id:int}", (IAnimalDb animalDb, int id) =>
{
    var animal = animalDb.AnimalById(id);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/animals", (IAnimalDb animalDb, Animal animal) =>
{
    animalDb.AddAnimal(animal);
    return Results.Created("Created", animal);
});

app.MapPut("/animals/{id:int}/", (IAnimalDb animalDb, int id, Animal animal) =>
{
    var exists = animalDb.AnimalById(id);
    if (exists == null)
    {
        return Results.NotFound();
    }
    animalDb.UpdateAnimal(id, animal);
    return Results.NoContent();
});

app.MapDelete("/animals/{id:int}", (IAnimalDb animalDb, int id) =>
{
    var exists = animalDb.AnimalById(id);
    if (exists == null)
    {
        return Results.NotFound();
    }
    animalDb.DeleteAnimal(exists);
    return Results.NoContent();
});

app.MapGet("/visit/{id:int}", (IVisitDb visitDb, int id) =>
{
    var visit = visitDb.PreviousVisits(id);
    if (visit.Count == 0)
    {
        return Results.NotFound();
    }
    return Results.Ok(visit);
});

app.MapPost("/visit", (IVisitDb visitDb, Visit visit) =>
{
    visitDb.AddVisit(visit);
    return Results.Created();
});

app.MapControllers();
app.Run();