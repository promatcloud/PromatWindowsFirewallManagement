<h1 align="center">
<img src="https://raw.githubusercontent.com/promatcloud/Branding/master/icons/org/promat.512.png" alt="promat" width="256"/>
 <br/>
 PromatWindowsFirewallManagement
</h1>

<div align="center">

[![Build status](https://ci.appveyor.com/api/projects/status/k3b39mkery9g5ke5?svg=true)](https://ci.appveyor.com/project/promatcloud/promatwindowsfirewallmanagement)
[![NuGet Badge](https://buildstats.info/nuget/PromatWindowsFirewallManagement?includePreReleases=true)](https://www.nuget.org/packages/PromatWindowsFirewallManagement/)

</div>
Library to add or remove rules to windows firewall from c# code.

PromatWindowsFirewallManagement está diponible por **NuGet [PromatWindowsFirewallManagement](https://www.nuget.org/packages/PromatWindowsFirewallManagement/)**

# Generalidades
The library is implemented in netstandard 2, so it can be used in all types of projects:

	Both in core and full framework we have to instantiate the WindowsFirewallRule class,  
	on it we can define the configuration of the rule.
	
	In the configuration we have to take into account that the Name, Dir and Action parameters are mandatory
	
	Once configured we can use its AddRule method to add the rule or DeleteRule to delete it.

# Net Core & Full Framework
Configuration:

```
       var rule = new WindowsFirewallRule
       {
         Name = "Microsoft SQL Server 2014 TCP Port 1433",
         Dir = DirEnum.In,
         Action = ActionEnum.Allow,
         Protocol = ProtocolEnum.Tcp,
         Profile = ProfileEnum.Private | ProfileEnum.Domain
       };
       rule.AddLocalPorts(1433);
```

Add / Delete:

```
       rule.AddRule();               
       rule.DeleteRule();
```  
