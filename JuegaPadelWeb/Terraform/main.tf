provider "azurerm" {
  features{}
}

resource "azurerm_resource_group" "JuegaPadel-Sta" {
  name     = "JuegaPadel-stageIn"
  location = var.location

}

resource "azurerm_resource_group" "JuegaPadel-Prod" {
  name     = "JuegaPadel-prod"
  location = var.location

}
#Definimos el app service plan que queremos crear 
resource "azurerm_app_service_plan" "JuegaPadelASP-Sta" {
  name                = "ASP-JuegaPadelstageIn"
  location            = azurerm_resource_group.JuegaPadel-Sta.location
  resource_group_name = azurerm_resource_group.JuegaPadel-Sta.name

  sku {
    tier = "Free"
    size = "F1"
  }
}

#Definimos el app service plan que queremos crear 
resource "azurerm_app_service_plan" "JuegaPadelASP-Prod" {
  name                = "ASP-JuegaPadelprod"
  location            = azurerm_resource_group.JuegaPadel-Prod.location
  resource_group_name = azurerm_resource_group.JuegaPadel-Prod.name

  sku {
    tier = "Free"
    size = "F1"
  }
}

#Definimos el app service Desarrollo

resource "azurerm_app_service" "app_service_terraform" {
  name                = "jp-catalogSta"
  location            = azurerm_resource_group.JuegaPadel-Sta.location
  resource_group_name = azurerm_resource_group.JuegaPadel-Sta.name
  app_service_plan_id = azurerm_app_service_plan.JuegaPadelASP-Sta.id


  app_settings = {
    "ASPNETCORE_ENVIRONMENT"= "Development"
  }
  connection_string {
    name  = "Database"
    type  = "SQLAzure"
    value = "Server=tcp:azurerm_sql_server.sqlserver.fully_qualified_domain_name Database=azurerm_sql_database.sqldatabase.name;User ID=azurerm_sql_server.sqlserver.administrator_login;Password=azurerm_sql_server.sqlserver.administrator_login_password;Trusted_Connection=False;Encrypt=True;"
  }

}

resource "azurerm_app_service" "app_service_terraform" {
  name                = "jp-catalogProd"
  location            = azurerm_resource_group.JuegaPadel-Prod.location
  resource_group_name = azurerm_resource_group.JuegaPadel-Prod.name
  app_service_plan_id = azurerm_app_service_plan.JuegaPadelASP-Prod.id


  app_settings = {
    "ASPNETCORE_ENVIRONMENT"= "Production"
  }
  connection_string {
    name  = "Database"
    type  = "SQLAzure"
    value = "Server=tcp:azurerm_sql_server.sqlserver.fully_qualified_domain_name Database=azurerm_sql_database.sqldatabase.name;User ID=azurerm_sql_server.sqlserver.administrator_login;Password=azurerm_sql_server.sqlserver.administrator_login_password;Trusted_Connection=False;Encrypt=True;"
  }

}
