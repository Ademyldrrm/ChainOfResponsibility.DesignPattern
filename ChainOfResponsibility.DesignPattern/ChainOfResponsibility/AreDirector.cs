using ChainOfResponsibility.DesignPattern.DAL.Context;
using ChainOfResponsibility.DesignPattern.DAL.Entities;
using ChainOfResponsibility.DesignPattern.Models;

namespace ChainOfResponsibility.DesignPattern.ChainOfResponsibility
{
    public class AreDirector : Employee
    {
        public override void ProcessReguest(CustomerProcessViewModel reg)
        {
            ChainOfRespContext context = new ChainOfRespContext();

            if (reg.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = "Bölge Müdürü  - Özlem Karakoç";
                customerProcess.Description = "Müşterinin talep ettiği tutar tarafımca ödenmiştir";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else 
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = "Bölge Müdürü  - Özlem Karakoç";
                customerProcess.Description = "Müşterinin Talep Etiği tutar bankanın günlük ödeme limitlerini aştığı için işlem gerçekleştirilmedi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
               
            }
        }
    }
}
