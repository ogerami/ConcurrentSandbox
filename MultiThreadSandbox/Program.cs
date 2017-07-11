using System;
using System.Threading.Tasks;
using MultiThreadSandbox.Ioc;
using MultiThreadSandbox.Models;
using MultiThreadSandbox.Repositories.Interfaces;

namespace MultiThreadSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new SimpleInjectorIoc()
                .InitializerContainer()
                .GetContainer();

            var repository = container.GetInstance<ICustomerRepository>();

            var taskWrite1 = Task.Run(() =>
            {
                for (var i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(10);
                    repository.Add(new CustomerModel
                    {
                        CustomerId = i.ToString(),
                        Name = $"Customer{i}"
                    });
                }
            });

            var taskWrite2 = Task.Run(() =>
            {
                for (var i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(10);
                    repository.Add(new CustomerModel
                    {
                        CustomerId = i.ToString(),
                        Name = $"Customer{i}"
                    });
                }
            });

            var taskRead1 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(500);
                var customerModels = repository.GetAll();
                foreach (var customerModel in customerModels)
                {
                    Console.WriteLine($"Id: {customerModel.CustomerId} - Name: {customerModel.Name}");
                    System.Threading.Thread.Sleep(100);
                }
            });

            var taskRead2 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(100);
                var customerModels = repository.GetAll();
                foreach (var customerModel in customerModels)
                {
                    Console.WriteLine($"Id: {customerModel.CustomerId} - Name: {customerModel.Name}");
                    System.Threading.Thread.Sleep(100);
                }
            });


            Task.WhenAll(taskRead1, taskRead2, taskWrite1, taskWrite2);
            Console.ReadLine();
        }
    }
}
