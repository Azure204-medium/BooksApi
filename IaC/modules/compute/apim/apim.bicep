@description('location')
param location string

// create apim 
resource apiManagementInstance 'Microsoft.ApiManagement/service@2025-03-01-preview' = {
  name: 'bookapim'
  location: location
  sku: {
    capacity: 1
    name: 'Developer'
  }
  properties: {
    virtualNetworkType: 'None'
    publisherEmail: 'rajaaz104learner02@outlook.com'
    publisherName: 'books-app'
  }
}

// create api
resource api 'Microsoft.ApiManagement/service/apis@2025-03-01-preview' = {
  name: 'books-api'
  parent: apiManagementInstance
  properties: {
    displayName: 'books api'
    path: 'books'
    protocols: ['https']
    serviceUrl: 'https://books-webapp-dev.azurewebsites.net'
  }
}

// create operation

resource getBooks 'Microsoft.ApiManagement/service/apis/operations@2025-03-01-preview' = {
  name: 'getBooks'
  parent: api
  properties: {
    method: 'GET'
    displayName: 'get books'
    urlTemplate: '/books'
  }
}

// create product
resource product 'Microsoft.ApiManagement/service/products@2025-03-01-preview' = {
  name: 'unlimited'
  parent: apiManagementInstance
  properties: {
    displayName: 'books unlimited'
    subscriptionRequired: false
    state: 'published'
  }
}
// tie product and api
resource productApi 'Microsoft.ApiManagement/service/products/apis@2025-03-01-preview' = {
  name: 'books-api'
  parent: product
  dependsOn: [
    api
  ]
}

// api policy
resource apiPolicy 'Microsoft.ApiManagement/service/apis/policies@2025-03-01-preview' = {
  name: 'policy'
  parent: api
  properties: {
    format: 'xml'
    value: '''
    <policies>
    <inbound>
      <rate-limit calls="10" renewal-period="60" />
      <base />
    </inbound>
    <backend>
      <base />
    </backend>
    <outbound>
      <base />
    </outbound>
  </policies>
    '''
  }
}
