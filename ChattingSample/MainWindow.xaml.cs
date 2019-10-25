using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChattingSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection _hubConnection;
        public MainWindow()
        {
            InitializeComponent();
            _hubConnection = new HubConnectionBuilder().WithUrl("http://127.0.0.1:56734/chathub").WithAutomaticReconnect().Build();

        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_hubConnection.State.ToString());
            //await _hubConnection.InvokeAsync("SendMessage",
            //        txbUserName.Text, txbMessage.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        
            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    txbChat.AppendText($"{Environment.NewLine}{user} : {message}");
                });
            });
        }
    }
}
