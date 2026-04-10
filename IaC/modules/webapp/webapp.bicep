@description('name of the app service plan')
param appServicePlanName string
@description('location of the app service plan')
param location string
@description('name of the web app')
param webAppName string

resource booksAppServicePlan 'Microsoft.Web/serverfarms@2024-04-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: 'F1'
    capacity: 1
  }
}

resource booksWebApplication 'Microsoft.Web/sites@2024-04-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: booksAppServicePlan.id
    siteConfig: { netFrameworkVersion: 'v9.0' }
  }
}
