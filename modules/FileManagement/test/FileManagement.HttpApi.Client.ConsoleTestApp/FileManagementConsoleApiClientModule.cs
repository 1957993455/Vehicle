﻿using Vehicle.App.FileManagement.HttpApi.Client;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FileManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FileManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class FileManagementConsoleApiClientModule : AbpModule
{

}
