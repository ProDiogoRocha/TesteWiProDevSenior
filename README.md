# Teste DEV Senior WiPro

* Resposta para o teste de C# **API** e **Console** - Pasta ***RespostaC#***;
* Resposta para o teste de **SQL** - Pasta ***RespostaSQL***;
* Scripts de **"Create Table"** e **Carga** - Pasta ***Scripts***
* ENDPOINT e JSON para request:
  * **ENPOINT** adicionar na FILA
    * : api/itemfila/additemfila;
  ~~~json
    [
      {
          "moeda": "USD",
          "data_inicio": "2010-01-01",
          "data_fim": "2010-12-01"
      },
      {
          "moeda": "EUR",
          "data_inicio": "2020-01-01",
          "data_fim": "2010-12-01"
      },
      {
          "moeda": "JPY",
          "data_inicio": "2000-03-11",
          "data_fim": "2000-03-30"
      }
    ]
  ~~~

* **ENDPOINT** para consulmir FILA:
  * api/itemfila/getitemfila