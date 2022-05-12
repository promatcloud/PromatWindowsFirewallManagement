namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Required. Especifica lo que hace el Firewall de Windows con seguridad avanzada para filtrar los paquetes de red que coinciden con los criterios especificados en esta regla. La acción puede ser una de las siguientes:
    /// Para equipos que ejecutan Windows 7 o Windows Server 2008 R2, se permite action= bypass en una regla de salida.Al seleccionar esta opción en una regla de salida, se permite el tráfico coincidente a través de esta regla, incluso si otras reglas coincidentes bloquearían el tráfico. No se requieren cuentas en rmtcomputergrp o rmtusergrp para una regla de omisión de salida; sin embargo, si los equipos autorizados o exceptuados se enumeran en esos grupos, se aplicarán.
    /// La opción action=bypass en una regla de salida no es válida en equipos que ejecutan versiones anteriores de Windows.
    /// </summary>
    public enum ActionEnum
    {
        /// <summary>
        /// allow.Los paquetes de red que cumplen todos los criterios especificados en esta regla se permiten a través del firewall. 
        /// </summary>
        Allow,
        /// <summary>
        /// block.El cortafuegos descarta los paquetes de red que cumplen todos los criterios especificados en esta regla. 
        /// </summary>
        Block,
        /// <summary>
        /// bypass.Si dir=in, esta opción solo es válida para las reglas que tienen una o más cuentas enumeradas en rmtcomputergrp y, opcionalmente, rmtusrgrp.Los paquetes de red que coinciden con esta regla y que se autentican con éxito contra una cuenta de computadora especificada en rmtcomputergrp y contra una cuenta de usuario identificada en rmtusrgrp se permiten a través del firewall. Si especifica esta opción, no puede establecer security = notrequired.Esta opción es equivalente a la casilla de verificación Anular reglas de bloqueo en el complemento Firewall de Windows con seguridad avanzada de MMC. 
        /// </summary>
        Bypass
    }
}