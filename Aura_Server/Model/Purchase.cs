using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_Server.Model
{
    public class Purchase
    {
        //класс, описывающий объект закупки


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
