﻿using ChainOfResponsibility.DesignPattern.DAL.Context;
using ChainOfResponsibility.DesignPattern.DAL.Entities;
using ChainOfResponsibility.DesignPattern.Models;

namespace ChainOfResponsibility.DesignPattern.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessReguest(CustomerProcessViewModel reg)
        {

            ChainOfRespContext context = new ChainOfRespContext();

            if (reg.Amount <= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Oğuzhan Karal";
                customerProcess.Description = "Müşterinin talep ettiği tutar tarafımca ödenmiştir";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Oğuzhan Karal";
                customerProcess.Description = "Müşterinin Talep Etiği tutar tarafımca ödenemediği için işlem şube müdürine aktarıyorum";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessReguest(reg);
            }
        }
    }
}
