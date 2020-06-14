---json
{
  "documentId": 0,
  "title": "The “Silverlight Business Application” Project and NTLM",
  "documentShortName": "2013-03-17-the-silverlight-business-application-project-and-ntlm",
  "fileName": "index.html",
  "path": "./entry/2013-03-17-the-silverlight-business-application-project-and-ntlm",
  "date": "2013-03-18T00:00:00Z",
  "modificationDate": "2013-03-18T00:00:00Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2013-03-17-the-silverlight-business-application-project-and-ntlm",
  "tag": "{\r\n  \"extract\": \"One very important detail that the classic “Silverlight Business Application” project has to teach us is how to use old-school NTLM authentication with Silverlight. This is a well-established but not very versatile/scalable way to authenticate users. In ...\"\r\n}"
}
---

# The “Silverlight Business Application” Project and NTLM

One very important detail that the classic “[Silverlight Business Application](http://msdn.microsoft.com/en-us/library/ee707360(v=vs.91).aspx)” project has to teach us is how to use old-school [NTLM](http://msdn.microsoft.com/en-us/library/windows/desktop/aa378749(v=vs.85).aspx) authentication with Silverlight. This is a well-established but not very versatile/scalable way to authenticate users. In the real world of the corporate enterprise, NTLM is the only way to go. The assumption today is that there are authentication alternatives that Microsoft would encourage such as [Microsoft Kerberos](http://msdn.microsoft.com/en-us/library/windows/desktop/aa378747(v=vs.85).aspx) or maybe [Active Directory Application Mode (ADAM)](http://msdn.microsoft.com/en-us/library/ff647400.aspx). The leading constraint on these Authentication alternatives is what ASP.NET supports out of the box. The other leading constraint would be a requirement that authentication depends on Active Directory as is—no domain-level modification, no LDAP-level customizations—and no secondary set of users to authenticate outside of Active Directory (stored in a database).

One unexpected takeaway from these notes is the assertion that we cannot have NTLM authentication without setting up ‘default’ ASP.NET profiles. The *defacto* default ASP.NET profile is represented by `AspNetSqlProfileProvider`. This implies that a SQL Server database is *required* to use NTLM—which seems very strange, encouraging us to look forward to finding out that the above assertion is incorrect.

## Setting up NTLM Authentication

In conventional Silverlight `App` constructor, state:

```cs
var webContext = new WebContext();
webContext.Authentication = new WindowsAuthentication();
this.ApplicationLifetimeObjects.Add(webContext);
```

In `App.Startup`, state:

```cs
WebContext.Current.Authentication.LoadUser(
        operation => Messenger.Default.Send(operation), null);
```

The MVVM Light Messenger expects this registration:

```cs
Messenger.Default.Register<LoadUserOperation>(this,
    operation =>
    {
        if (operation.HasError) return; //TODO: handle LoadUser() error.
        if (operation.User == null) return;
        var user = WebContext.Current.Authentication.User;
        this.CurrentUserName = user.Identity.GetWindowsUserName();
    });
```

…where `Identity.GetWindowsUserName()` is from [a custom extension method](http://pastebin.com/hmmEMmpg).

In the `system.web` node of `web.config`, declare:

```xml
<authorization>
        <deny users="?"/>
    </authorization>

<authentication mode="Windows" />
    <membership>
        <providers>
            <clear/>
        </providers>
    </membership>
    <roleManager enabled="false">
        <providers>
            <clear/>
        </providers>
    </roleManager>
    <profile>
        <providers>
            <clear/>
            <add name="AspNetSqlProfileProvider"
                type="System.Web.Profile.SqlProfileProvider"
                 connectionStringName="ApplicationServices"
                 applicationName="./" />
        </providers>
    </profile>
```

…where `connectionStringName="ApplicationServices"` refers to:

```xml
<add name="ApplicationServices" connectionString="Data Source=MyDbServer;Initial Catalog=MyDb;User ID=MyUser;Password=my!pwd;MultipleActiveResultSets=true" />
```

…where the Data Source contains tables setup by the `aspnet_regsql.exe` tool, covered in “[Installing ASP.NET Membership services database in SQL Server Express 2008](http://weblogs.asp.net/sukumarraju/archive/2009/10/02/installing-asp-net-membership-services-database-in-sql-server-expreess.aspx).” (An attempt to avoid doing all of this work with the `AspNetSqlProfileProvider`, might lead one to use the `System.Web.Security.WindowsTokenRoleProvider`, I found ne success here.)

## Setting up WCF over NTLM

Visual studio will automatically generate `ServiceReferences.ClientConfig` during the **Add Service Reference…** process. In the `configuration\system.serviceModel` node of this document we might have this declaration:

```xml
<bindings>
    <basicHttpBinding>
        <binding name="BasicHttpBinding"
            maxBufferSize="2147483647"
            maxReceivedMessageSize="2147483647">
            <security mode="None" />
        </binding>
    </basicHttpBinding>
</bindings>
```

To support NTLM, declare:

```xml
<bindings>
    <basicHttpBinding>
        <binding name="BasicHttpBinding"
            maxBufferSize="2147483647"
            maxReceivedMessageSize="2147483647">
            <security mode="TransportCredentialOnly" />
        </binding>
    </basicHttpBinding>
</bindings>
```

Visual studio will automatically generate a `system.serviceModel` node in `web.config`, during the **Add Service Reference…** process. We must add a binding in `system.serviceModel\bindings` to complement the one declared for the Client in `ServiceReferences.ClientConfig`:

```xml
<bindings>
    <basicHttpBinding>
        <binding>
            <security mode="TransportCredentialOnly">
                <transport clientCredentialType="Windows"/>
            </security>
        </binding>
    </basicHttpBinding>
</bindings>
```

## Setting up “Classic” NTLM Authentication on IIS 7.x

* Select **Authentication** from the Features View of Internet Information Services (IIS) Manager.
* Disable **Anonymous Authentication** (and all other forms of authentication).
* Enable **Windows Authentication** and select **Providers…** In the **Providers** dialog, move NTLM to the top of **Enabled Providers**.

## Related Links

* “[Walkthrough: Using the Silverlight Business Application Template](http://msdn.microsoft.com/en-us/library/ee707360(v=vs.91).aspx)”
* “[Installing ASP.NET Membership services database in SQL Server Express 2008—Sukumar Raju’s Blog](http://weblogs.asp.net/sukumarraju/archive/2009/10/02/installing-asp-net-membership-services-database-in-sql-server-expreess.aspx)”
* “[ASP.NET Forms Based Authentication with Active Directory](http://www.christowles.com/2011/04/aspnet-forms-based-authentication-with.html)”
* “[RIA Services fallback from WindowsAuthentication to FormsAuthentication?](http://social.msdn.microsoft.com/Forums/en-US/silverlightarchieve/thread/a565b6aa-e791-47f3-a472-223f379b7788/)”
* “[Integrated Windows Authentication](http://blogs.msdn.com/b/ieinternals/archive/2011/07/06/integrated-windows-authentication-kerberos-ntlm-http-400-error-for-16kb-authorization-header.aspx)”
* “[ASP.NET NTLM Authentication—is it worth it?](http://www.codinghorror.com/blog/2005/04/aspnet-ntlm-authentication---is-it-worth-it.html)”

@[BryanWilhite](https://twitter.com/BryanWilhite)
