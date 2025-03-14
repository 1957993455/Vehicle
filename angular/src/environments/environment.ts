 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44366/',
  redirectUri: baseUrl,
  clientId: 'App_App',
  responseType: 'code',
  scope: 'offline_access App',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'App',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44366',
      rootNamespace: 'Vehicle.App',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
