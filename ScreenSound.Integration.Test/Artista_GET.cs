using ScreenSound.API.Requests;
using ScreenSound.Modelos;
using System.Net.Http.Json;

namespace ScreenSound.Integration.Test;

public class Artista_GET:IClassFixture<ScreenSoundWebApplicationFactory>
{
    private readonly ScreenSoundWebApplicationFactory app;

    public Artista_GET(ScreenSoundWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task Recupera_Artista_Por_Nome()
    {
        //Arrange
        var artistaExistente = app.Context.Artistas.FirstOrDefault();
        if (artistaExistente is null) { 
        
          artistaExistente = new Artista() { Nome = "João Silva", Bio = "Nascido em SP." };
          app.Context.Add(artistaExistente);
          app.Context.SaveChanges();
        }

        using var client = app.CreateClient();

        //Act
        var response = await client.GetFromJsonAsync<Artista>("/Artistas/" + artistaExistente.Nome);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(artistaExistente.Id, response.Id);
        Assert.Equal(artistaExistente.Nome, response.Nome);

    }
}
