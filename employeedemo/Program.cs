using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.NH;

//sing IEquipamentoGenericoPresenter = EFDemo.IEquipamentoPresenter<EFDemo.EquipamentoGenericoViewModel, EFDemo.EquipamentoGenerico> ;

                                      
namespace EFDemo {
   /* using IEquipamentoGenericoView2 = EFDemo.IEquipamentoView<IEquipamentoGenericoPresenter, EFDemo.EquipamentoGenericoViewModel, EFDemo.EquipamentoGenerico>;

    public class EquipamentoViewModel {}
    public class Equipamento {}

    public class EquipamentoGenericoViewModel :EquipamentoViewModel {}

    public class EquipamentoGenerico : Equipamento {}

    public interface IEquipamentoPresenter<TVm, TE>
        where TVm : EquipamentoViewModel
        where TE : Equipamento {
    }

    //public interface IEquipamentoGenericoPresenter : IEquipamentoPresenter<EquipamentoGenericoViewModel, EquipamentoGenerico> {}

    public interface IEquipamentoView<TP, TVm, TE>
        where TP : IEquipamentoPresenter<TVm, TE>
        where TE : Equipamento
        where TVm : EquipamentoViewModel {
    }

    public interface IEquipamentoGenericoView :
        IEquipamentoView<IEquipamentoGenericoPresenter, EquipamentoGenericoViewModel, EquipamentoGenerico> {
    }

    public abstract class EquipamentoPresenter<TVm, TE, TVe> : IEquipamentoPresenter<TVm, TE>
        where TVm : EquipamentoViewModel, new()
        where TE : Equipamento, new()
        where TVe : IEquipamentoView<IEquipamentoPresenter<TVm, TE>, TVm, TE> {
    }

    public class EquipamentoGenericoPresenter : EquipamentoPresenter<
        EquipamentoGenericoViewModel,
        EquipamentoGenerico,
        IEquipamentoView<IEquipamentoPresenter<EquipamentoGenericoViewModel, EquipamentoGenerico>, EquipamentoGenericoViewModel,
                EquipamentoGenerico>>, IEquipamentoGenericoPresenter {
    }

    public class EquipamentoGenericoPresenterComErro : EquipamentoPresenter<
        EquipamentoGenericoViewModel,
        EquipamentoGenerico,
        IEquipamentoGenericoView2> {
    }
    */

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

            SaveAndLoadEmployee();
        }

        private static void SaveAndLoadEmployee() {
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
