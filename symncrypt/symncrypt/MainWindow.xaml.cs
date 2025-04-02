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
using System.CodeDom;
using System.Collections.Specialized;

namespace symncrypt;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    SymmetricAlgorithm alg = DES.Create();
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
        if (alg == null)
            return;

        

        Util.Encrypt(alg, txtInputFile.Text, txtOutputFile.Text);
    }

    private void btnDecrypt_Click(object sender, RoutedEventArgs e)
    {
        if (alg == null)
            return;

        Util.Decrypt(alg, txtInputFile.Text, txtOutputFile.Text);
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

    private void cmbAlgo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (((ComboBoxItem)(cmbAlgo.SelectedValue)).Content)
        {
            case "AES":
                alg = Aes.Create();
                break;
            case "DES":
                alg = DES.Create();
                break;
            case "RC2":
                alg = RC2.Create();
                break;
            case "Rijndael":
                alg = Aes.Create();
                break;
            case "TripleDES":
                alg = TripleDES.Create();
                break;
        }
    }

    private void cmbModOperare_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        alg.Mode = (CipherMode)cmbModOperare.SelectedValue;
    }

    private void cmbPadding_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        alg.Padding = (PaddingMode)cmbPadding.SelectedValue;
    }
}