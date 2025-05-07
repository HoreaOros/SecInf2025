using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
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

namespace HashGenerator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string hashAlgorithm = "MD5";
    private string fileName = string.Empty;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        bool? ret = dlg.ShowDialog();
        if(ret == true)
        {
            this.txtFileName.Text = dlg.FileName;
            this.fileName = dlg.FileName;
            ComputeHash();
        }
    }

    private void ComputeHash()
    {
        HashAlgorithm ha = MD5.Create();
        switch (hashAlgorithm)
        {
            case "MD5":
                ha = MD5.Create();
                break;
            case "SHA1":
                ha = SHA1.Create();
                break;
            case "SHA256":
                ha = SHA256.Create();
                break;
            case "SHA3_512":
                ha = SHA3_512.Create();
                break;
            default:
                break;
        }
        byte[] buffer = ha.ComputeHash(new FileStream(fileName, FileMode.Open, FileAccess.Read));
        StringBuilder sb = new StringBuilder();
        foreach (byte b in buffer)
        {
            sb.Append(b.ToString("x2"));
        }
        this.txtResult.Text = sb.ToString();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        hashAlgorithm = (string)((ComboBoxItem)((ComboBox)sender).SelectedItem).Content;
        Debug.WriteLine(hashAlgorithm);
        if (string.IsNullOrEmpty(fileName))
        {
            return;
        }
        ComputeHash();
    }
}