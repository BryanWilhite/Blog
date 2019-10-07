---json
{
  "author": "Bryan Wilhite",
  "content": "My conventional drive E:\\ (SonghayHomeDrive) has been moved to this new virtual machine (VM). This move migrated the serious permission problems I was trying to ignore on my last VM. My 2009 FunkyKB article, “Windows Server 2008: Notes on Moving a Hard D...",
  "inceptDate": "2012-09-19T16:08:00",
  "isPublished": true,
  "slug": "the-songhay-home-drive-on-a-new-vm",
  "title": "The Songhay Home Drive on a new VM"
}
---

My conventional drive E:\ (`SonghayHomeDrive`) has been moved to this new virtual machine (VM). This move migrated the serious permission problems I was trying to ignore on my last VM. My 2009 FunkyKB article, “[Windows Server 2008: Notes on Moving a Hard Drive to a New Machine; Orphaned SIDs; TAKEOWN.EXE; ICACLS.EXE; Get-Acl; Set-Acl](http://songhaysystem.com/kb/number/2076072285/subject/winos),” would have helped a great deal to get the problem fixed instead of ignored. The first two steps mentioned in this article were definitely needed. In addition, I took a screenshot of this command:


ICACLS \myRootShareFolder ^
    /grant SYSTEM: (CI) (OI) (IO) (F) ^
    /grant Administrators: (CI) (OI) (IO) (F) ^
    /grant Users: (CI) (OI) (IO) (RX) ^
    /grant SYSTEM: (F) ^
    /grant Administrators: (F) ^
    /grant Users: (RX) ^
    /t /l /q


Taking this new pattern with my 2009 notes, we might work with this script:


TAKEOWN /f E:\myRootShareFolder /a



ICACLS E:\myRootShareFolder /reset /t



ICACLS \myRootShareFolder ^
    /grant SYSTEM:(CI)(OI)(IO)(F) ^
    /grant Administrators:(CI)(OI)(IO)(F) ^
    /grant Users:(CI)(OI)(IO)(RX) ^
    /grant SYSTEM:(F) ^
    /grant Administrators:(F) ^
    /grant Users:(RX) ^
    /t /l /q


What is definitely missing from this general-purpose approach is some support for that conventional Internet Information Server (IIS) User—let’s take the one for IIS 7.x:


ICACLS \myRootShareFolder\myCustomWebRoot ^
    /grant IIS_IUSRS:(CI)(OI)(IO)(RX) ^
    /t /l /q


## Related Links

*   “[Icacls: The New and Improved Cacls?](http://www.windowsitpro.com/article/permissions/icacls-the-new-and-improved-cacls-)”
*   “[.net 4.0: ASP.NET MVC on IIS 7.5—Stack Overflow](http://stackoverflow.com/questions/2374957/asp-net-mvc-on-iis-7-5)” —this is the 32-bit command: `%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -ir`.
*   “[500.19 Internal Server Error : The Official Microsoft IIS Site](http://forums.iis.net/t/1179352.aspx)” —I don’t this fix was needed in view of the [statckoverflow.com article](http://stackoverflow.com/questions/2374957/asp-net-mvc-on-iis-7-5) (the command: `%windir%\system32\inetsrv\appcmd unlock config -section:system.webServer/modules`).
