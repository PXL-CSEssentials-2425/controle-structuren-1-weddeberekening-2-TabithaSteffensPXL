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

namespace weddeberekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double hourlyWage = double.Parse(hourlyWageTextBox.Text);
            double amountHours = double.Parse(numberOfHoursTextBox.Text);
            string employeeName = employeeTextBox.Text;
            double income = hourlyWage * amountHours;
            double taxBracket;
            if (income > 50000)
            {
                taxBracket = 0.5; 
            }
            else if (income > 25000 && income <= 5000)
            {
                taxBracket = 0.6;
            }
            else if (income > 15000 &&  income <= 25000)
            {
                taxBracket = 0.7;
            }
            else if (income > 10000 && income <= 15000)
            {
                taxBracket = 0.8;
            }
            else
            {
                taxBracket = 1.0;
            }
            double taxedIncome = taxBracket * income;
            double taxes = income - taxedIncome;

            resultTextBox.Text = $"LOONFICHE VAN {employeeName} \r\n Aantal gewerkte uren: {amountHours}  \r\n Uurloon: {hourlyWage:c} \r\n Brutojaarwedde: {income:c}  \r\n Belasting: {taxes:c} \r\n Nettojaarwedde: {taxedIncome:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            employeeTextBox.Clear();
            numberOfHoursTextBox.Clear();
            hourlyWageTextBox.Clear();
            resultTextBox.Clear();
            employeeTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}