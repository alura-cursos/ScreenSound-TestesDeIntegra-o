using ScreenSound.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.Modelos;

namespace ScreenSound.Integration.Test;
public class Artista_PUT:IClassFixture<ScreenSoundWebApplicationFactory>
{
    private readonly ScreenSoundWebApplicationFactory app;

    public Artista_PUT(ScreenSoundWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task Atualiza_Artista()
    {
        //Arrange
        var artistaExistente = app.Context.Artistas.FirstOrDefault();
        if (artistaExistente is null)
        {
            artistaExistente = new Artista("João Arthur", "Artista de pagode carioca.");      
            app.Context.Add(artistaExistente);
            app.Context.SaveChanges();
        }

        using var client = app.CreateClient();

        artistaExistente.Nome = "João Arthur. [Atualizado]";
        artistaExistente.Bio = "Artista de pagode carioca. [Atualizada]";
        //Act
        var response = await client.PutAsJsonAsync($"/Artistas", new ArtistaRequestEdit(artistaExistente.Id,artistaExistente.Nome,artistaExistente.Bio));

        //Assert
        //Assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
}
