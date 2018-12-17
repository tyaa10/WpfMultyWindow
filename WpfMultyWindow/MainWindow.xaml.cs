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

namespace WpfMultyWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentNameSpace;
        private int currentDocIdx = 0;
        List<FlowDocument> docs;
        FlowDocumentReader fdr;
        public MainWindow()
        {
            InitializeComponent();

            fdr = new FlowDocumentReader();
            contentGrid.Children.Add(fdr);

            currentNameSpace =
                this.GetType().Namespace;

            
            FlowDocument doc = new FlowDocument();
            Paragraph p1 = new Paragraph(new Run("Hello Document 1!"));
            doc.Blocks.Add(p1);

            FlowDocument doc2 = new FlowDocument();
            Paragraph p2 = new Paragraph(new Run("Hello Document 2!"));
            doc2.Blocks.Add(p2);

            docs = new List<FlowDocument> { doc, doc2 };
        }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((MenuItem)sender).Header.ToString());
            /*switch (((MenuItem)sender).Header.ToString().Replace("GoTo", ""))
            {
                case "Window1":
                    {
                        Window1 w1 = new Window1();
                        //w1.Show();
                        w1.ShowDialog();
                        break;
                    }
                case "Window2":
                    {
                        Window2 w2 = new Window2();
                        w2.Show();
                        break;
                    }
            }*/
            string windowName =
                currentNameSpace
                + "."
                + ((MenuItem)sender).Header.ToString().Replace("GoTo", "");
            //MessageBox.Show(windowName);
            Type windowType = Type.GetType(windowName);
            Window window =
                (Window)windowType.GetConstructor(Type.EmptyTypes).Invoke(null);
            window.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentDocIdx == docs.Count)
            {
                currentDocIdx = 0;
            }
            fdr.Document = docs[currentDocIdx];
            
            currentDocIdx++;
        }
    }
}
