namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica que los paquetes de red con un protocolo IP coincidente coinciden con esta regla.
    /// Se pueden especificar varias entradas para el protocolo separándolas con una coma.No incluya ningún espacio.
    /// Si no se especifica el protocolo, el valor predeterminado es cualquiera.
    /// </summary>
    public enum ProtocolEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        /// <summary>
        /// any.Coincide con cualquier valor en el campo Protocolo del paquete IP.
        /// </summary>
        Any,
        /// <summary>
        /// Integer.Especifica el protocolo por número que debe estar presente para que el paquete coincida con la regla.El valor puede oscilar entre 0 y 255.
        /// </summary>
        Integer,
        /// <summary>
        /// icmpv4.Especifica que todos los paquetes ICMP v4 coinciden con esta regla.
        /// </summary>
        Icmpv4,
        /// <summary>
        /// icmpv6.Especifica que todos los paquetes ICMP v6 coinciden con esta regla.
        /// </summary>
        Icmpv6,
        /// <summary>
        /// icmpv4:tipo, código.Especifica que solo los paquetes de red ICMP v4 con el tipo y código especificados coinciden con esta regla.El tipo y el código pueden ser la palabra clave any o un número entero entre 0 y 255.
        /// </summary>
        Icmpv4TypeCode,//icmpv4:type,code
        /// <summary>
        /// icmpv6:tipo, código.Especifica que solo los paquetes de red ICMP v6 con el tipo y código especificados coinciden con esta regla.El tipo y el código pueden ser la palabra clave any o un número entero entre 0 y 255.
        /// </summary>
        Icmpv6TypeCode,//icmpv6:type,code
        /// <summary>
        /// tcp.Especifica que solo el tráfico TCP dirigido hacia o desde los puertos identificados por localport y remoteport coincide con esta regla.
        /// </summary>
        Tcp,
        /// <summary>
        ///  upp.Especifica que solo el tráfico UDP dirigido hacia o desde los puertos identificados por localport y remoteport coincide con esta regla.
        /// </summary>
        Udp
    }
}