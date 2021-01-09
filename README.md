## 說明
* 網站服務提供單檔CRUD的網站功能。
* API服務提供單檔CRUD的API功能(可搭配postman.json檔)。
* 使用前，請於各服務專案中的Web.config檔設定資料庫連線字串。

## 專案
* Rogiluo.Common：含商業邏輯層、資料存取層和Models存放庫。
* Rogiluo.WebAPI：API服務。
* Rogiluo.Website：網站服務。

## ORM
* 使用Entity Framework Core，並採用Code First方式。
* 相關指令：
1. add-migration【migration】-Context【DbContext】：新增移轉腳本。
2. update-database -Context【DbContext】：更新資料庫。

