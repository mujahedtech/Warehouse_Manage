﻿using System;
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

namespace Warehouse_Manage
{
    class AccountUsers
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserPWD { get; set; }

        public string UserMSG { get; set; }

        public string UserType { get; set; }

        public DateTime DateCreate { get; set; }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xamls
    /// </summary>
    public partial class MainWindow : Window
    {

        //private static DAL.Database database;

        //public static DAL.Database Database
        //{
        //    get
        //    {
        //        if (database==null)
        //        {
        //            database = new DAL.Database("MujahedTech.db3");
        //        }
        //        return database;
        //    }
        //}


       


        public MainWindow()
        {
            InitializeComponent();

            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            
              GridMain.Children.Clear();
            GridMain.Children.Add(new Pages.Home());

            Loaded += MainWindow_Loaded;
        }

       

        private void btnMainButtons(object sender, RoutedEventArgs e)
        {
            double Width = GridNameButtons.ColumnDefinitions[1].ActualWidth;
            GridCursor.Width = Width;
            int index = int.Parse(((Button)e.Source).Uid);


            GridCursor.Margin = new Thickness(0 + (Width * index), 0, 0, 0);

          
            GridMain.Children.Clear();

            switch (index)
            {
                case 0:
                    GridMain.Children.Add(new Pages.Home());
                    break;
                case 1:
                    GridMain.Children.Add(new Pages.Farms());
                    break;
                case 2:
                    GridMain.Children.Add(new Pages.FarmCycle());
                    break;
                case 3:
                   
                    break;
                case 4:
                   
                    break;
                case 5:

                    
                    break;
                case 6:
                   

                    break;
                case 7:
                   
                    break;

            }
        }
        private void btnTopButtons(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    if (WindowState == WindowState.Maximized)
                    {
                        WindowState = WindowState.Normal;
                        PackIconWindowsState.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                    }
                    else if (WindowState != WindowState.Maximized)
                    {
                        this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                        WindowState = WindowState.Maximized;
                        PackIconWindowsState.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                    }

                    break;
                case 1:
                    Application.Current.Shutdown();
                    break;
                case 2:
                    WindowState = WindowState.Minimized;
                    break;
                case 3:
                    MessageBoxResult MR = MessageBox.Show("Are You Sure ?", "Install Lastest Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (MR == MessageBoxResult.Yes)
                    {
                        //System.Diagnostics.Process.Start("StartUpdate.exe");
                        //Application.Current.Shutdown();
                    }

                    break;
                case 4:


                   
                    break;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

           


            if (e.ClickCount==2)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    return;
                }
                WindowState = WindowState.Maximized;
                return;
            }


            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

            }

            DragMove();
        }



        Firebase.Database.FirebaseClient firebaseClient;
        //دالة تقوم بالتواصل مع فاير بيك من اجل عمل البرنامج
        async void CheckApp(string User, string PWD)
        {
            try
            {
                firebaseClient = new Firebase.Database.FirebaseClient("https://khiratserv-default-rtdb.asia-southeast1.firebasedatabase.app/");

                var account = (await firebaseClient.Child("AccountUsersKhirat").OnceAsync<AccountUsers>()).Select(item => new AccountUsers
                {
                    UserID = item.Object.UserID,
                    UserMSG = item.Object.UserMSG,
                    UserName = item.Object.UserName,
                    UserPWD = item.Object.UserPWD,
                    UserType = item.Object.UserType
                }).ToList();
                var UsersAccounts = new System.Collections.ObjectModel.ObservableCollection<AccountUsers>(account).Where(i => i.UserName == User && i.UserPWD == PWD).ToList();


                //في حال ان المستخدم غير الموجود
                //if (UsersAccounts.Count() == 0)
                //{
                //    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                //    {
                //        if (window.GetType() == typeof(MainWindow))
                //        {
                           
                           
                //        }
                //    }
                //    return;
                //}


                //في حال ان التطبيق يوجد به امر توقف
                if (UsersAccounts.Count() > 0)
                {
                    if (UsersAccounts[0].UserType == "Stop")
                    {
                        foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                (window as MainWindow).GridPage.Children.Clear();

                                string Message = "عزيزي المستخدم" + Environment.NewLine;
                                Message += "يوجد مشكلة بالبرنامج" + Environment.NewLine;
                                Message += "البرنامج لن يعمل بشكل صحيح" + Environment.NewLine;
                                Message += "يرجى التواصل مع المبرمج" + Environment.NewLine;

                                (window as MainWindow).GridPage.Children.Add(new Pages.ErrorPage(Message)) ;
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }





        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CheckApp("Warehouse_Manage","Mujahed1200");
        }
    }
}
