using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Aura_Server.Model
{
    public class Purchase
    {
        //класс, описывающий объект закупки

        public Purchase()
        {
            purchaseEisDate = bidsStartDate = bidsEndDate =
                bidsOpenDate = bidsFirstPartDate = auctionDate =
                bidsSecondPartDate = bidsFinishDate = contractDatePlan =
                contractDateLast = contractDateReal = reestrDateLast =

                DateTime.MinValue.ToString();

        }

        public Purchase(DataRow row)
        {
            //создать закупку из строки БД

            id = (int)(long)row[0];
            employeID = (int)(long)row[1];
            organizationID = (int)(long)row[2];
            purchaseMethodID = (int)(long)row[3];
            purchaseName = (string)row[4];
            statusID = (int)(long)row[5];            
            purchacePrice = (float)(double)row[6];

            purchaseEisNum = (string)row[7];
            purchaseEisDate = (string)row[8];
            bidsStartDate = (string)row[9];
            bidsEndDate = (string)row[10];
            bidsOpenDate = (string)row[11];
            bidsFirstPartDate = (string)row[12];
            auctionDate = (string)row[13];
            bidsSecondPartDate = (string)row[14];
            bidsFinishDate = (string)row[15];

            contractPrice = (float)(double)row[16];
            contractDatePlan = (string)row[17];
            contractDateLast = (string)row[18];
            contractDateReal = (string)row[19];
            reestrDateLast = (string)row[20];
            reestrNumber = (string)row[21];

            comments = (string)row[22];

        }

        public int id;                      //ИД закупки в БД
        public int employeID;               //индекс юзера, ответственного за закупку
        public int organizationID;          //индекс организации - заказчика
        public int purchaseMethodID;        //индекс способа определения поставщика
        public string purchaseName;         //наименование объекта закупки
        public int statusID;                //идентификатор статуса. Подача заявок, рассмотрение итд
        public float purchacePrice;         //НМЦК, начальная цена

        public string purchaseEisNum;       //номер извещения в ЕИСе
        public string purchaseEisDate;      //дата публикации извещения в ЕИС
        public string bidsStartDate;        //дата начала подачи заявок
        public string bidsEndDate;          //дата окончания подачи заявок
        public string bidsOpenDate;         //дата вскрытия конвертов
        public string bidsFirstPartDate;    //дата рассмотрения первых частей
        public string auctionDate;          //дата проведения аукциона
        public string bidsSecondPartDate;   //дата рассмотрения вторых частей
        public string bidsFinishDate;       //дата подведения итогов

        public float contractPrice;         //цена заключенного контракта
        public string contractDatePlan;     //дата подписания контракта (планируемая)
        public string contractDateLast;     //дата подписания контракта (крайняя)
        public string contractDateReal;     //дата подписания контракта (фактическая)
        public string reestrDateLast;       //дата внесения контракта в реестр (крайняя)
        public string reestrNumber;         //реестровый номер контракта в ЕИС

        public string comments;             //комментарии к закупке

    }

}
