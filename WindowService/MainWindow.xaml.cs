using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ClientSending;

namespace WindowService
{
    
    public partial class MainWindow : Window
    {
        public enum News
        {
            humor = 4567,
            politic,
            coocking
        }
        List<Client> clients;

        public MainWindow()
        {
            InitializeComponent();
            clients = new List<Client>();
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            output.Text = string.Empty;
            CheckBox checkbox = sender as CheckBox;
            
            if (checkbox.IsChecked == true)
            {

                clients.Add(new Client((int)Enum.Parse(typeof(News), checkbox.Name)));
                foreach (Client client in clients)
                {
                    output.Text += " " + await client.AcceptAsync();
                }
            }
               
        }
    }
}
