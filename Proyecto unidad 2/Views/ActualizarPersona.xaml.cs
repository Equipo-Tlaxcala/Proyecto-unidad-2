using Proyecto_unidad_2.Models;
using Proyecto_unidad_2.Services;

namespace Proyecto_unidad_2.Views;

public partial class ActualizarPersona : ContentPage
{
    private Persona _persona;
    private DatabaseService _dbService = new();

    public ActualizarPersona(Persona persona)
    {
        InitializeComponent();
        _persona = persona;

        nombreEntry.Text = _persona.Nombre;
        correoEntry.Text = _persona.Correo;
        telefonoEntry.Text = _persona.Telefono;
    }

    private async void OnActualizarClicked(object sender, EventArgs e)
    {
        _persona.Nombre = nombreEntry.Text;
        _persona.Correo = correoEntry.Text;
        _persona.Telefono = telefonoEntry.Text;

        await _dbService.ActualizarPersonaAsync(_persona);
        await DisplayAlert("Éxito", "Persona actualizada", "OK");
        await Navigation.PopAsync();
    }
}
