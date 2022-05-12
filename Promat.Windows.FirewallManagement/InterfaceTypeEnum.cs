namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica que solo los paquetes de red que pasan a través de los tipos de interfaz indicados coinciden con esta regla.
    /// El uso de este parámetro le permite especificar diferentes requisitos de firewall para cada uno de los tres tipos de red principales.
    /// Si no se especifica el tipo de interfaz, el valor predeterminado es cualquiera.
    /// </summary>
    public enum InterfaceTypeEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        /// <summary>
        /// any. Los paquetes de red que pasan a través de cualquiera de los tipos de interfaz coinciden con esta regla.
        /// </summary>
        Any,
        /// <summary>
        /// wireless. Los paquetes de red que pasan a través de un adaptador de red inalámbrico coinciden con esta regla.
        /// </summary>
        Wireless,
        /// <summary>
        /// lan. Los paquetes de red que pasan a través de un adaptador LAN cableado cumplen esta regla.
        /// </summary>
        Lan,
        /// <summary>
        /// ras. Los paquetes de red que pasan a través de una interfaz RAS, como una VPN o una conexión de red de acceso telefónico, coinciden con esta regla.
        /// </summary>
        Ras
    }
}