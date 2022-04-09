using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace Warehouse_Manage.Controls
{
    public class MonthNumber
    {

        public int Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }
        public string Name { get; set; }

        public string MyDate { get; set; } = false.ToString();

        public bool Selected { get; set; } = false;


    }
    /// <summary>
    /// Interaction logic for DateTimePicker.xaml
    /// </summary>
    public partial class DateTimePicker : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key==Key.Tab|| e.Key == Key.Enter)
            {
                ViewDate.IsOpen = false;
            }
            base.OnKeyDown(e);
        }


        public string DateFormat { get; set; }
        string Lang { get; set; } = "en-US";

        public enum DateMode { Gregorian, Hijri }


        public DateMode DateStyle { set; get; }

     

        DateTime SelectedDateTime = new DateTime();

        public DateTime SelectDate { get; set; } = DateTime.Now;




        public DateTimePicker()
        {
            InitializeComponent();

            Loaded += DateTimePicker_Loaded;

            DataContext = this;


        }

        string Calender = "Calender";

        private void DateTimePicker_Loaded(object sender, RoutedEventArgs e)
        {

            DateMode dateMode = DateMode.Gregorian;

            switch (dateMode)
            {
                case DateMode.Gregorian:
                    PrepareDate(SelectDate.Year, SelectDate.Month);
                    Lang = "en-US";

                    break;
                case DateMode.Hijri:
                    PrepareDateHijri(DateTime.Now);
                    Lang = "ar-SA";

                    break;

            }

        }



        #region Constractor



        int CountDay(string Day)
        {
            int Counter = 0;

            switch (Day)
            {

                case "Sunday":
                    Counter = 1;

                    break;
                case "Monday":
                    Counter = 2;

                    break;
                case "Tuesday":

                    Counter = 3;
                    break;
                case "Wednesday":
                    Counter = 4;

                    break;
                case "Thursday":
                    Counter = 5;

                    break;
                case "Friday":
                    Counter = 6;

                    break;
                case "Saturday":
                    Counter = 7;

                    break;
            }

            return Counter - 1;
        }




        void PrepareDate(int Year, int Month)
        {

            bool CheckDayOnReal = true;

            DateTime Base = new DateTime(Year, Month, 1);
            int x = DateTime.DaysInMonth(Base.Year, Base.Month);

            List<MonthNumber> monthNumbers = new List<MonthNumber>();

            int DayCounter = CountDay(Base.DayOfWeek.ToString());

            int DayPrevoiusMonth = DateTime.DaysInMonth(Base.Year, Base.AddMonths(-1).Month);



            for (int i = 0; i < DayCounter; i++)
            {
                monthNumbers.Add(new MonthNumber { Day = DayPrevoiusMonth- DayCounter+1, Name = Base.DayOfWeek.ToString(), Month = Base.AddMonths(-1).Month.ToString(), Year = Base.Year.ToString(), MyDate = "Previous" });
                DayPrevoiusMonth += 1;
            }


            bool MyDate = false; bool SelectedDate = true;


            if (DateTime.Now.Year == Base.Year)
            {
                if (DateTime.Now.Month == Base.Month)
                {
                    if (DateTime.Now.Day == Base.Day)
                    {

                        MyDate = true;

                        CheckDayOnReal = false;
                    }
                }
            }


            monthNumbers.Add(new MonthNumber { Year = Base.Year.ToString(), Month = Base.Month.ToString(), Day = Base.Day, Name = Base.DayOfWeek.ToString(), MyDate = MyDate.ToString() });

            SelectedDate = false;
            Base = Base.AddDays(1);
            for (int i = 0; i < x - 1; i++)
            {
                if (CheckDayOnReal)
                {
                    if (DateTime.Now.Year == Base.Year)
                    {
                        if (DateTime.Now.Month == Base.Month)
                        {
                            if (DateTime.Now.Day == Base.Day)
                            {
                                MyDate = true;
                                CheckDayOnReal = false;
                            }
                        }
                    }
                }

                if (Base.Year == SelectedDateTime.Year && Base.Month == SelectedDateTime.Month && Base.Day == SelectedDateTime.Day)
                {
                    SelectedDate = true;
                }
                monthNumbers.Add(new MonthNumber { Year = Base.Year.ToString(), Month = Base.Month.ToString(), Day = Base.Day, Name = Base.DayOfWeek.ToString(), Selected = SelectedDate, MyDate = MyDate.ToString() });
                SelectedDate = false;


                Base = Base.AddDays(1);
                MyDate = false;
            }

            listCategories.ItemsSource = monthNumbers;
        }

        void PrepareDateHijri(DateTime dateTime)
        {
            DateTime myDT = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new GregorianCalendar());

            HijriCalendar myCal = new HijriCalendar();

            myDT = new DateTime(myCal.GetYear(myDT), myCal.GetMonth(myDT), 1, new HijriCalendar());

            int x = myCal.GetDaysInMonth(myCal.GetYear(myDT), myCal.GetMonth(myDT), myCal.GetEra(myDT));



            List<MonthNumber> monthNumbers = new List<MonthNumber>();

            for (int i = 0; i < CountDay(myCal.GetDayOfWeek(myDT).ToString()); i++)
            {
                monthNumbers.Add(new MonthNumber { Day = new int(), Name = "", Month = "", Year = "" });
            }



            monthNumbers.Add(new MonthNumber { Year = myCal.GetYear(myDT).ToString(), Month = myCal.GetMonth(myDT).ToString(), Day = myCal.GetDayOfMonth(myDT), Name = myCal.GetDayOfWeek(myDT).ToString(), MyDate = false.ToString() });
            myDT = myDT.AddDays(1);

            for (int i = 0; i < x - 1; i++)
            {
                monthNumbers.Add(new MonthNumber { Year = myCal.GetYear(myDT).ToString(), Month = myCal.GetMonth(myDT).ToString(), Day = myCal.GetDayOfMonth(myDT), Name = myCal.GetDayOfWeek(myDT).ToString() });
                myDT = myDT.AddDays(1);
            }

            listCategories.ItemsSource = monthNumbers;

        }







        private void PreviousMonth(object sender, RoutedEventArgs e)
        {
            SelectDate = SelectDate.AddMonths(-1);
            switch (DateStyle)
            {
                case DateMode.Gregorian:
                    PrepareDate(SelectDate.Year, SelectDate.Month);
                    break;
                case DateMode.Hijri:
                    PrepareDateHijri(SelectDate);
                    break;

            }

        }

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            SelectDate = SelectDate.AddMonths(+1);
            switch (DateStyle)
            {
                case DateMode.Gregorian:
                    PrepareDate(SelectDate.Year, SelectDate.Month);
                    break;
                case DateMode.Hijri:
                    PrepareDateHijri(SelectDate);
                    break;

            }

        }

        #endregion


        private void SetDateSelected(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.RadioButton;
            var Date = button.CommandParameter as MonthNumber;

            SelectedDateTime = new DateTime(int.Parse(Date.Year), int.Parse(Date.Month), Date.Day);
            SelectDate = SelectedDateTime;

            ViewDate.IsOpen = false;
        }

        private void SelecDatebtn_Click(object sender, RoutedEventArgs e)
        {
            ViewDate.IsOpen = true;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void ToggleButton_LostFocus(object sender, RoutedEventArgs e)
        {
           
           
        }
    }
}
