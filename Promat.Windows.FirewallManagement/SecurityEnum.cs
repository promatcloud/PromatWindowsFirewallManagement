namespace Promat.Windows.FirewallManagement
{
    /// <summary>
    /// Especifica que solo los paquetes de red protegidos con el tipo especificado de opciones de IPsec coinciden con esta regla.
    /// Esta opción es útil para conexiones que deben ser monitoreadas por equipos de red, como sistemas de detección de intrusos (IDS), que no son compatibles con paquetes de red protegidos con ESP NULL.
    /// La conexión inicial se autentica mediante IPsec mediante AuthIP, pero el SA de modo rápido permite el tráfico de texto no cifrado.Para usar esta opción, también debe configurar una regla de seguridad de conexión que especifique authnoencap como método de seguridad de modo rápido.
    /// Si no se especifica la seguridad, no se requiere el valor predeterminado.
    /// </summary>
    public enum SecurityEnum
    {
        /// <summary>
        /// NotSet. Este campo no es obligatorio y este el valor por defecto
        /// </summary>
        NotSet,
        /// <summary>
        /// authenticate.Los paquetes de red autenticados por IPsec cumplen esta regla.Debe crear una regla de seguridad de conexión separada para autenticar el tráfico. Esta opción es equivalente a Permitir solo conexiones seguras en el complemento MMC de Firewall de Windows con seguridad avanzada.
        /// </summary>
        Authenticate,
        /// <summary>
        /// authenc.Los paquetes de red autenticados y cifrados por IPsec cumplen esta regla. Debe crear una regla de seguridad de conexión independiente para autenticar y cifrar el tráfico.Esta opción es equivalente a la opción Requerir cifrado en el complemento Firewall de Windows con seguridad avanzada de MMC.
        /// </summary>
        Authenc,
        /// <summary>
        /// Authdynenc.Los paquetes de red autenticados por IPsec cumplen esta regla y, si el paquete inicial aún no está cifrado, se negocia una nueva SA de modo rápido con el host remoto para cifrar la conexión. Todos los paquetes subsiguientes son autenticados y encriptados. Si falla la negociación de una SA de cifrado de modo rápido, el cortafuegos bloquea la conexión.Debe crear una regla de seguridad de conexión independiente que requiera autenticación y cifrado para permitir la negociación de una SA cifrada adecuada.Esta opción es el equivalente de Permitir que los sistemas negocien dinámicamente el cifrado en el complemento Firewall de Windows con seguridad avanzada de MMC.
        /// </summary>
        Authdynenc,
        /// <summary> 
        /// Esta opción es válida solo para reglas de firewall entrantes.Esta opción solo está disponible en equipos que ejecutan Windows 7 o Windows Server 2008 R2.
        /// Las políticas de grupo creadas con esta opción son compatibles con equipos que ejecutan Windows Vista o versiones posteriores de Windows.
        /// authnoencap.Las conexiones de red autenticadas, pero no encapsuladas por ESP o AH, cumplen con esta regla.
        /// </summary>
        Authnoencap,
        /// <summary> 
        /// Esta opción es válida solo en equipos que ejecutan Windows 7 o Windows Server 2008 R2.
        /// notrequired.Cualquier paquete de red coincide con esta regla, esté o no protegido por IPsec.
        /// Esta opción es el equivalente a no seleccionar la opción Permitir solo conexiones seguras en el complemento Firewall de Windows con seguridad avanzada de MMC.
        /// </summary>
        Notrequired
    }
}