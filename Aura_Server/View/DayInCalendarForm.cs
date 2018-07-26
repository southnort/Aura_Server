using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura_Server.Model;

namespace Aura_Server.View
{
    public partial class DayInCalendarForm : UserControl
    {
        //краткое визуальное представление одного дня в календаре
        //содержит кнопки-ссылки на закупки, для которых этот день важен

        public DayInCalendarForm(DayInCalendar dayInCalendar)
        {
            InitializeComponent();

            dateLabel.Text = dayInCalendar.date.Day.ToString();

            //добавить кнопки закупок, если на этот день что-то назначено
            foreach (var pair in dayInCalendar.events)
            {
                if (panel1.Controls.Count < 2)
                {
                    Button btn = CreateButton(pair);
                    panel1.Controls.Add(btn);
                    if (panel1.Controls.Count == 0)
                    {
                        btn.Location = new Point(7, 6);
                    }
                    else
                    {
                        btn.Location = new Point(7, 51);
                    }

                }

                else
                {
                    lowerLabel.Text = "...и еще " + (dayInCalendar.events.Count - 2);
                    break;
                }
            }

        }

        private Button CreateButton(KeyValuePair<Purchase, string> pair)
        {
            Button button = new Button()
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Text = pair.Key.purchaseName + "\n" +
                pair.Value,

            };

            return button;

        }




    }
}
