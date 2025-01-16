# Vad

En exempelsite med databas, som kan användas för att visa hur publicering kan göras

# Secrets.js

Skapa en fil secrets.json utifrån secrets.sample.json och fyll i dina egna värden.

# Starta lokalt

Kör detta kommando för att skapa en ny databas lokalt. Ändra portnumret och lösenordet till dina egna värden.

    $env:PGPASSWORD="password"; psql -U postgres -f reset-database.sql -p 5434

Kör detta för att skapa tabeller i databasen.

    dotnet ef database update

Kör detta för att starta servern.

    dotnet run

Om du nu går in till http://localhost:5106/TestDatabase så ska du kunna trycka på "Add Random Product" för att lägga till ett nytt produkt. Produkterna sparas i databasen.





<?xml version="1.0" encoding="utf-8"?>
<!--
This file is used by the publish/package process of your Web project. You can customize the behavior of this process
by editing this MSBuild file. In order to learn more about this please visit https://go.microsoft.com/fwlink/?LinkID=208121. 
-->
<Project>
  <PropertyGroup>
    <WebPublishMethod>MSDeploy</WebPublishMethod>
    <!-- <LaunchSiteAfterPublish>true</LaunchSiteAfterPublish> -->
    <!-- <LastUsedBuildConfiguration>Release</LastUsedBuildConfiguration>
    <LastUsedPlatform>Any CPU</LastUsedPlatform> -->
    <!-- <SiteUrlToLaunchAfterPublish>🤡happybits.se</SiteUrlToLaunchAfterPublish> -->
    <!-- <ExcludeApp_Data>false</ExcludeApp_Data> -->
    <!-- <ProjectGuid>4457d2ac-f74e-4614-ab19-f9ef7c4a9bd2</ProjectGuid> -->
    <SelfContained>true</SelfContained>
    <MSDeployServiceURL>🤡nt40.unoeuro.com</MSDeployServiceURL>
    <DeployIisAppPath>🤡happybits.se</DeployIisAppPath>
    <!-- <RemoteSitePhysicalPath /> -->
    <!-- <SkipExtraFilesOnServer>false</SkipExtraFilesOnServer> -->
    <MSDeployPublishMethod>WMSVC</MSDeployPublishMethod>
    <!-- <EnableMSDeployBackup>true</EnableMSDeployBackup> -->
    <UserName>🤡happybits.se</UserName>
    <!-- <_SavePWD>true</_SavePWD> -->
    <TargetFramework>net9.0</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <EnableMsDeployAppOffline>true</EnableMsDeployAppOffline>
    <!-- <ExcludeFilesFromDeployment>Happybits.db*</ExcludeFilesFromDeployment> -->
  </PropertyGroup>
</Project>