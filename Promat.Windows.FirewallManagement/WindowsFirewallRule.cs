using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Promat.Windows.FirewallManagement
{
    //public static class WindowsFirewall
    //{
    //    private static string Program => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Microsoft SQL Server\\90\\Shared\\sqlbrowser.exe");
    //    private static List<WindowsFirewallRule> SqlPortRules => new List<WindowsFirewallRule>
    //        {
    //            GetSqlTcpInPortRule(),
    //            GetSqlUdpInPortRule(),
    //            GetSqlTcpOutPortRule(),
    //            GetSqlUdpOutPortRule()
    //        };

    //    private static List<WindowsFirewallRule> SqlPortAndExecutableRules =>
    //        SqlPortRules.Union(new List<WindowsFirewallRule>
    //        {
    //            GetSqlExecutableInRule(),
    //            GetSqlExecutableOutRule()
    //        }).ToList();

    //    public static List<WindowsFirewallRule> AddSqlPortAndExecutableRules()
    //    {
    //        var rules = SqlPortAndExecutableRules;
    //        foreach (var rule in rules)
    //        {
    //            try
    //            {
    //                rule.AddRule();
    //            }
    //            catch
    //            {
    //                // ignored
    //            }
    //        }

    //        return rules;
    //    }
    //    public static List<WindowsFirewallRule> AddSqlPortRules()
    //    {
    //        var rules = SqlPortRules;
    //        foreach (var rule in rules)
    //        {
    //            try
    //            {
    //                rule.AddRule();
    //            }
    //            catch
    //            {
    //                // ignored
    //            }
    //        }

    //        return rules;
    //    }
    //    private static WindowsFirewallRule GetSqlTcpInPortRule()
    //    {
    //        var rule = new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 TCP Port 1433",
    //            Dir = DirEnum.In,
    //            Action = ActionEnum.Allow,
    //            Protocol = ProtocolEnum.Tcp,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain
    //        };
    //        rule.AddLocalPorts(1433);
    //        return rule;
    //    }
    //    private static WindowsFirewallRule GetSqlUdpInPortRule()
    //    {
    //        var rule = new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 UDP Port 1433",
    //            Dir = DirEnum.In,
    //            Action = ActionEnum.Allow,
    //            Protocol = ProtocolEnum.Udp,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain
    //        };
    //        rule.AddLocalPorts(1433);
    //        return rule;
    //    }
    //    private static WindowsFirewallRule GetSqlTcpOutPortRule()
    //    {
    //        var rule = new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 TCP Port 1433",
    //            Dir = DirEnum.Out,
    //            Action = ActionEnum.Allow,
    //            Protocol = ProtocolEnum.Tcp,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain
    //        };
    //        rule.AddRemotePorts(1433);
    //        return rule;
    //    }
    //    private static WindowsFirewallRule GetSqlUdpOutPortRule()
    //    {
    //        var rule = new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 UDP Port 1433",
    //            Dir = DirEnum.Out,
    //            Action = ActionEnum.Allow,
    //            Protocol = ProtocolEnum.Udp,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain
    //        };
    //        rule.AddRemotePorts(1433);
    //        return rule;
    //    }
    //    private static WindowsFirewallRule GetSqlExecutableInRule() =>
    //        new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 Browser",
    //            Dir = DirEnum.In,
    //            Action = ActionEnum.Allow,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain,
    //            Program = Program
    //        };
    //    private static WindowsFirewallRule GetSqlExecutableOutRule() =>
    //        new WindowsFirewallRule
    //        {
    //            Name = "Microsoft SQL Server 2014 Browser",
    //            Dir = DirEnum.Out,
    //            Action = ActionEnum.Allow,
    //            Profile = ProfileEnum.Private | ProfileEnum.Domain,
    //            Program = Program
    //        };
    //}
    public class WindowsFirewallRule
    {
        /// <summary>
        /// Obligatorio.Especifica el comando.
        /// </summary>
        private CommandEnum Command { get; set; }
        /// <summary>
        ///Especifica que los paquetes de red con direcciones IP coincidentes coinciden con esta regla.localip se compara con el campo de dirección IP de destino de un paquete de red entrante.
        /// Se compara con el campo de dirección IP de origen de un paquete de red saliente. localip puede tener cualquiera de los siguientes valores:
        /// ninguna.Coincide con cualquier dirección IP.
        /// Dirección IP. Coincide solo con la dirección IPv4 o IPv6 exacta.
        /// IPSubred.Coincide con cualquier dirección IPv4 o IPv6 que forme parte de la subred especificada. El formato es la dirección de subred, seguida de '/' y luego el número de bits en la máscara de subred o la propia máscara de subred.
        /// Rango IP. Coincide con cualquier dirección IPv4 o IPv6 que se encuentre dentro del rango especificado. El formato son las direcciones IP iniciales y finales del rango separadas por un '-'.
        /// Se pueden especificar varias entradas para localip separándolas con una coma.No incluya ningún espacio. Si no se especifica localip, el valor predeterminado es cualquiera. 
        /// </summary>
        private LocalIpEnum LocalIp { get; set; } = LocalIpEnum.NotSet;
        /// <summary>
        /// Especifica que los paquetes de red con direcciones IP coincidentes coinciden con esta regla.
        /// remoteip se compara con el campo de dirección IP de destino de un paquete de red saliente.
        /// Se compara con el campo de dirección IP de origen de un paquete de red de entrada.remoteip puede tener cualquiera de los siguientes valores:
        /// ninguna.Coincide con cualquier dirección IP.
        /// subred local. Coincide con cualquier dirección IP que esté en la misma subred IP que la computadora local.
        /// dns|dhcp|gana|puerta de enlace predeterminada. Coincide con la dirección IP de cualquier computadora que
        /// esté configurada como el tipo de servidor identificado en la computadora local.
        /// Dirección IP. Coincide solo con la dirección IPv4 o IPv6 exacta especificada.
        /// IPSubred.Coincide con cualquier subred IPv4 o IPv6 que forme parte de la subred especificada. El formato es la dirección de subred, seguida de '/' y
        /// luego el número de bits en la máscara de subred o la propia máscara de subred.
        /// Rango IP. Coincide con cualquier dirección IPv4 o IPv6 que se encuentre dentro del rango especificado. El formato son las direcciones IP iniciales y
        /// finales del rango separadas por un '-'.
        /// Se pueden especificar varias entradas para remoteip separándolas con una coma.Si no se especifica remoteip, el valor predeterminado es cualquiera. 
        /// </summary>
        private RemoteIpEnum RemoteIp { get; set; } = RemoteIpEnum.NotSet;
        /// <summary>
        /// Obligatorio, debe ser un valor de <see cref="LocalPortEnum"/>
        /// </summary>
        private LocalPortEnum LocalPort { get; set; } = LocalPortEnum.NotSet;
        /// <summary>
        /// Obligatorio, debe ser un valor de <see cref="RemotePortEnum"/>
        /// </summary>
        private RemotePortEnum RemotePort { get; set; } = RemotePortEnum.NotSet;
        private List<int> SpecificRemotePorts { get; set; } = new List<int>();
        private List<(int inicio, int fin)> SpecificRangesRemotePorts { get; set; } = new List<(int inicio, int fin)>();
        private List<int> SpecificLocalPorts { get; set; } = new List<int>();
        private List<(int inicio, int fin)> SpecificRangesLocalPorts { get; set; } = new List<(int inicio, int fin)>();
        private List<string> SpecificLocalIp { get; set; } = new List<string>();
        private List<(string inicio, string fin)> SpecificRangesLocalIp { get; set; } = new List<(string inicio, string fin)>();
        private List<string> SpecificRemoteIp { get; set; } = new List<string>();
        private List<(string inicio, string fin)> SpecificRangesRemoteIp { get; set; } = new List<(string inicio, string fin)>();

        /// <summary>
        /// Obligatorio. Especifica el nombre de esta regla de firewall.El nombre debe ser único y no debe ser "all".
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Obligatorio. Debe ser un valor de <see cref="ActionEnum"/>
        /// </summary>
        public ActionEnum Action { get; set; } = ActionEnum.Allow;
        /// <summary>
        /// Obligatorio. Debe ser un valor de <see cref="DirEnum"/>
        /// </summary>
        public DirEnum Dir { get; set; } = DirEnum.In;
        /// <summary>
        /// Opcional. Proporciona información sobre la regla de firewall.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Especifica que el tráfico de red generado por el programa ejecutable identificado coincide con esta regla.
        /// Precaución
        /// La creación de reglas de firewall para hospedar procesos como svchost.exe puede generar un comportamiento impredecible en Firewall de Windows con seguridad avanzada. A partir de Windows Vista, la seguridad de los servicios de red de Windows se incrementó mediante el uso de reglas de firewall integradas y predefinidas.La creación de nuevas reglas que hagan referencia a servicios que ya están protegidos por las reglas integradas puede generar conflictos o efectos secundarios no deseados.
        /// Si no se especifica el programa, el tráfico de red generado por cualquier programa coincide con esta regla.
        ///  [program = ProgramPath\FileName]
        /// </summary>
        public string Program { get; set; }
        /// <summary>
        /// Especifica si la regla está habilitada actualmente. Si no se especifica habilitar, el valor predeterminado es yes.
        /// [ enable = { yes |no } ]
        /// </summary>
        public bool Enable { get; set; } = true;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="ServiceEnum"/>
        /// </summary>
        public ServiceEnum Service { get; set; } = ServiceEnum.NotSet;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="InterfaceTypeEnum"/>
        /// </summary>
        public InterfaceTypeEnum InterfaceType { get; set; } = InterfaceTypeEnum.NotSet;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="EdgeEnum"/>
        /// </summary>
        public EdgeEnum Edge { get; set; } = EdgeEnum.NotSet;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="SecurityEnum"/>
        /// </summary>
        public SecurityEnum Security { get; set; } = SecurityEnum.NotSet;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="ProtocolEnum"/>
        /// </summary>
        public ProtocolEnum Protocol { get; set; } = ProtocolEnum.NotSet;
        /// <summary>
        /// Opcional. Debe ser un valor de <see cref="ProfileEnum"/>, admite múltiples valores mediante manejo de flags
        /// </summary>
        public ProfileEnum Profile { get; set; } = ProfileEnum.NotSet;
        public string ExecutionOutput { get; private set; }

        /// <summary>
        /// Elimina la regla que queremos crear y después la crea.
        /// </summary>
        /// <exception cref="ElevationRequiredException"></exception>
        public void AddRule()
        {
            ThrowIfNotAdministrator();
            Command = CommandEnum.DeleteRule;
            ExecuteCommand();
            Command = CommandEnum.AddRule;
            ExecuteCommand();
        }
        /// <summary>
        /// Elimina la regla.
        /// </summary>
        /// <exception cref="ElevationRequiredException"></exception>
        public void DeleteRule()
        {
            ThrowIfNotAdministrator();
            Command = CommandEnum.DeleteRule;
            ExecuteCommand();
        }
        /// <summary>
        /// Los puertos sólo se pueden especificar para los protocolos TCP y UDP
        /// </summary>
        public void AddRemotePortRange(int inicio, int fin)
        {
            if (fin <= inicio)
            {
                throw new ArgumentException("el puerto inicio debe ser inferior al puerto fin");
            }
            RemotePort = RemotePortEnum.Specific;
            SpecificRangesRemotePorts.Add((inicio, fin));
        }
        /// <summary>
        /// Los puertos sólo se pueden especificar para los protocolos TCP y UDP
        /// </summary>
        public void AddLocalPortRange(int inicio, int fin)
        {
            if (fin <= inicio)
            {
                throw new ArgumentException("el puerto inicio debe ser inferior al puerto fin");
            }
            LocalPort = LocalPortEnum.Specific;
            SpecificRangesLocalPorts.Add((inicio, fin));
        }
        public void AddLocalIpRange(string inicio, string fin)
        {
            LocalIp = LocalIpEnum.Specific;
            SpecificRangesLocalIp.Add((inicio, fin));
        }
        public void AddRemoteIpRange(string inicio, string fin)
        {
            RemoteIp = RemoteIpEnum.Specific;
            SpecificRangesRemoteIp.Add((inicio, fin));
        }
        /// <summary>
        /// Los puertos sólo se pueden especificar para los protocolos TCP y UDP
        /// </summary>
        public void AddLocalPorts(params int[] ports)
        {
            LocalPort = LocalPortEnum.Specific;
            SpecificLocalPorts.AddRange(ports);
        }
        /// <summary>
        /// Los puertos sólo se pueden especificar para los protocolos TCP y UDP
        /// </summary>
        public void AddRemotePorts(params int[] ports)
        {
            RemotePort = RemotePortEnum.Specific;
            SpecificRemotePorts.AddRange(ports);
        }
        public void AddLocalIps(params string[] ips)
        {
            LocalIp = LocalIpEnum.Specific;
            SpecificLocalIp.AddRange(ips);
        }
        public void AddRemoteIps(params string[] ips)
        {
            RemoteIp = RemoteIpEnum.Specific;
            SpecificRemoteIp.AddRange(ips);
        }

        private void ThrowIfNotAdministrator()
        {
            if (!IsUserAnAdmin())
            {
                throw new ElevationRequiredException();
            }
        }

        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsUserAnAdmin();
     
        private void ExecuteCommand()
        {
            var commandNetsh = "netsh advfirewall firewall" +
                              GetCommand() +
                              GetName() +
                              GetDir() +
                              GetAction() +
                              GetProgram() +
                              GetService() +
                              GetDescription() +
                              GetEnable() +
                              GetProfile() +
                              GetLocalIp() +
                              GetRemoteIp() +
                              GetLocalPort() +
                              GetRemotePort() +
                              GetProtocol() +
                              GetInterfaceType() +
                              // GetRmtComputerGrp() +
                              // GetRmtUsrGpr() +
                              GetEdge() +
                              GetSecurity();

            Execute(commandNetsh);
        }
        private string GetCommand()
        {
            var command = "";

            if (Command == CommandEnum.AddRule)
            {
                command = " add rule";
            }
            if (Command == CommandEnum.DeleteRule)
            {
                command = " delete rule";
            }
            if (Command == CommandEnum.SetRule)
            {
                command = " set rule";
            }
            if (Command == CommandEnum.ShowRule)
            {
                command = " show rule";
            }
            return command;
        }
        private string GetRemoteIp()
        {
            if (RemoteIp == RemoteIpEnum.Specific)
            {
                var ports = string.Join(",", SpecificRemoteIp);
                var ranges = string.Join(",", SpecificRangesRemoteIp.Select(tupla => $"{tupla.inicio}-{tupla.fin}"));

                if (string.IsNullOrWhiteSpace(ports) && string.IsNullOrWhiteSpace(ranges))
                {
                    return string.Empty;
                }

                if (ranges.Length > 0)
                {
                    if (ports.Length > 0)
                    {
                        ports += "," + ranges;
                    }
                    else
                    {
                        ports = ranges;
                    }
                }

                return $@" remoteip=""{ports}""";
            }
            return string.Empty;
        }
        private string GetLocalIp()
        {
            if (LocalIp == LocalIpEnum.Specific)
            {
                var ports = string.Join(",", SpecificLocalIp);
                var ranges = string.Join(",", SpecificRangesLocalIp.Select(tupla => $"{tupla.inicio}-{tupla.fin}"));

                if (string.IsNullOrWhiteSpace(ports) && string.IsNullOrWhiteSpace(ranges))
                {
                    return string.Empty;
                }

                if (ranges.Length > 0)
                {
                    if (ports.Length > 0)
                    {
                        ports += "," + ranges;
                    }
                    else
                    {
                        ports = ranges;
                    }
                }

                return $@" localip=""{ports.Replace(" ", "")}""";
            }
            return string.Empty;
        }
        private string GetInterfaceType()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (InterfaceType == InterfaceTypeEnum.NotSet)
                {
                    return string.Empty;
                }

                return $@" interfacetype=""{InterfaceType.ToString().ToLowerInvariant()}""";
            }

            return string.Empty;
        }
        private string GetSecurity()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (Security == SecurityEnum.NotSet)
                {
                    return string.Empty;
                }

                return $@" security=""{Security.ToString().ToLowerInvariant()}""";
            }

            return string.Empty;
        }
        private string GetEdge()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (Edge == EdgeEnum.NotSet)
                {
                    return string.Empty;
                }

                return $@" edge=""{Edge.ToString().ToLowerInvariant()}""";
            }

            return string.Empty;
        }
        private string GetProfile()
        {
            if (Profile == ProfileEnum.NotSet)
            {
                return string.Empty;
            }
            return $@" profile=""{Profile.ToString().ToLowerInvariant().Replace(" ", "")}""";
        }
        private string GetEnable()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (Enable)
                {
                    return $@" enable=""yes""";
                }

                return $@" enable=""no""";
            }
            return string.Empty;
        }
        private string GetDescription()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (string.IsNullOrWhiteSpace(Description))
                {
                    return string.Empty;
                }

                return $@" description=""{Description}""";
            }
            return string.Empty;
        }
        private string GetProgram()
        {
            if (string.IsNullOrWhiteSpace(Program))
            {
                return string.Empty;
            }
            return $@" program=""{Program}""";
        }
        private string GetService()
        {
            if (Service == ServiceEnum.NotSet)
            {
                return string.Empty;
            }
            return $@" service=""{Service.ToString().ToLowerInvariant()}""";
        }
        private string GetRemotePort()
        {
            if (RemotePort == RemotePortEnum.Any)
            {
                return $@" remoteport=""any""";
            }
            if (RemotePort == RemotePortEnum.Specific)
            {
                var ports = string.Join(",", SpecificRemotePorts);
                var ranges = string.Join(",", SpecificRangesRemotePorts.Select(tupla => $"{tupla.inicio}-{tupla.fin}"));

                if (string.IsNullOrWhiteSpace(ports) && string.IsNullOrWhiteSpace(ranges))
                {
                    return string.Empty;
                }

                if (ranges.Length > 0)
                {
                    if (ports.Length > 0)
                    {
                        ports += "," + ranges;
                    }
                    else
                    {
                        ports = ranges;
                    }
                }

                return $@" remoteport=""{ports}""";
            }
            return string.Empty;
        }
        private string GetLocalPort()
        {
            if (LocalPort == LocalPortEnum.Any)
            {
                return $@" localport=""any""";
            }
            if (LocalPort == LocalPortEnum.RcpEpmap)
            {
                return $@" localport=""rpc-epmap""";
            }

            if (LocalPort == LocalPortEnum.Rcp ||
                LocalPort == LocalPortEnum.Iphttps ||
                LocalPort == LocalPortEnum.Teredo)
            {

                return $@" localport=""{LocalPort.ToString().ToLowerInvariant()}""";
            }

            if (LocalPort == LocalPortEnum.Specific)
            {
                var ports = string.Join(",", SpecificLocalPorts);
                var ranges = string.Join(",", SpecificRangesLocalPorts.Select(tupla => $"{tupla.inicio}-{tupla.fin}"));

                if (string.IsNullOrWhiteSpace(ports) && string.IsNullOrWhiteSpace(ranges))
                {
                    return string.Empty;
                }

                if (ranges.Length > 0)
                {
                    if (ports.Length > 0)
                    {
                        ports += "," + ranges;
                    }
                    else
                    {
                        ports = ranges;
                    }
                }

                return $@" localport=""{ports}""";
            }
            return string.Empty;
        }
        private string GetDir()
        {
            if (string.IsNullOrWhiteSpace(Action.ToString()))
            {
                throw new ArgumentException("El parámetro dir es un campo obligatorio ");
            }
            return $@" dir=""{Dir.ToString().ToLowerInvariant()}""";
        }
        private string GetProtocol()
        {
            if (Protocol == ProtocolEnum.NotSet)
            {
                return string.Empty;
            }
            if (Protocol == ProtocolEnum.Icmpv4TypeCode)
            {
                return $@" protocol=""icmpv4:type,code""";
            }
            if (Protocol == ProtocolEnum.Icmpv6TypeCode)
            {
                return $@" protocol=""icmpv6:type,code""";
            }

            return $@" protocol=""{Protocol.ToString().ToLowerInvariant()}""";
        }
        private string GetAction()
        {
            if (Command == CommandEnum.AddRule)
            {
                if (string.IsNullOrWhiteSpace(Action.ToString()))
                {
                    throw new ArgumentException("El parámetro action es un campo obligatorio ");
                }

                return $@" action=""{Action.ToString().ToLowerInvariant()}""";
            }

            return string.Empty;
        }
        private string GetName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("El parámetro name es un campo obligatorio y no puede estar vacío");
            }
            return $@" name=""{Name}""";
        }
        private void Execute(string command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command)
            {
                // Indicamos que la salida del proceso se redireccione en un Stream
                RedirectStandardOutput = true,
                UseShellExecute = false,
                //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
                CreateNoWindow = true
            };
            //Inicializa el proceso
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            ExecutionOutput = proc.StandardOutput.ReadToEnd();
            //Muestra en pantalla la salida del Comando
            Console.WriteLine(ExecutionOutput);
        }

        // Especifica que solo los paquetes de red que se autentican como provenientes o dirigidos a una computadora identificada en la lista de computadoras y
        // cuentas de grupo coinciden con esta regla.Si se especifica rmtcomputergrp, entonces la seguridad debe configurarse para autenticar o autenticar.
        // entonces se debe especificar al menos una cuenta de computadora o grupo de computadoras en rmtcomputergrp. 
        //    [rmtcomputergrp = SDDLString]
        // Especifica que solo los paquetes de red que se autentican como provenientes o dirigidos a un usuario identificado en la lista de cuentas de usuarios y grupos coinciden con esta regla.
        // Si se especifica rmtusrgrp, entonces la seguridad debe configurarse para autenticar o autenticar.
        // el tráfico de la red debe autenticarse mediante una credencial que lleve la información de la cuenta del usuario.
        //    [rmtusrgrp = SDDLString]

        private enum CommandEnum
        {
            AddRule,
            DeleteRule,
            SetRule,
            ShowRule
        }
        /// <summary>
        /// Especifica que los paquetes de red con números de puerto IP coincidentes coinciden con esta regla. El puerto remoto se compara con el campo Puerto de destino de un paquete de red saliente. Se compara con el campo Puerto de origen de un paquete de red entrante.
        /// Los intervalos de puertos solo se admiten en equipos que ejecutan Windows 7 o Windows Server 2008 R2.
        /// Se pueden especificar varias entradas para puerto remoto separándolas con una coma. No incluya ningún espacio. Si no se especifica puerto remoto, el valor predeterminado es cualquiera.
        /// </summary>
        private enum RemotePortEnum
        {
            /// <summary>
            /// NotSet. Este campo no es obligatorio y este el valor por defecto
            /// </summary>
            NotSet,
            /// <summary>
            /// any.Coincide con cualquier valor en el campo de puerto del paquete IP.
            /// </summary>
            Any,
            /// <summary>
            /// specific.Especifica el número de puerto exacto que debe estar presente para que el paquete coincida con la regla.Los valores de puerto pueden ser números individuales, un rango, como 5000-5020, o una lista de números y rangos separados por comas.
            /// </summary>
            Specific
        }
        private enum LocalIpEnum
        {
            /// <summary>
            /// NotSet. Este campo no es obligatorio y este el valor por defecto
            /// </summary>
            NotSet,
            /// <summary>
            /// Specific. Este campo especifica que tiene contenido
            /// </summary>
            Specific
        }
        private enum RemoteIpEnum
        {
            /// <summary>
            /// NotSet. Este campo no es obligatorio y este el valor por defecto
            /// </summary>
            NotSet,
            /// <summary>
            /// Specific. Este campo especifica que tiene contenido
            /// </summary>
            Specific
        }
    }
}
