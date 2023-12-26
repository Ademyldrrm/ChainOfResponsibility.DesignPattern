﻿using ChainOfResponsibility.DesignPattern.DAL.Context;
using ChainOfResponsibility.DesignPattern.DAL.Entities;
using ChainOfResponsibility.DesignPattern.Models;

namespace ChainOfResponsibility.DesignPattern.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessReguest(CustomerProcessViewModel reg)
        {
            ChainOfRespContext context = new ChainOfRespContext();

            if (reg.Amount <= 280000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = "Şube Müdür  - İpek Çelik";
                customerProcess.Description = "Müşterinin talep ettiği tutar tarafımca ödenmiştir";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = reg.Amount;
                customerProcess.Name = reg.Name;
                customerProcess.EmployeeName = " Müdür Yardımcısı - İpek Çelik";
                customerProcess.Description = "Müşterinin Talep Etiği tutar tarafımca ödenemediği için işlem Bölge müdürrüne aktarıyorum";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessReguest(reg);
            }
        }
    }
}
