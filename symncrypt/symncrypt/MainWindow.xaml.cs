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
using System.Security.Cryptography;
using Microsoft.Win32;

namespace symncrypt;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        foreach(var item in Enum.GetValues(typeof(CipherMode)))
            this.cmbModOperare.Items.Add(item);

        foreach (var item in Enum.GetValues(typeof(PaddingMode)))
            this.cmbPadding.Items.Add(item);
    }



    private void btnEncrypt_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnDecrypt_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnBrowseInput_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        bool? ret = dlg.ShowDialog();
        if(ret == true)
        {
            this.txtInputFile.Text = dlg.FileName;
        }
    }
}