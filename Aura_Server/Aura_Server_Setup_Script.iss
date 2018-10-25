; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{29C22713-5BA8-4BA3-9AFB-FF5AE93499FB}
AppName=Aura_Server
AppVersion=1.0.3.2
;AppVerName=Aura_Server 1.0.3.2
AppPublisher=ASTIKS
DefaultDirName={pf}\Aura_Server
DefaultGroupName=Aura_Server
AllowNoIcons=yes
OutputBaseFilename=setup
SetupIconFile=C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\MainIcon.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Aura_Server.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Aura_DLL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Aura_Server.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Aura_Server.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\AuraDataBase.sqlite"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\AuraDataBase_ForLogs.sqlite"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\connect settings.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\EntityFramework.SqlServer.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\EntityFramework.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\EnvDTE.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\ExcelDataReader.DataSet.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\ExcelDataReader.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Icon.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\ICSharpCode.SharpZipLib.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icudt49.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icudt50.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icuin49.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icuin50.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icuuc49.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\icuuc50.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\MainIcon.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Microsoft.VisualStudio.OLE.Interop.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Microsoft.VisualStudio.Shell.Interop.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Microsoft.VisualStudio.TextManager.Interop.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\SQLite.Designer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.Core.ICU.targets"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\System.Data.SQLite.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\Backups\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\����\Documents\Projects\Aura_Server\Aura_Server\bin\Debug\x86\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\Aura_Server"; Filename: "{app}\Aura_Server.exe"
Name: "{group}\{cm:UninstallProgram,Aura_Server}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Aura_Server"; Filename: "{app}\Aura_Server.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Aura_Server.exe"; Description: "{cm:LaunchProgram,Aura_Server}"; Flags: nowait postinstall skipifsilent
