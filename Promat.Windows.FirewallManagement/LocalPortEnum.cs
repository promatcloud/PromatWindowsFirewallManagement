namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica que los paquetes de red con números de puerto IP coincidentes coinciden con esta regla.
    /// localport se compara con el campo Puerto de origen de un paquete de red saliente. Se compara con el campo Puerto de destino de un paquete de red entrante.
    /// Se pueden especificar varias entradas para localport separándolas con una coma.No incluya ningún espacio. Si no se especifica localport, el valor predeterminado es any.
    /// </summary>
    public enum LocalPortEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        /// <summary>
        ///  any.Coincide con cualquier valor en el campo de puerto del paquete IP.
        /// </summary>
        Any,
        /// <summary>
        /// Integer.Especifica el número de puerto exacto que debe estar presente para que el paquete coincida con la regla.
        /// Los valores de puerto pueden ser números individuales del 0 al 65535, un rango, como 5000-5020, o una lista de números y rangos separados por comas.
        /// Nota
        /// Los intervalos de puertos solo se admiten en equipos que ejecutan Windows 7 o Windows Server 2008 R2.
        /// </summary>
        Specific,
        /// <summary>
        /// rpc.Hace coincidir los paquetes TCP entrantes que se dirigen al socket de escucha de una aplicación que registra correctamente el
        /// puerto como un puerto de escucha RPC.Una regla con esta opción también debe especificar protocol = tcp y dir = in.
        /// Le recomendamos que también especifique las opciones program = ProgramName y/o service = ServiceName adecuadas para garantizar
        /// que solo el servicio correcto pueda enviar o recibir tráfico mediante este regla.
        /// Esta opción elimina la necesidad de conocer los números de puerto específicos asignados a la aplicación cuando se inicia.
        /// </summary>
        Rcp,
        /// <summary>
        /// rpc-epmap.Coincide con los paquetes TCP entrantes que se dirigen al servicio de asignación de extremos de RPC dinámica.
        /// Una regla con esta opción también debe especificar protocol = tcp y dir = in.
        /// Le recomendamos que también especifique program = % windir %\system32\svchost.exe y service = rpcss para garantizar que solo
        /// el servicio RPC pueda enviar o recibir tráfico de red mediante el uso de esta regla. Esta opción elimina la necesidad de conocer
        /// los números de puerto específicos asignados al servicio cuando se inicia. Si tiene una o más reglas que especifican localport = rpc,
        /// también debe crear una regla con localport = rpc - epmap habilitado.Esto permite tanto la solicitud entrante al mapeador como
        /// los paquetes posteriores a los puertos efímeros asignados por el servicio RPC.
        /// </summary>
        RcpEpmap, //rcp-epmap
        /// <summary>
        /// iphttps.Hace coincidir los paquetes TCP entrantes que contienen HTTPS con paquetes IPv6 integrados.IP-HTTPS es un protocolo
        /// transversal de cortafuegos que permite paquetes IPv6 que, de otro modo, se bloquearían si se enviaran mediante Teredo,
        /// 6to4 o IPv6 nativo. HTTPS se permite casi universalmente a través de un firewall, por lo que IP sobre HTTPS es otro mecanismo
        /// que se puede usar cuando un firewall no admite otros protocolos transversales de borde.
        /// La opción IP-HTTPS es válida solo en equipos que ejecutan Windows 7 o Windows Server 2008 R2 y se ignora si la directiva de grupo
        /// la aplica a equipos que ejecutan versiones anteriores de Windows.
        /// </summary>
        Iphttps,
        /// <summary>
        /// Teredo.Coincide con los paquetes UDP entrantes que contienen paquetes Teredo. Teredo es una tecnología de transición de IPv4 a IPv6
        /// que permite que las computadoras IPv4 se comuniquen con las computadoras IPv6.
        /// </summary>
        Teredo
    }
}