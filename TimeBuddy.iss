[Setup]
AppCopyright=Copyright © 2011 5amsoftware
AppName=TimeBuddy
AppVerName=TimeBuddy version 1.2.1
DefaultDirName={pf}\TimeBuddy
AppID={{F19F4D39-62FE-4A0E-B503-FE888AB0173F}
DefaultGroupName=TimeBuddy
VersionInfoVersion=1.2.1
VersionInfoCompany=5amsoftware
VersionInfoDescription=TimeBuddy
VersionInfoCopyright=Copyright © 2011 5amsoftware
OutputBaseFilename=TimeBuddy_Setup
AppPublisherURL=http://www.5amsoftware.com/
AppSupportURL=http://www.5amsoftware.com/
AppUpdatesURL=http://www.5amsoftware.com/

[Components]

[Files]
Source: .\TimeBuddy\bin\Release\TimeBuddy.exe; DestDir: {app}; 
Source: .\ChangeLog.txt; DestDir: {app}; 
Source: .\Help\TimeBuddy Help.chm; DestDir: {app}; 

[Icons]
Name: {group}\TimeBuddy; Filename: {app}\TimeBuddy.exe; WorkingDir: {app}; 
Name: "{group}\TimeBuddy Help"; Filename: {app}\TimeBuddy Help.chm; WorkingDir: {app}; 
Name: "{group}\Change Log"; Filename: {app}\ChangeLog.txt; WorkingDir: {app}; 
Name: "{group}\Uninstall TimeBuddy"; Filename: {uninstallexe}; 

[code]

/////////////////////////////////////////////////////////////////////
function GetUninstallString(): String;
var
  sUnInstPath: String;
  sUnInstallString: String;
begin
  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppId")}_is1');
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;


/////////////////////////////////////////////////////////////////////
function IsUpgrade(): Boolean;
begin
  Result := (GetUninstallString() <> '');
end;


/////////////////////////////////////////////////////////////////////
function UnInstallOldVersion(): Integer;
var
  sUnInstallString: String;
  iResultCode: Integer;
begin
// Return Values:
// 1 - uninstall string is empty
// 2 - error executing the UnInstallString
// 3 - successfully executed the UnInstallString

  // default return value
  Result := 0;

  // get the uninstall string of the old app
  sUnInstallString := GetUninstallString();
  if sUnInstallString <> '' then begin
    sUnInstallString := RemoveQuotes(sUnInstallString);
//    if Exec(sUnInstallString, '/SILENT /NORESTART /SUPPRESSMSGBOXES','', SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    if Exec(sUnInstallString, '','', 0, ewWaitUntilTerminated, iResultCode) then
      Result := 3
    else
      Result := 2;
  end else
    Result := 1;
end;

function InitializeSetup(): Boolean;
var
  present: boolean;
begin
  present := true;

  // Check for .NET 4.0
  if not RegKeyExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4') then
  begin
    MsgBox('Microsoft .NET framework version 4.0 is a prerequisite of this software.', mbInformation, MB_OK);
    present := false;
  end;

  // Only do this if pre-reqs are met
  if present then
  begin
    if IsUpgrade() then
    begin
      MsgBox('A previously installed version was found. It will be uninstalled first.', mbInformation, MB_OK);
      UnInstallOldVersion();
    end;
  end;

  Result := present;
end;
