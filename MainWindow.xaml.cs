
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SolidEdgeCommunity;

namespace SolidPluginTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SolidEdgeFramework.Application app = null;
            SolidEdgeFramework.Documents docs = null;

            SolidEdgePart.PartDocument partDoc = null;
            
            try
            {
                OleMessageFilter.Register();

                app = SolidEdgeUtils.Connect(false);
                docs = app.Documents;


                if (app.ActiveDocumentType != SolidEdgeFramework.DocumentTypeConstants.igPartDocument)
                {
                    return;
                }

                partDoc = (SolidEdgePart.PartDocument)app.ActiveDocument;

                SolidEdgeFramework.Variables vars;
                vars = (SolidEdgeFramework.Variables)partDoc.Variables;
                
                datagrid.ItemsSource = (SolidEdgeFramework.VariableList)vars.Query("*",
                                SolidEdgeConstants.VariableNameBy.seVariableNameByUser,
                                SolidEdgeConstants.VariableVarType.SeVariableVarTypeVariable);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                OleMessageFilter.Unregister();
            }
        }
    }
}
