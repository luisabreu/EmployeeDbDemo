using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.EF;
using EFDemo.NH;

//sing IEquipamentoGenericoPresenter = EFDemo.IEquipamentoPresenter<EFDemo.EquipamentoGenericoViewModel, EFDemo.EquipamentoGenerico> ;

                                      
namespace EFDemo {
   
    class Program {
        static void Main(string[] args) {

            //SaveAndLoadEmployeeWithNH();

            SaveAndLoadEmployeeWithEF();
        }

        private static void SaveAndLoadEmployeeWithEF() {
            var cnnString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            var d = new EfDemoContext(cnnString);
            var t = d.EmployeeTypes.ToList();
            var d1 = new EfDemoContext(cnnString);
            var t2 = d1.EmployeeTypes.ToList();
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
