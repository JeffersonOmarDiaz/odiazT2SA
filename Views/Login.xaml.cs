namespace odiazT2SA.Views;

public partial class Login : ContentPage
{
    List<string> users = new List<string> {"Omar", "Carlos", "Ana", "Jose" };
    List<string> password = new List<string> { "Omar", "carlos123", "ana123", "jose123" };
    public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

		string nombre = txtName.Text;
		string clave = txtClave.Text;

		if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
		{
            DisplayAlert("Error!", "Engrese todos los datos", "Cerrar");
			return;
        }

		if (this.users.Contains(nombre)) {
			int posicionClave = users.IndexOf(nombre);
			if (clave == this.password[posicionClave])
			{
                //exito para iniciar sesión
                DisplayAlert("Iniciando Sesión", "Bienvedido " + nombre, "Continuar");
                Navigation.PushAsync(new Views.StudenScore());
            }
			else
			{
				DisplayAlert("Error!", "Usuario o contraseña incorrectos", "Cerrar");
				return;
			}
		}
		else
		{
			DisplayAlert("Error!", "Usuario o contraseña incorrectos", "Cerrar");
            return;
        }
    }

}