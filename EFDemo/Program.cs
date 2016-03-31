using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.EF;
using EFDemo.NH;
using Microsoft.Data.Entity;

//sing IEquipamentoGenericoPresenter = EFDemo.IEquipamentoPresenter<EFDemo.EquipamentoGenericoViewModel, EFDemo.EquipamentoGenerico> ;

                                      
namespace EFDemo {

    class Program {
        static void Main(string[] args) {
//            var tipoFuncionario = new EmployeeType("Teste", 1);

//            var funcionario = new Employee();
//            funcionario.ChangeAdress("Funchal");
//            funcionario.ChangeName("Luis");
//            funcionario.SetEmployeeType(tipoFuncionario);
//            funcionario.AddContact(new Contact("123123123", ContactKind.Phone));
//            funcionario.AddContact(new Contact("123123123", ContactKind.Phone));
//            Console.WriteLine(funcionario);

           /* using (var context = new FuncionariosDbContext()) {
                context.TiposFuncionario.Add(tipoFuncionario);
            }*/

            SaveAndLoadEmployeeWithNH();
//            SaveAndLoadEmployeeWithEF();
        }

        private static void SaveAndLoadEmployeeWithEF() {
            var dbContext = new EfDemoContext(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            using (var tran = dbContext.Database.BeginTransaction()) {
                var types = dbContext.Set<EmployeeType>().ToList();
                foreach (var employeeType in types) {
                    Console.WriteLine(employeeType.EmployeeTypeId + " - " +employeeType.Designation);
                }
                tran.Commit();
            }
        }

        private static void SaveAndLoadEmployeeWithNH() {
            var employeeId = 0;
            var sessionFactory =
                SessionFactoryHelper.GetSessionFactory(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            using (var session = sessionFactory.OpenSession()) {
                using (var tran = session.BeginTransaction()) {
                    var employeeTypes = session.QueryOver<EmployeeType>().List<EmployeeType>();

                    var employee = new Employee();
                    employee.ChangeAdress("Funchal");
                    employee.ChangeName("Luis");
                    employee.SetEmployeeType(employeeTypes.First());
                    employee.AddContact(new Contact("123123123", ContactKind.Phone));
                    employee.AddContact(new Contact("123123123", ContactKind.Phone));
                    session.SaveOrUpdate(employee);
                    tran.Commit();

                    employeeId = employee.EmployeeId;

                }
            }

            using (var session = sessionFactory.OpenSession()) {
                using (var tran = session.BeginTransaction()) {
                    var employee = session.Load<Employee>(employeeId);
                    Console.WriteLine(employee);
                }
            }
        }
    }

    
}
