using ch.hsr.wpf.gadgeothek.manager.viewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace ch.hsr.wpf.gadgeothek.manager.view
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        GadgetDelete GadgetDelete { get; set; }

        public AdminWindow(AdminWindowViewModel AdminWindowViewModel)
        {
            DataContext = AdminWindowViewModel;
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, (message) =>
            {
                switch (message.Notification)
                {
                    case "Delete_Gadget":
                        GadgetDelete = new GadgetDelete();
                        GadgetDelete.DataContext = new GadgetDeleteViewModel();
                        GadgetDelete.Show();
                        break;

                    case "Delete_Gadget_Cancel":
                        GadgetDelete.Close();
                        break;

                    case "Delete_Gadget_Ok":
                        GadgetDelete.Close();
                        break;
                }
            }); 


        }


    }
}
