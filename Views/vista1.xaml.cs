using System.Text.RegularExpressions;

namespace ctrujilloT3.Views;

public partial class vista1 : ContentPage
{
    public vista1()
    {
        InitializeComponent();
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {

        if (pkIdentificacion.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Seleccione de nuevo el tipo de identificación", "Cerrar");
            return;
        }

        string tipoIdentificacion = pkIdentificacion.SelectedItem?.ToString() ?? "No seleccionado";
        string numeroIdentificacion = txtIdentificacion.Text;

        if (string.IsNullOrWhiteSpace(numeroIdentificacion))
        {
            DisplayAlert("Error", "Ingrese de nuevo el numero de identificacion", "Cerrar");
            return;
        }

        if (tipoIdentificacion == "CI")
        {
            if (numeroIdentificacion.Length != 10 || !numeroIdentificacion.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese de nuevo el CI", "Cerrar");
                return;
            }
        }
        else if (tipoIdentificacion == "RUC")
        {
            if (numeroIdentificacion.Length != 13 || !numeroIdentificacion.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese de nuevo el RUC", "Cerrar");
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(txtNombres.Text) || !txtNombres.Text.All(c => char.IsLetter(c) || c == ' '))
        {
            DisplayAlert("Error", "Ingrese de nuevo los nombres", "Cerrar");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtApellidos.Text) || !txtApellidos.Text.All(c => char.IsLetter(c) || c == ' '))
        {
            DisplayAlert("Error", "Ingrese de nuevo los apellidos", "Cerrar");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCorreo.Text))
        {
            DisplayAlert("Error", "Ingrese de nuevo el correo", "Cerrar");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSalario.Text) || !decimal.TryParse(txtSalario.Text, out decimal salario) || salario <= 0)
        {
            DisplayAlert("Error", "Ingrese de nuevo el salario", "Cerrar");
            return;
        }

        Navigation.PushAsync(new vista2(tipoIdentificacion, numeroIdentificacion, txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
        dpkFecha.Date, txtCorreo.Text.Trim(), salario));
    }
}