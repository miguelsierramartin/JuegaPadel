variable "location" {
  default     = "West Europe"
  type        = string
  description = "RG location in Azure"
}

variable "sql_server_name" {
   type        = string
  description = "SQL Server instance name in Azure"
  default="sqlservertfg"
}

variable "sql_server_database_name" {
  type        = string
  description = "SQL Database name in Azure"
  default="sqldatabasetfg"
  }

variable "sql_admin_user" {
  type        = string
  description = "SQL Server login name in Azure"
  default="miguel"
}
variable "sql_admin_password" {
  type        = string
  description = "SQL Server password name in Azure"
  default="Polloasado#123"
}
