using ChainOfResponsibility.DesignPattern.Models;

namespace ChainOfResponsibility.DesignPattern.ChainOfResponsibility
{
    public abstract class Employee
    {
       
            protected Employee NextApprover;
            public void SetNextApprover(Employee supervisor)
            {
                this.NextApprover = supervisor;
            }
            public abstract void ProcessReguest(CustomerProcessViewModel reg);
        }
    }

