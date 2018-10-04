using Aura.Model;
using Aura_Server.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aura_Server.View
{
    public partial class PurchasesCalendarForm : Form
    {
        //визуальное представление календаря закупок
        private PurchasesTableAdapter dataBase;
        private int month;      //выбранный для отображание месяц
        private int year;       //выбранный для отображения год


        public PurchasesCalendarForm(PurchasesTableAdapter adapter)
        {
            InitializeComponent();
            dataBase = adapter;

            month = DateTime.Today.Month - 1;
            year = DateTime.Today.Year - 2016;
            ShowDate();

            RefreshTable();

        }

        private void ShowDate()
        {
            monthComboBox.SelectedIndex = month;
            yearComboBox.SelectedIndex = year;

        }


        //обработка смены даты
        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = monthComboBox.SelectedIndex;
            RefreshTable();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = yearComboBox.SelectedIndex;
            RefreshTable();
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 0)
            {
                year--;
                month = 11;
            }
            ShowDate();
            RefreshTable();
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 11)
            {
                year++;
                month = 0;
            }
            ShowDate();
            RefreshTable();
        }


        //заполнение календаря
        private void RefreshTable()
        {
            //Clear();

            //Calendar calendar = new Calendar(Program.purchasesDataBase.GetAllPurchases());
            //Fill(calendar.GetDays());
        }

        private void Clear()
        {
            mainPanel.Controls.Clear();
        }

        private List<DayInCalendar> GetDays(Calendar calendar)
        {
            //создаем лист дней для выбранного месяца
            List<DayInCalendar> days = new List<DayInCalendar>();

            //заполняем его пустыми днями
            for (int i = 0; i < DateTime.DaysInMonth(year + 2016, month + 1); i++)
            {
                try
                {
                    days.Add(new DayInCalendar(new DateTime(year + 2016, month + 1, i + 1)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine((year + 2016) + " " + (month + 1) + " " + (i + 1));
                    throw ex;
                }

            }

            //добавляем в нужные пустые дни события из календаря
            foreach (var pair in calendar)
            {
                if (pair.Key.Month == month + 1)
                    days.Add(pair.Value);
            }

            return days;
        }

        private void Fill(List<DayInCalendar> days)
        {
            //заполнить таблицу днями недели из List'а
            //в листе должны быть даты только из 
            for (int i = 0; i < days.Count; i++)
            {
                DayInCalendar day = days[i];

                DayInCalendarForm form = new DayInCalendarForm(day);
                mainPanel.Controls.Add(form);

                form.Location = GetLocationForButton(day.date, form);

            }

        }

        private Point GetLocationForButton(DateTime day, DayInCalendarForm form)
        {
            //американская неделя начинается с воскресенья. Поэтому сдвигаем в конец.
            int x = day.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)day.DayOfWeek;
            x--;
            int weekDelta = 7 - x;      //когда месяц начинается не с понедельника

            int y = (day.Day + weekDelta) / 7;

            return new Point(x * (form.Width + 5), y * (form.Height + 5));
        }

    }
}
