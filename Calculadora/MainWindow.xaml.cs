using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        

        private bool isDarkMode = false;

        private void btnToggleMode_Click(object sender, RoutedEventArgs e)
        {
            ToggleColorMode();
        }

        private void ToggleColorMode()
        {
            if (isDarkMode)
            {
                // Mudar para modo claro
                Application.Current.MainWindow.Background = ColorPalette.LightBackground;
                Application.Current.MainWindow.Foreground = ColorPalette.LightForeground;
            }
            else
            {
                // Mudar para modo escuro
                Application.Current.MainWindow.Background = ColorPalette.DarkBackground;
                Application.Current.MainWindow.Foreground = ColorPalette.DarkForeground;
            }

            // Inverter o estado do modo
            isDarkMode = !isDarkMode;
        }

        public class ColorPalette
        {
            // Paleta de cores para o modo claro
            public static readonly SolidColorBrush LightBackground = new SolidColorBrush(Colors.White);
            public static readonly SolidColorBrush LightForeground = new SolidColorBrush(Colors.Black);

            // Paleta de cores para o modo escuro
            public static readonly SolidColorBrush DarkBackground = new SolidColorBrush(Colors.Black);
            public static readonly SolidColorBrush DarkForeground = new SolidColorBrush(Colors.White);
        }


        public decimal resultado { get; set; }
        public decimal valor { get; set; }


        private enum Operacao
        {
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao,
            Porcento
        }

        private Operacao OperacaoSelecionada { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "0";
            tbKeyPressedString.Text += "0";

        }

        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "00";
            tbKeyPressedString.Text += "00";
        }

        private TextBlock GetTbEntered_Number()
        {
            return tbEntered_Number;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "1";
            tbKeyPressedString.Text += "1";


        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "2";
            tbKeyPressedString.Text += "2";

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "3";
            tbKeyPressedString.Text += "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "4";
            tbKeyPressedString.Text += "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "5";
            tbKeyPressedString.Text += "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "6";
            tbKeyPressedString.Text += "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "7";
            tbKeyPressedString.Text += "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "8";
            tbKeyPressedString.Text += "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text += "9";
            tbKeyPressedString.Text += "9";
        }

        private void btnAdicao_Click(object sender, RoutedEventArgs e)
        {
            OperacaoSelecionada = Operacao.Adicao;
            valor = Convert.ToDecimal(tbEntered_Number.Text);
            tbEntered_Number.Text = "";
            tbKeyPressedString.Text += "+";

        }

        private void btnSubtracao_Click(object sender, RoutedEventArgs e)
        {
            OperacaoSelecionada = Operacao.Subtracao;
            valor = Convert.ToDecimal(tbEntered_Number.Text);
            tbEntered_Number.Text = "";
            tbKeyPressedString.Text += "-";
        }

        private void btnMultiplicacao_Click(object sender, RoutedEventArgs e)
        {
            OperacaoSelecionada = Operacao.Multiplicacao;
            valor = Convert.ToDecimal(tbEntered_Number.Text);
            tbEntered_Number.Text = "";
            tbKeyPressedString.Text += "x";

        }

        private void btnDivisao_Click(object sender, RoutedEventArgs e)
        {
            {
                // Verifica se o divisor é zero
                if (tbEntered_Number.Text == "0")
                {
                    tbEntered_Number.Text = "ERRO";
                    return; // Saia da função para evitar a divisão por zero
                }

                // Se o divisor não for zero, continue com a operação de divisão
                OperacaoSelecionada = Operacao.Divisao;
                valor = Convert.ToDecimal(tbEntered_Number.Text);
                tbEntered_Number.Text = "";
                tbKeyPressedString.Text += "÷";
            }

        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            switch (OperacaoSelecionada)
            {
                case Operacao.Adicao:
                    resultado = valor + Convert.ToDecimal(tbEntered_Number.Text); break;

                case Operacao.Subtracao:
                    resultado = valor - Convert.ToDecimal(tbEntered_Number.Text); break;

                case Operacao.Multiplicacao:
                    resultado = valor * Convert.ToDecimal(tbEntered_Number.Text); break;

                case Operacao.Divisao:


                    try
                    {
                        resultado = valor / Convert.ToDecimal(tbEntered_Number.Text);
                    }
                    catch (DivideByZeroException ex)
                    {
                        // Handle division by zero exception
                        MessageBox.Show("Error: Cannot divide by zero!", "Calculator Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        // Clear the display or prompt the user for a new divisor (optional)
                        tbEntered_Number.Text = "";
                        return; // Exit the method to prevent further calculations
                    }
                    break;

                case Operacao.Porcento:


                    resultado = (valor / 100) * Convert.ToDecimal(tbEntered_Number.Text); break;

            }

            tbEntered_Number.Text = Convert.ToString(resultado);
            
            

        }

        private void btnVirgula_Click(object sender, RoutedEventArgs e)
        {
            if (!tbEntered_Number.Text.Contains(","))
                tbEntered_Number.Text += ",";
            tbKeyPressedString.Text = tbEntered_Number.Text;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbEntered_Number.Text = " ";
            tbKeyPressedString.Text = tbEntered_Number.Text;
        }

        private void btnPorcento_Click(object sender, RoutedEventArgs e)
        {
            OperacaoSelecionada = Operacao.Porcento;
            
            valor = Convert.ToDecimal(tbEntered_Number.Text);
            tbEntered_Number.Text = "";
            tbKeyPressedString.Text += "﹪";


        }

        private void btnToggleColorMode_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkMode)
            {
                // Mudar para modo claro
                Application.Current.Resources["BackgroundColor"] = ColorPalette.LightBackground;
                Application.Current.Resources["ButtonBackgroundColor"] = ColorPalette.LightBackground;
                Application.Current.MainWindow.Foreground = ColorPalette.LightForeground;
            }
            else
            {
                // Mudar para modo escuro
                Application.Current.Resources["BackgroundColor"] = ColorPalette.DarkBackground;
                Application.Current.Resources["ButtonBackgroundColor"] = ColorPalette.DarkBackground;
                Application.Current.MainWindow.Foreground = ColorPalette.DarkForeground;
            }

            // Inverter o estado do modo
            isDarkMode = !isDarkMode;
        }
    }
}
