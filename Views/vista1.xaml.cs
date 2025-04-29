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
            DisplayAlert("Error", "Seleccione un tipo de identificación.", "Cerrar");
            return;
        }

        string tipoIdentificacion = pkIdentificacion.SelectedItem?.ToString() ?? "No seleccionado";
        string numeroIdentificacion = txtIdentificacion.Text;

        if (string.IsNullOrWhiteSpace(numeroIdentificacion))
        {
            DisplayAlert("Error", "Ingrese el número de identificación.", "Cerrar");
            return;
        }

        if (tipoIdentificacion == "CI")
        {
            if (numeroIdentificacion.Length != 10 || !numeroIdentificacion.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese el CI", "Cerrar");
                return;
            }
        }
        else if (tipoIdentificacion == "RUC")
        {
            if (numeroIdentificacion.Length != 13 || !numeroIdentificacion.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese el RUC", "Cerrar");
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(txtNombres.Text))
        {
            DisplayAlert("Error", "Ingrese su nombre.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtApellidos.Text))
        {
            DisplayAlert("Error", "Ingrese su apellido.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCorreo.Text))
        {
            DisplayAlert("Error", "Ingrese su correo.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSalario.Text) || !decimal.TryParse(txtSalario.Text, out decimal salario) || salario <= 0)
        {
            DisplayAlert("Error", "Ingrese un salario válido mayor a 0.", "OK");
            return;
        }

        Navigation.PushAsync(new vista2(tipoIdentificacion, numeroIdentificacion, txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
        dpkFecha.Date, txtCorreo.Text.Trim(), salario));
    }
}