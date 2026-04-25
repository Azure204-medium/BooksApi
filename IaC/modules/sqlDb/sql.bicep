@description('location of the db server and database')
param location string
@description('Name of the sql sever')
param sqlServerName string
@description('Name of the sql DB')
param sqlDbName string
@description('sql admin user name')
param sqlAdminUserName string = 'sqlserveradmin'
@description('sql admin password')
param sqlAdminPassword string = 'Admin12345678!'

resource booksSqlServer 'Microsoft.Sql/servers@2025-02-01-preview' = {
  name: sqlServerName
  location: location
  properties: { administratorLogin: sqlAdminUserName, administratorLoginPassword: sqlAdminPassword }
}

resource booksSqlServerDatabase 'Microsoft.Sql/servers/databases@2025-02-01-preview' = {
  parent: booksSqlServer
  name: sqlDbName
  location: location
  sku: {
    name: 'Basic'
    tier: 'Basic'
    capacity: 5 // 5 DTUs - the minimum for Basic
  }
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS' // Standard default collation
    maxSizeBytes: 1073741824 // 1 GB - maximum for Basic tier
  }
}

resource sqlServerFirewallRules 'Microsoft.Sql/servers/firewallRules@2021-02-01-preview' = {
  parent: booksSqlServer
  name: 'allow azure resources'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

output sqlConnectionString string = 'Server=tcp:${booksSqlServer.properties.fullyQualifiedDomainName},1433;Initial Catalog=${booksSqlServerDatabase};Persist Security Info=False;User ID=${sqlAdminUserName};Password=${sqlAdminPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
