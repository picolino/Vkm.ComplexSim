; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define AuthorName 'Danila Chervonny'
#define ApplicationName 'Complex Simulator'
#define ApplicationVersion GetFileVersion('..\bin\Release\Vkm.ComplexSim.exe')

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4C45B9F4-AFA9-4C6B-88D1-1236FE078B8D}
AppName={#ApplicationName}
AppVersion={#ApplicationVersion}
AppVerName={#ApplicationName} {#ApplicationVersion}
AppPublisher={#AuthorName}
DefaultDirName={pf}\{#ApplicationName}
DefaultGroupName={#ApplicationName}
AllowNoIcons=yes
OutputBaseFilename={#ApplicationName} Installer
Compression=lzma
SolidCompression=yes
AppCopyright={#AuthorName}
PrivilegesRequired=none
AppContact=webmaster.pico@gmail.com
SetupIconFile=..\logo.ico
VersionInfoVersion={#ApplicationVersion}
VersionInfoCopyright={#AuthorName}
VersionInfoProductName={#ApplicationName}
AppPublisherURL=https://picolino.github.io/
AppSupportURL=https://picolino.github.io/
VersionInfoProductVersion={#ApplicationVersion}
LicenseFile=..\LICENSE.txt
UninstallDisplayName={#ApplicationName}
UninstallDisplayIcon={app}\logo.ico

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "..\bin\Release\Appccelerate.CommandLineParser.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\Appccelerate.Fundamentals.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\DevExpress.Mvvm.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\DevExpress.Mvvm.UI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\Vkm.ComplexSim.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\Vkm.ComplexSim.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\XAMLEx.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\LiveCharts.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\LiveCharts.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\LICENSE.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Documentation.xps"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\logo.ico"; DestDir: "{app}"; Flags: ignoreversion
; .NET Framework 4.7
Source: "NDP47-KB3186497-x86-x64-AllOS-ENU.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

[Icons]
Name: "{group}\Complex Simulator"; Filename: "{app}\Vkm.ComplexSim.exe"
Name: "{commondesktop}\Complex Simulator"; Filename: "{app}\Vkm.ComplexSim.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Vkm.ComplexSim.exe"; Description: "{cm:LaunchProgram,Complex Simulator}"; Flags: nowait postinstall skipifsilent
Filename: "{tmp}\NDP47-KB3186497-x86-x64-AllOS-ENU.exe"; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: ��������������� Microsoft .NET 4.7... ����������, ���������.

[Code]

#include "dotnet.pas"
#include "urlValid.pas"

//-----------------------------------------------------------------------------
//    Check DotNetFramework Installed
//-----------------------------------------------------------------------------

function IsRequiredDotNetDetected(): boolean;
begin
    result := IsDotNetDetected('v4.7', 460798);
end;

function InitializeSetup(): boolean;
begin
  if not IsDotNetDetected('v4.7', 460798) then
    begin
      MsgBox('Complex Simulator ��������� � ��������� .NET Framework 4.7.'#13
             '������ ����� ����������� ��������� ������������ ����������', mbInformation, MB_OK);
    end;   

  result := true;
end;

//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
//    Add Url Master Server Field
//-----------------------------------------------------------------------------

const
 InputQueryPageID = 100;

var
AppConfigPage : TInputQueryWizardPage;

procedure InitializeWizard;
begin
AppConfigPage := CreateInputQueryPage(wpLicense,
    '��������� ������������', '����������, ��������� ������������, ������������ �� ������',
    '');
  AppConfigPage.Add('������ �����������������:', False);

  AppConfigPage.Values[0] := 'http://192.168.1.2/';
end;

function NextButtonClick(pageId: Integer): Boolean;

var validated : boolean;

begin
  case pageId of
   InputQueryPageID   : begin
                 validated := ValidateUrl(AppConfigPage.Values[0]);
                 if validated then
                 begin
                      result := true;
                 end
                 else
                 begin
                     MsgBox('�������� ������ Url',mbError,MB_OK);
                     result := false;
                 end;
               end;
   else result := true;
 end;
end;

function FileReplaceString(ReplaceString: string):boolean;
var
  MyFile : TStrings;
  MyText : string;
begin
  Log('Replacing in file');
  MyFile := TStringList.Create;

  try
    Result := true;

    try
      MyFile.LoadFromFile(ExpandConstant('{app}' + '\Vkm.ComplexSim.exe.config'));
      Log('File loaded');
      MyText := MyFile.Text;

      { Only save if text has been changed. }
      if StringChangeEx(MyText, '{AdminBaseAddress}', ReplaceString, True) > 0 then
      begin;
        Log('IP address inserted');
        MyFile.Text := MyText;
        MyFile.SaveToFile(ExpandConstant('{app}' + '\Vkm.ComplexSim.exe.config'));
        Log('File saved');
      end;
    except
      Result := false;
    end;
  finally
    MyFile.Free;
  end;

  Result := True;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    Log('File installed, replacing IP address');
    FileReplaceString(AppConfigPage.Values[0]);
  end;
end;

//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------