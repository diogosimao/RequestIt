# RequestIt

##Requirements

```
PM> Install-Package EntityFramework -Version 6.1.3
```

##Requirements (outros)

Necessário em casos que a versão do Visual Studio não inclui os controles Reporting

```
PM> Install-Package Microsoft.ReportViewer.Common
PM> Install-Package Microsoft.ReportViewer.WinForms
```

##Database setup

Instruções para sua criação do banco de dados no ambiente do cliente final

- O banco de dado relacional SQL Server Express 2016 Edition. 
- O script para criação do bando de dados encontra-se no arquivo \Database\script.sql. 
- Banco de dados com o nome RequestIt deve ser criado e em seguida o script pode ser executado. 
- O arquivo RequestIt.exe.config deve ser alterado para condizer com a nova instância no campo Data Source= 
- O campo data source aparece na linha 11 e linha 14.

