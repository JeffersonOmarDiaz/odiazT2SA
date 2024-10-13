namespace odiazT2SA.Views;

public partial class StudenScore : ContentPage
{
	public StudenScore()
	{
		InitializeComponent();
	}

    private void btnCalificar_Clicked(object sender, EventArgs e)
    {
        if (pickerList.SelectedIndex == -1)
        {

            DisplayAlert("Cerrar", "Seleccione un estudiante", "cerrar");
            return;
        }
        // Intentar obtener los números de las entradas
        if (double.TryParse(txtNotaSeg1.Text, out double notaSeg1) &&
            double.TryParse(txtNotaExamen1.Text, out double notaExa1) &&
            double.TryParse(txtNotaSeg2.Text, out double notaSeg2) &&
            double.TryParse(txtNotaExamen2.Text, out double notaExa2))
        {
            /*if(notaSeg1 >= 0 && notaSeg1 <= 10 && notaExa1 >= 0 && notaExa1 <= 10)
            {
                DisplayAlert("Error", "Por favor, HOLIIIIIIIIIIIIIII.", "OK");
            }*/
            if (validateValuesScore(notaSeg1) && 
                validateValuesScore(notaExa1) &&
                validateValuesScore(notaSeg2) &&
                validateValuesScore(notaExa2))
            {
                notaSeg1 = notaSeg1 * (0.3);
                notaExa1 = notaExa1 * (0.2);
                txtNotaP1.Text =  (notaSeg1 + notaExa1).ToString("F2");
                
                notaSeg2 = notaSeg2 * (0.3);
                notaExa2 = notaExa2 * (0.2);
                txtNotaP2.Text =  (notaSeg2 + notaExa2).ToString("F2");
            
                txtNotaTotal.Text = (Convert.ToDouble(txtNotaP1.Text) + Convert.ToDouble(txtNotaP2.Text)).ToString("F2");
                this.showStatus(Convert.ToDouble(txtNotaTotal.Text));
            }
        }
        else
        {
            DisplayAlert("Error", "Por favor, asegúrese de que ambos campos contengan números válidos.", "OK");
        }

    }

    private void showStatus(double totalScore)
    {
        string estudiante;
        if (Convert.ToDouble(txtNotaTotal.Text) >= 7)
        {
            txtEstadoAprobacion.Text = "Aprobado";
        }
        else if (Convert.ToDouble(txtNotaTotal.Text) >= 5 && Convert.ToDouble(txtNotaTotal.Text) < 7)
        {
            txtEstadoAprobacion.Text = "Complementario";
        }
        else
        {
            txtEstadoAprobacion.Text = "Reprobado";
        }

        estudiante = pickerList.Items[pickerList.SelectedIndex];

        DisplayAlert("Calificación", 
            "Nombre: " + estudiante + "\n" +
            "Fecha: " + dFechas.Date.ToString("dd/MM/yyyy") + "\n" +
            "Nota Parcial 1: " + txtNotaP1.Text + "\n" +
            "Nota Parcial 2: " + txtNotaP2.Text + "\n" +
            "Nota Final: " + txtNotaTotal.Text + "\n" +
            "Estado: " + txtEstadoAprobacion.Text + "\n" 
            , "OK");
    }

    private bool validateValuesScore(double scores)
    {
        if (scores >= 0 && scores <= 10)
        {
            return true;
        }
        else
        {
            DisplayAlert("Error", "Por favor, asegúrese que todos campos contengan números válidos entre 0 y 10", "OK");
            return false;
        }
    }
    private void scoreValues_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        // Intentar convertir el texto a número decimal
        if (!double.TryParse(entry.Text, out double _) && entry.Text != null && entry.Text != "")
        {
            DisplayAlert("Entrada inválida", "Por favor, ingrese solo números válidos (enteros o decimales).", "OK");
        }
    }

}