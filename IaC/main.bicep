param location string
param web object
param sql object
module devWebApp './modules/compute/webapp/webapp.bicep' = {
  name: 'web'
  params: {
    location: location
    appServicePlanName: web.appServicePlanName
    webAppName: web.webAppName
  }
}

module devSqlDb './modules/sqlDb/sql.bicep' = {
  name: 'sql'
  params: { location: location, sqlDbName: sql.sqlServerName, sqlServerName: sql.sqlDbName }
}

module devApim './modules/compute/apim/apim.bicep' = {
  name: 'dev-apim'
  params: {
    location: location
  }
}
