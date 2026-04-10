param location string
param web object

module devWebApp './modules/webapp/webapp.bicep' = {
  name: 'web'
  params: {
    location: location
    appServicePlanName: web.appServicePlanName
    webAppName: web.webAppName
  }
}
