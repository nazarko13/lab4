using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AnalyzerClass;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Memory;
        private Stopwatch _timer = new Stopwatch();
        private string _checkExp;
        public MainWindow()
        {
            InitializeComponent();
            Memory = 0;
            var args = Environment.GetCommandLineArgs();
            textBoxExpression.Text = args.Length != 0 ? string.Join(" ", args.SubArray(1, args.Length-1)) : "0";
            _checkExp = textBoxExpression.Text;    

            if(textBoxExpression.Text.Length > 0)
            {
                Analyzer.Expression = textBoxExpression.Text;
                textBoxResult.Text = Analyzer.Estimate();
            }
        }                
       
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                switch (btn.Content.ToString())
                {
                    case "1":
                        if(textBoxExpression.Text != "0")
                            textBoxExpression.Text += "1";
                        break;
                    case "2":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "2";
                        break;
                    case "3":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "3";
                        break;
                    case "4":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "4";
                        break;
                    case "5":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "5";
                        break;
                    case "6":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "6";
                        break;
                    case "7":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "7";
                        break;
                    case "8":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "8";
                        break;
                    case "9":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "9";
                        break;
                    case "0":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "0";
                        break;
                    case "(":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += "(";
                        break;
                    case ")":
                        if (textBoxExpression.Text != "0")
                            textBoxExpression.Text += ")";
                        break;
                    case "*":
                        textBoxExpression.Text += "*";
                        break;
                    case "/":
                        textBoxExpression.Text += "/";
                        break;
                    case "+":
                        textBoxExpression.Text += "+";
                        break;
                    case "-":
                        textBoxExpression.Text += "-";
                        break;
                    case "mod":
                        textBoxExpression.Text += "mod";
                        break;
                    case "C":
                        textBoxExpression.Text = "";
                        textBoxResult.Text = "";              
                        break;
                    case "Backspace":
                        if (textBoxExpression.Text.Length > 0)
                            textBoxExpression.Text = textBoxExpression.Text.Remove(textBoxExpression.Text.Length - 1);
                        if (textBoxExpression.Text.Length == 0)
                            textBoxExpression.Text = "0";
                        break;                    
                    case "MC":
                        Memory = 0;
                        break;
                    case "MR":
                        textBoxExpression.Text += Memory.ToString();
                        break;
                    case "M+":
                        try
                        {
                            Memory = int.Parse(textBoxResult.Text);
                        }
                        catch
                        {
                            textBoxResult.Text = "Неможливо перетворити до числа";
                        }
                        break;
                    case "+/-":   
                        if(textBoxExpression.Text.Length > 0)
                        {
                            if (!_timer.IsRunning)
                            {
                                _timer = Stopwatch.StartNew();

                            }
                            else
                            {
                                _timer.Stop();
                                if (_timer.Elapsed.Seconds > 3)
                                {
                                    _timer.Reset();
                                    _timer = Stopwatch.StartNew();
                                    return;
                                }
                            }
                            if (textBoxExpression.Text[textBoxExpression.Text.Length - 1] == 'm')
                            {
                                textBoxExpression.Text = textBoxExpression.Text.Remove(textBoxExpression.Text.Length - 1, 1);
                                textBoxExpression.Text += 'p';
                            }
                            else
                            {
                                if (textBoxExpression.Text[textBoxExpression.Text.Length - 1] == 'p')
                                {
                                    textBoxExpression.Text = textBoxExpression.Text.Remove(textBoxExpression.Text.Length - 1, 1);
                                    textBoxExpression.Text += 'm';
                                }
                                else
                                {
                                    if (textBoxExpression.Text == "0")
                                    {
                                        textBoxExpression.Text = "m";
                                    }
                                    else
                                    {
                                        textBoxExpression.Text += "m";
                                    }
                                }
                            }
                            _checkExp = textBoxExpression.Text;
                        }                    
                        
                        break;
                    case "=":
                        Analyzer.Expression = textBoxExpression.Text;
                        textBoxResult.Text = Analyzer.Estimate();
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry for the inconvenience, Unexpected error occured. Details: " +
                    ex.Message);
            }
        }
    }    
}
