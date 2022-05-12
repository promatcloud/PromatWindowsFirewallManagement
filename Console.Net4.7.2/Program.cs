using Promat.Windows.FirewallManagement;

namespace Console.Net4._7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una regla de firewall para puerto de sql server
            var rule = GetSqlTcpInPortRule();
            try
            {
                // Añadimos la regla, a las reglas del firewall
                rule.AddRule();
                System.Console.WriteLine("Regla creada en el Firewall");
                // Borramos la regla.
                rule.DeleteRule();
                System.Console.WriteLine("Regla eliminada del Firewall");
            }
            catch (ElevationRequiredException e)
            {
                System.Console.WriteLine("Se necesita ejecutar como administrador para acceder al firewall de windows");
            }

            System.Console.ReadLine();
        }
        private static WindowsFirewallRule GetSqlTcpInPortRule()
        {
            var rule = new WindowsFirewallRule
            {
                Name = "Microsoft SQL Server 2014 TCP Port 1433",
                Dir = DirEnum.In,
                Action = ActionEnum.Allow,
                Protocol = ProtocolEnum.Tcp,
                Profile = ProfileEnum.Private | ProfileEnum.Domain
            };
            rule.AddLocalPorts(1433);
            return rule;
        }
    }
}
