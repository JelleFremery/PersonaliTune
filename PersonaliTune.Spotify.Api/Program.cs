using PersonaliTune.Spotify.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddTransient<ISpotifyService, SpotifyService>();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7238")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("MyCorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

