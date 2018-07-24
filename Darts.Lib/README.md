# 注意事項


**********專案初始**********

1. Install-Package Microsoft.EntityFrameworkCore.Tools
2. Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

Ps.需額外安裝Microsoft.AspNetCore.All,版本請選擇2.0.9 大於會不相容

**********Don't Try**********
注意：=> Install-Package Microsoft.EntityFrameworkCore.SqlServer

M$表示：需要安裝Microsoft.EntityFrameworkCore.SqlServer 

千萬不要安裝會出現以下錯誤，

「Unable to resolve service for type 'Microsoft.EntityFrameworkCore.Storage.IRelationalTypeMapper' 

while attempting to activate 'Microsoft.EntityFrameworkCore.Scaffolding.Internal.RelationalScaffoldingModelFactory'.」

**********如何利用Nuget Console更新資料庫Model至專案內**********<p>

1. 在Nuget Console選擇專案
2. 在Nuget Console輸入下列指令
Scaffold-DbContext "{0}" Microsoft.EntityFrameworkCore.SqlServer -OutputDir {1}

{0} => Connection String 可透過伺服器總管取得
{1} => Model存放路徑

**********注意**********

專案到新電腦時,如SQL尚未建立請修改Db Connection String 

並建立DataBase後並依序執行下列步驟

1. 開啟Nuget Console,並將預設專案調整為此專案名稱
2. 假設專案底下沒有Migrations資料夾
   請輸入：Enable-Migrations
   ,假如發生錯誤請將Migrations整個資料夾(包含資料)一起刪除再執行一次
3. Add-Migration Initial => Initial可修改為任何備註
4. Update-Database 輸入完成後即可回SQL SERVER檢查是否已更新完成
