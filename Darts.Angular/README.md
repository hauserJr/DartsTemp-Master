# Angular簡易說明


## ＊必要安裝軟體及步驟
### 安裝[nodejs](https://nodejs.org/en/)

安裝完後開啟CMD並Step By Step即可
* npm -v
`確認nodejs是否安裝正常`

* npm update
`進行更新確保nodeja維持在最新版本`

* npm install -g @angular/cli

* cd to `AngularPath`
`移至Angular專案底下`

* npm install

* npm i npm@latest -g

* npm install

* npm audit fix

* ng -v 
`確認ng是否安裝正常,如遇升級請直接cmd ng update即可`
* ng serve
`啟動專案`


## ＊Angular專案簡易介紹 (以此專案主要的檔案舉例)
* app-routing.module.ts
> 用途與net route差不多,用於決定各URL路徑的對應動作、屬性定義等

* AngularTempDataModel.ts
> 用途為Data Model，當介接後端資料時,名稱需一致 
> ### 注意：欄位名稱第一個字母絕對需要是小寫 !!!!!!

* message-list.component.ts
> 裡面定義了各式模板、服務 etc.。
> 
* message.service.ts
> 撰寫各類功能,提供注入使用。

簡易舉例：
當啟動本專案並輸入 `http://localhost:4200/messageList`
會依照以下流程去執行：
* Step 1 進入app-routing.module.ts，查詢該URL的動作為何
> * 由程式碼可以得知：
> 1. import 定義component路徑、檔案名稱及變數名稱
`此處component變數名稱為：MessageListComponent`
> 2. Routes 定義URL所對應的Component
`URL：../messageList 對應到的 Component為MessageListComponent`


```
#### 程式碼取自本專案'app-routing.module.ts'檔案的片段程式碼  ####
#### Path : DartsTemp-Master\Darts.Angular\ClientApp\src\app ####

import { MessageListComponent } from './message-list/message-list.component';
const routes: Routes = [
  { path: 'messageList', component: MessageListComponent },
  { path: '', redirectTo: 'messageList', pathMatch: 'full' },
];
```

* Step 2 進入Route指定的Component：message-list.component
> 由程式碼可以得知：
> * 此import可得知此Component會用到的Service及Model的路徑及檔名
> 1. Model ：
> 路徑：../
> 檔名：AngularTempDataModel
> 變數名稱：MessageService
> 2. Service ： 
> 路徑：../
> 檔名：message.service
> 變數名稱：MessageService
> * @Component則是設定此處所使用的樣板
> * 宣告Array Model的變數名稱
> * 在constructor注入Service
> * ngOnInit()執行程式Init動作() `呼叫getMessages()`
> * 進入getMessages()使用Services取得對應動作(此處使用getMsgs())
```
#### 程式碼取自本專案'message-list.component.ts'檔案的片段程式碼 ####
#### Path : .\Darts.Angular\ClientApp\src\app\message-list ####

import { AngularTempDataModel } from '../AngularTempDataModel';
import { MessageService } from '../message.service';
@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})

messages: AngularTempDataModel[];
  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.getMessages();
  }
  getMessages(): void {
    this.messageService.getMsgs()
      .subscribe(messages => this.messages = messages);

  }
```


* Step3 啟用Service
> * 從後端把資料拋過來會用Data Model來接,所以一樣會先Import Data Model
> * 在此Service會有很多Http設定，例如：Header etc.
> 因為我們會透過Http去跟後端溝通
> * 由於Step 2呼叫getMsgs()，所以此處會進入getMsgs
> * 而getMsgs內定義了接收的DataType、request methods及呼叫的URL
> 1. DataType : AngularTempDataModel[] (Array AngularTempDataModel)
> 2. request methods：GET
> 3. Url：messageUrl
```
...

import { AngularTempDataModel } from './AngularTempDataModel';

...

export class MessageService {
  private messageUrl = 'http://localhost:1974/api/Messages';

  constructor(private http: HttpClient) { }
  getMsgs(): Observable<AngularTempDataModel[]> {
    return this.http.get<AngularTempDataModel[]>(this.messageUrl).pipe(
      catchError(this.handleError<AngularTempDataModel[]>('getMessage'))
    );
  }

```
