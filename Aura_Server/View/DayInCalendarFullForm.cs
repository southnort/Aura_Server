using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura.Model;

namespace Aura_Server.View
{
    public partial class DayInCalendarFullForm : Form
    {
        //Максимально подробная форма дня из календаря
        public DayInCalendarFullForm(DayInCalendar day)
        {
            InitializeComponent();

            dateLabel.Text = day.date.ToString();
            foreach (var ev in day.events)
            {
                Button button = CreateButton(ev);
                int x = 0;
                int y = mainPanel.Controls.Count + 5 * button.Height;
                button.Location = new Point(x, y);
            }

           

        }

        private Button CreateButton(KeyValuePair<Purchase,string> eventOb)
        {
            Button button = new Button()
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(284, 40),
                Text = eventOb.Key.purchaseName + "\n" + eventOb.Value,

            };

            return button;
        }


    }
}
