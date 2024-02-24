<div align='center'>

<p>With .Net Core, it allows you to keep the json files of your applications securely encrypted on your remote server and easily integrate them into your applications.</p>

<h4> <span> · </span> <a href="https://github.com/alizorlu/RConfig/blob/master/README.md"> Documentation </a> <span> · </span> <a href="https://github.com/alizorlu/RConfig/issues"> Report Bug </a> <span> · </span> <a href="https://github.com/alizorlu/RConfig/issues"> Request Feature </a> </h4>


</div>

# :notebook_with_decorative_cover: Table of Contents

- [About the Project](#star2-about-the-project)
- [Roadmap](#compass-roadmap)
- [Acknowledgements](#gem-acknowledgements)


## :star2: About the Project

### :camera: Screenshots
<div align="center"> <a href=""><img src="https://i.postimg.cc/4dvkXrss/rconfig.png" alt='image' width='800'/></a> </div>

<<<<<<< HEAD
## Example Using
https://i.postimg.cc/ZJ4WzpTg/1.png
<div align="left"> <a href=""><img src="https://i.postimg.cc/ZJ4WzpTg/1.png" alt='image' width='800'/></a> </div>
=======
>>>>>>> dee3f9c (Create README.md)


## :toolbox: Getting Started

<<<<<<< HEAD
### :gear: Installation for docker container

1-RConfig UI ( docker.yaml) #### ```bash  docker pull alizorlu/pretechsoftwarerconfigui ```
=======
### :gear: Installation

1-RConfig UI ( docker.yaml)
>>>>>>> dee3f9c (Create README.md)
```bash
version: '3'

services:
  rconfig_ui:
    container_name: rconfig_ui
    image: alizorlu/pretechsoftwarerconfigui
    restart: always
    mem_limit: 2g
    environment:
      - RootUser=admin
      - RootPassword=admin
      - RootSession=01:00:00
      - SqlType=MsSQL
<<<<<<< HEAD
      - Mysql=Server=mysql.example.server.com;Database=rconfig;Uid=root;Pwd=pass;
      - MsSQL=Server=mssql.example.ser.com;Database=RConfig;Uid=root;Pwd=pass;Application Name=Rconfig.Ui.Application;Integrated Security=False;TrustServerCertificate=True;MultipleActiveResultSets=True;
      - Postgresql=Server=server.test.local;Port=5432;Database=rconfig;User Id=postgres;Password=pass;
=======
      - TLS_VERSION=1
      - Mysql=Server=mysql.example.server.com;Database=rconfig;Uid=root;Pwd=pass;
      - MsSQL=Server=mssql.example.ser.com;Database=RConfig;Uid=root;Pwd=pass;Application Name=Rconfig.Ui.Application;Integrated Security=False;TrustServerCertificate=True;MultipleActiveResultSets=True;
>>>>>>> dee3f9c (Create README.md)
    ports:
      - "80:80"

```
<<<<<<< HEAD
2-RConfig API (docker.yaml) for docker container ```bash  docker pull alizorlu/pretechsoftwarerconfigapiserver ```
=======
2-RConfig API (docker.yaml)
>>>>>>> dee3f9c (Create README.md)
```bash
version: '3'

services:
  rconfig_api:
    container_name: rconfig_api
    image: alizorlu/pretechsoftwarerconfigapiserver
    restart: always
    mem_limit: 2g
    environment:
<<<<<<< HEAD
      - SqlType=Postgresql
      - Mysql=Server=mysql.example.server.com;Database=rconfig;Uid=root;Pwd=pass;
      - MsSQL=Server=mssql.example.ser.com;Database=RConfig;Uid=root;Pwd=pass;Application Name=Rconfig.Ui.Application;Integrated Security=False;TrustServerCertificate=True;MultipleActiveResultSets=True;
      - Postgresql=Server=server.test.local;Port=5432;Database=rconfig;User Id=postgres;Password=pass;
=======
      - SqlType=MsSQL
      - TLS_VERSION=1
      - Mysql=Server=mysql.example.server.com;Database=rconfig;Uid=root;Pwd=pass;
      - MsSQL=Server=mssql.example.ser.com;Database=RConfig;Uid=root;Pwd=pass;Application Name=Rconfig.Ui.Application;Integrated Security=False;TrustServerCertificate=True;MultipleActiveResultSets=True;
>>>>>>> dee3f9c (Create README.md)
    ports:
      - "80:80"

```
<<<<<<< HEAD
3-RConfig.Crypto(Dependency Ext . Lib) ```bash dotnet add package RConfig.Crypto.1.0.0 --version 1.0.0```
=======
3-RConfig.Crypto(Dependency Ext . Lib)
>>>>>>> dee3f9c (Create README.md)
```bash
NuGet\Install-Package RConfig.Crypto.1.0.0 -Version 1.0.0
```


## :compass: Roadmap

* [x] Key-based encryption (AES)
* [x] IP based access (RConfig API)
* [ ] Appending remote changes automatically on the stack side
* [ ] Support for other databases (primarily postgresql)
* [ ] Adding usage metrics to RConfig UI


## :gem: Acknowledgements

Use this section to mention useful resources and libraries that you have used in your projects.

- [Tabler (Rconfig UI )](https://github.com/tabler/tabler)
- [JSonFormatter](https://www.nuget.org/packages/JsonFormatterPlus)
